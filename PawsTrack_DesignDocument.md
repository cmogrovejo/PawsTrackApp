PawsTrack - System Design Document

This document outlines the high-level system design for a desktop application called "PawsTrack". It covers the core components, architecture, data flow, and key design considerations.

# 1\. Introduction

This system design document details the technical approach and architecture for developing a desktop application. The application aims to manage client and dog information for a dog walking business. This document is intended for the development and architecture teams.

# 2\. Goals and Requirements

## 2.1. Key Goals

- **Performance:** Provide a fast and responsive user experience.
- **Reliability:** Ensure high stability and minimal crashes.
- **User Experience (UX):** Offer an intuitive and modern user interface.
- **Security:** Protect user data and application integrity.

## 2.2. Functional Requirements

- Include fields for client name, phone number, dog name, breed, age, walk date, and duration.
- Add buttons for saving, clearing, deleting, and exiting.
- Implement validation for relevant fields.
- Ensure the save button stores the information and displays a confirmation message.
- Delete should remove the item. Don't allow them to delete a "Completed" walk, it will mess up their Reporting/Billing.
- Clear button should reset all fields. Ensure "Clear" does not trigger a Save. It must only wipe the _temporary_ UI state in the current form..
- Exit button should close the application.
- Include an area to retrieve saved entries.
- Implement search functionality to find specific entries.
- Include error handling for unexpected inputs.
- Have a login flow
- Allow for adding a dog walk for a client that records information about the event
- Use validation messages where appropriate

This is our "Ship List":

| **Feature** | **Description** | **Priority** |
| ----------- | --------------- |:------------:|
| **User Profiles** | Basic login/password for multiple local users. | **High** |
| **The Pack Walk** | 1:N Dog-to-Walk relationship with "Clone/Repeat" feature. | **High** |
| **Invoicing Report** | Dog-hour totals with PDF/CSV export and Discount field. | **High** |
| **Client Update Report** | Behavioral/Health notes for the owner. | **Medium** |
| **Maintenance Modal** | Password-protected DB backup/restore and tech settings. | **Medium** |

## 2.3. Non-Functional Requirements

| Requirement | Description | Target Metric |
| ----------- | ----------- |:-------------:|
| Latency | UI response time for critical actions | < 500 ms |
| Memory Usage | Maximum memory footprint | < 500 MB |
| Operating Systems | Support for major desktop OS | Windows, macOS, Linux |
| Logging | Logs all app actions | We need to store app logs on text files |
| Installation | We need to configure the database creation and connection at the install time. | The app installed needs to be ready to use. |

# 3\. Architecture

Consider following aspects of the application architecture:

- Follow clean architecture following SOLID principles.
- Follow clear domain modeling.
- Proper validation and error handling.

The application must be developed in Windows Forms and save data in a SQL Server Database.

## 3.1. High-Level Components

### 3.1.1. Presentation layer (UI) Layer

This layer is responsible for rendering the application's visuals and handling user input.

- **Technology Stack:** Windows Forms
- **Components:**
  - Forms
- **Key Responsibilities:**
  - Rendering views and controls.
  - Handling input events (clicks, keyboard).
  - Communicating with the Business Logic Layer.
  - UI logic only
  - No business rules

### 3.1.2. Domain layer - Business Logic

The core of the application where all rules, processes, and state management reside.

- **Technology Stack:** C#
- **Components:**
  - Entities
  - Value objects
  - Core business rules
- **Key Responsibilities:**
  - Implementing application workflows.
  - Managing application state.
  - Coordinating data flow with the Data Access Layer.

### 3.1.3. Application layer

Connects the UI to the infrastructure layer.

- **Technology Stack:** C#
- **Components:**
  - Use cases
  - Services
  - Interfaces
- **Key Responsibilities:**
  - Implementing application connectors.
  - Managing application connections.
  - Coordinating data flow with the UI and Data Access Layer.

### 3.1.3. Infrastructure layer

This layer manages the interaction with local and remote data stores.

- **Key Responsibilities:**
  - Persistence (EF Core or equivalent)
  - Repository implementations

## 3.2. Data Flow

- User initiates an action in the UI Layer.
- The UI Layer forwards the request to the BLL.
- The BLL executes the required logic, potentially requesting data from the DAL.
- The DAL retrieves or stores data in the local persistent storage..
- The BLL processes the data and updates the application state.
- The BLL notifies the UI Layer of state changes.
- The UI Layer updates the displayed view.

# 4\. Use Cases

### Use Case 1: The "New Client & Pet" Intake

**Goal:** Efficiently register a billing entity (Owner) and the service recipient (Dog).

- **The Workflow:**

1\. Walker triggers "New Intake."

2\. **Input:** Owner Name, Phone, and Address.

3\. **Input (Dog):** Name, Age, Medical Notes, and **Breed (Standardized Dropdown)**.

4\. **The Connection:** The system links this Dog to the Owner for future reporting/billing.

- **PM Note:** We must ensure the "Breed" list is searchable/filterable within the dropdown so the user isn't scrolling through 200+ breeds.

### Use Case 2: The "Pack Walk" Lifecycle

**Goal:** Manage a walk session for multiple dogs simultaneously, ensuring accurate billing and history for each participant.

- **1\. Initiation (Scheduling/Staging):**
  - The Walker creates a new "Walk Session."
  - **The "Search & Add" Interface:** On the _same screen_, the walker uses a search bar to find dogs. Clicking a dog adds them to the "Current Pack" list.
  - **Efficiency Shortcut:** A "Clone Last Walk" or "Repeat Last Pack" button is available to instantly populate the list with the dogs from the most recent session.
- **2\. Execution (In-Progress):**
  - The session is marked as "Started." The system captures the timestamp.
  - **Pack Status:** The UI shows all dogs currently "on the leash."
- **3\. Completion & Batch Logging:**
  - Walker hits "Complete."
  - **Validation:** The system confirms the duration.
  - **Data Persistence:** The system creates _N_ individual billing records (one for each dog). If the walk was 60 minutes with 3 dogs, the database records 3 separate 60-minute entries tied to that specific Walk ID.
- **4\. Post-Action:**
  - A confirmation modal appears: _"Walk Completed. 3 Dog-Hours logged."_

### The Pricing & Discount Logic

You want to handle costs and discounts simply. Here is the **Data Flow** for the "Invoicing" Report:

- **Cost of Service:** We add a BaseRate field (e.g., \$20) to the **Walk Session**.
- **The "Whole Service" Discount:** We add a Discount field (percentage or flat amount) to the **Final Invoice/Report view**, not the individual walk.
- **Calculated Field:**  
    Total Bill = (sum of Dog-Hours X Base Rate) - Discount

### Data Integrity & The "Lifecycle" State

Since you want to manage the lifecycle, we need a more robust State Machine.

| **State** | **Allowed Actions** | **Logic** |
| --------- | ------------------- |:---------:|
| **Scheduled** | Edit Pack, Cancel, Start | Entry exists in DB with a ScheduledTime. |
| **In-Progress** | Add Note, Mark Complete | System records StartTime. Prevents "Deleting" the walk. |
| **Completed** | View, Archive | Records EndTime. Triggers the **Confirmation Modal** if the user tries to edit/delete. |

### Use Case 3: Business Intelligence (The Reporting Module)

**Goal:** Extract actionable data for billing and performance tracking.

- **Functional Requirements:**
  - **Client Billing Report:** Filter by Client + Date Range to show total walks and total hours (for invoicing).
  - **Activity Log:** A historical "Search" view to find specific past events or notes.
  - **Dog Health History:** A report showing all notes for a specific dog over time (valuable for owners).
- **PM Note:** For V1, let's prioritize the "Client Billing Report." If they can't get paid, the app is useless.

### The "Invoicing" Report (High Priority)

This is what the walker uses to bill their clients.

- **Detailed Columns:** \* **Date of Walk**
  - **Dog Name(s)** (Crucial for multi-dog owners)
  - **Duration per Dog** (The "Dog-Hour" unit)
  - **Rate/Total** (Optional: If we let them set a price per hour, we can calculate the total bill).
- **PM Note:** For an MVP, we don't need a fancy PDF generator. A **DataGrid view** with a **"Print to PDF"** and the **"Export to CSV"** button is the "Ruthless" way to ship this fast.

### The "Client Update" Report (Medium Priority)

Walkers often send a summary to the owners to show they are doing a good job.

- **Detailed Columns:**
  - **Walk Date/Time**
  - **Behavioral Notes** (e.g., "Max was very energetic today!")
  - **Medical/Poop Notes** (This sounds silly, but it's actually a top request from dog owners).
- **PM Note:** This builds "Customer Empathy." It shows the owner that the walker actually cares about the dog.

### User Stories: The Maintenance Toolkit

### Use Case 4: Secure Access (The Gatekeeper)

**As a** technical support person or advanced user, **I want** to enter a specific password to access the Maintenance Modal, **So that** I don't accidentally modify system-level settings during a normal dog-walking log.

- **Acceptance Criteria:**
  - Clicking the "Maintenance" button in Settings triggers a password prompt.
  - Incorrect passwords show a "Access Denied" message and log the attempt.
  - The password should be stored securely (hashed) in the local database or config file.

### Use Case 5: Manual Database Backup (The Safety Net)

**As a** dog walker who values my business data, **I want** to manually trigger a full backup of the SQL database to a chosen folder, **So that** I can recover my client history if my computer fails.

- **Acceptance Criteria:**
  - User can select a destination path via a standard folder browser.
  - The system generates a .bak (SQL) or compressed file with a timestamped name (e.g., PawsTrack_Backup_20260305.bak).
  - A "Success" message appears only after the file is verified on disk.

### Use Case 6: Database Restoration (The Recovery)

**As a** technical person, **I want** to select a previously saved backup file and restore the application state, **So that** I can recover lost data after a hardware migration or corruption.

- **Acceptance Criteria:**
  - The system warns the user that a restore will **overwrite** all current data.
  - The app must close all active database connections before attempting the restore.
  - The app restarts automatically (or prompts for restart) after a successful restore to reload the data.

### Use Case 7: User Password Reset (Shared Hardware Support)

**As a** maintenance user, **I want** to be able to reset the login password for any local user profile, **So that** a walker who forgets their password isn't permanently locked out of their data.

- **Acceptance Criteria:**
  - A list of all created User Profiles is displayed.
  - The "Admin" can select a user and enter a new temporary password.
  - The change is committed immediately to the Users table.

### Use Case 8: Data Purge/Cleanup (Performance)

**As a** long-term user, **I want** an option to delete walk logs older than 2 years, **So that** the local SQL Server instance remains performant and doesn't exceed storage limits.

- **Acceptance Criteria:**
  - A date-picker allows the user to select the "Cut-off Date."
  - A summary shows how many records will be deleted before the action is confirmed.
  - The action requires a "Double Confirmation" because it is irreversible.

# 4\. Technical Stack

| Component | Technology/Tool | Rationale |
| --------- | --------------- |:---------:|
| Framework | .NET Framework | Compatible for windows forms |
| Language | C#  | Most complete language for Windows Forms. |
| Database (Local) | SQL Server | Embedded and zero-configuration for desktop use. |
| Version Control | Git | Industry standard for collaborative development. |

# 5\. Deployment and Installation

## 5.1. Packaging

The application will be packaged into native installers for each supported operating system using WiX Toolset.

## 5.2. Distribution

The primary distribution channel will be direct installer download.