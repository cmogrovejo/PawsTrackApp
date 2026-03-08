namespace PawsTrack.Presentation.Forms
{
    partial class MainDashboardWalkerForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;

        // Nav bar
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlNavBorder;
        private System.Windows.Forms.Button btnTabSchedule;
        private System.Windows.Forms.Button btnTabBilling;
        private System.Windows.Forms.Button btnTabReports;

        // Body
        private System.Windows.Forms.Panel pnlBody;

        // Sidebar
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlSidebarBorder;
        private System.Windows.Forms.Panel pnlIntakeView;
        private System.Windows.Forms.Button btnNewService;
        private System.Windows.Forms.Button btnNewClient;

        // Main content host
        private System.Windows.Forms.Panel pnlMainContent;

        // Schedule view
        private System.Windows.Forms.Panel pnlScheduleView;
        private System.Windows.Forms.Panel pnlScheduleHeader;
        private System.Windows.Forms.Panel pnlScheduleHeaderBorder;
        private System.Windows.Forms.Label lblScheduleTitle;
        private System.Windows.Forms.DateTimePicker dtpScheduleDate;
        private System.Windows.Forms.Panel pnlTimeSlots;

        // Billing view
        private System.Windows.Forms.Panel pnlBillingView;
        private System.Windows.Forms.Panel pnlBillingHeader;
        private System.Windows.Forms.Label lblBillingTitle;
        private System.Windows.Forms.Panel pnlBillingHeaderBorder;
        private System.Windows.Forms.Panel pnlBillingSearch;
        private System.Windows.Forms.Label lblBillingClient;
        private System.Windows.Forms.TextBox txtBillingClient;
        private System.Windows.Forms.CheckBox chkBillingDate;
        private System.Windows.Forms.DateTimePicker dtpBillingDate;
        private System.Windows.Forms.Button btnBillingSearch;
        private System.Windows.Forms.Panel pnlBillingSearchBorder;
        private System.Windows.Forms.Panel pnlBillingResults;

        // Reports view
        private System.Windows.Forms.Panel pnlReportsView;
        private System.Windows.Forms.Label lblReportsPlaceholder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblAppTitle = new Label();
            lblUserInfo = new Label();
            btnLogout = new Button();
            pnlNav = new Panel();
            btnTabSchedule = new Button();
            btnTabBilling = new Button();
            btnTabReports = new Button();
            pnlNavBorder = new Panel();
            pnlBody = new Panel();
            pnlMainContent = new Panel();
            pnlScheduleView = new Panel();
            pnlTimeSlots = new Panel();
            pnlScheduleHeader = new Panel();
            lblScheduleTitle = new Label();
            dtpScheduleDate = new DateTimePicker();
            pnlScheduleHeaderBorder = new Panel();
            pnlBillingView = new Panel();
            pnlBillingHeader = new Panel();
            lblBillingTitle = new Label();
            pnlBillingHeaderBorder = new Panel();
            pnlBillingSearch = new Panel();
            lblBillingClient = new Label();
            txtBillingClient = new TextBox();
            chkBillingDate = new CheckBox();
            dtpBillingDate = new DateTimePicker();
            btnBillingSearch = new Button();
            pnlBillingSearchBorder = new Panel();
            pnlBillingResults = new Panel();
            pnlReportsView = new Panel();
            lblReportsPlaceholder = new Label();
            pnlIntakeView = new Panel();
            pnlSidebar = new Panel();
            btnNewService = new Button();
            btnNewClient = new Button();
            pnlSidebarBorder = new Panel();
            pnlHeader.SuspendLayout();
            pnlNav.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlScheduleView.SuspendLayout();
            pnlScheduleHeader.SuspendLayout();
            pnlBillingView.SuspendLayout();
            pnlBillingHeader.SuspendLayout();
            pnlBillingSearch.SuspendLayout();
            pnlReportsView.SuspendLayout();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblUserInfo);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1312, 85);
            pnlHeader.TabIndex = 2;
            //
            // lblAppTitle
            //
            lblAppTitle.Location = new Point(27, 13);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(183, 32);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "PawsTrack";
            //
            // lblUserInfo
            //
            lblUserInfo.Location = new Point(27, 48);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(686, 24);
            lblUserInfo.TabIndex = 1;
            //
            // btnLogout
            //
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(1049, 14);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(114, 48);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Log Out";
            btnLogout.Click += btnLogout_Click;
            //
            // pnlNav
            //
            pnlNav.BackColor = Color.White;
            pnlNav.Controls.Add(btnTabSchedule);
            pnlNav.Controls.Add(btnTabBilling);
            pnlNav.Controls.Add(btnTabReports);
            pnlNav.Controls.Add(pnlNavBorder);
            pnlNav.Dock = DockStyle.Top;
            pnlNav.Location = new Point(0, 85);
            pnlNav.Margin = new Padding(3, 4, 3, 4);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(1312, 59);
            pnlNav.TabIndex = 1;
            //
            // btnTabSchedule
            //
            btnTabSchedule.Location = new Point(0, 0);
            btnTabSchedule.Margin = new Padding(3, 4, 3, 4);
            btnTabSchedule.Name = "btnTabSchedule";
            btnTabSchedule.Size = new Size(206, 59);
            btnTabSchedule.TabIndex = 0;
            btnTabSchedule.Text = "Schedule && Services";
            btnTabSchedule.Click += btnTabSchedule_Click;
            //
            // btnTabBilling
            //
            btnTabBilling.Location = new Point(206, 0);
            btnTabBilling.Margin = new Padding(3, 4, 3, 4);
            btnTabBilling.Name = "btnTabBilling";
            btnTabBilling.Size = new Size(126, 59);
            btnTabBilling.TabIndex = 1;
            btnTabBilling.Text = "Billing";
            btnTabBilling.Click += btnTabBilling_Click;
            //
            // btnTabReports
            //
            btnTabReports.Location = new Point(331, 0);
            btnTabReports.Margin = new Padding(3, 4, 3, 4);
            btnTabReports.Name = "btnTabReports";
            btnTabReports.Size = new Size(126, 59);
            btnTabReports.TabIndex = 2;
            btnTabReports.Text = "Reports";
            btnTabReports.Click += btnTabReports_Click;
            //
            // pnlNavBorder
            //
            pnlNavBorder.Dock = DockStyle.Bottom;
            pnlNavBorder.Location = new Point(0, 58);
            pnlNavBorder.Margin = new Padding(3, 4, 3, 4);
            pnlNavBorder.Name = "pnlNavBorder";
            pnlNavBorder.Size = new Size(1312, 1);
            pnlNavBorder.TabIndex = 3;
            //
            // pnlBody
            //
            pnlBody.Controls.Add(pnlMainContent);
            pnlBody.Controls.Add(pnlSidebar);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 144);
            pnlBody.Margin = new Padding(3, 4, 3, 4);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(1312, 809);
            pnlBody.TabIndex = 0;
            //
            // pnlMainContent
            //
            pnlMainContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlMainContent.Controls.Add(pnlScheduleView);
            pnlMainContent.Controls.Add(pnlBillingView);
            pnlMainContent.Controls.Add(pnlReportsView);
            pnlMainContent.Controls.Add(pnlIntakeView);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(123, 0);
            pnlMainContent.Margin = new Padding(3, 4, 3, 4);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1189, 809);
            pnlMainContent.TabIndex = 0;
            //
            // pnlScheduleView
            //
            pnlScheduleView.Controls.Add(pnlTimeSlots);
            pnlScheduleView.Controls.Add(pnlScheduleHeader);
            pnlScheduleView.Dock = DockStyle.Fill;
            pnlScheduleView.Location = new Point(0, 0);
            pnlScheduleView.Margin = new Padding(3, 4, 3, 4);
            pnlScheduleView.Name = "pnlScheduleView";
            pnlScheduleView.Size = new Size(1189, 809);
            pnlScheduleView.TabIndex = 0;
            //
            // pnlTimeSlots
            //
            pnlTimeSlots.AutoScroll = true;
            pnlTimeSlots.BackColor = Color.White;
            pnlTimeSlots.Dock = DockStyle.Fill;
            pnlTimeSlots.Location = new Point(0, 62);
            pnlTimeSlots.Margin = new Padding(3, 4, 3, 4);
            pnlTimeSlots.Name = "pnlTimeSlots";
            pnlTimeSlots.Size = new Size(1189, 747);
            pnlTimeSlots.TabIndex = 0;
            //
            // pnlScheduleHeader
            //
            pnlScheduleHeader.BackColor = Color.White;
            pnlScheduleHeader.Controls.Add(lblScheduleTitle);
            pnlScheduleHeader.Controls.Add(dtpScheduleDate);
            pnlScheduleHeader.Controls.Add(pnlScheduleHeaderBorder);
            pnlScheduleHeader.Dock = DockStyle.Top;
            pnlScheduleHeader.Location = new Point(0, 0);
            pnlScheduleHeader.Margin = new Padding(3, 4, 3, 4);
            pnlScheduleHeader.Name = "pnlScheduleHeader";
            pnlScheduleHeader.Padding = new Padding(18, 11, 18, 0);
            pnlScheduleHeader.Size = new Size(1189, 62);
            pnlScheduleHeader.TabIndex = 1;
            //
            // lblScheduleTitle
            //
            lblScheduleTitle.Location = new Point(18, 11);
            lblScheduleTitle.Name = "lblScheduleTitle";
            lblScheduleTitle.Size = new Size(130, 40);
            lblScheduleTitle.TabIndex = 0;
            lblScheduleTitle.Text = "Schedule For:";
            lblScheduleTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpScheduleDate
            //
            dtpScheduleDate.CustomFormat = "dd/MM/yyyy";
            dtpScheduleDate.Format = DateTimePickerFormat.Custom;
            dtpScheduleDate.Location = new Point(165, 15);
            dtpScheduleDate.Margin = new Padding(3, 4, 3, 4);
            dtpScheduleDate.Name = "dtpScheduleDate";
            dtpScheduleDate.Size = new Size(169, 27);
            dtpScheduleDate.TabIndex = 1;
            dtpScheduleDate.ValueChanged += dtpScheduleDate_ValueChanged;
            //
            // pnlScheduleHeaderBorder
            //
            pnlScheduleHeaderBorder.Dock = DockStyle.Bottom;
            pnlScheduleHeaderBorder.Location = new Point(18, 61);
            pnlScheduleHeaderBorder.Margin = new Padding(3, 4, 3, 4);
            pnlScheduleHeaderBorder.Name = "pnlScheduleHeaderBorder";
            pnlScheduleHeaderBorder.Size = new Size(1153, 1);
            pnlScheduleHeaderBorder.TabIndex = 2;
            //
            // pnlBillingView
            //
            pnlBillingView.Controls.Add(pnlBillingResults);
            pnlBillingView.Controls.Add(pnlBillingSearch);
            pnlBillingView.Controls.Add(pnlBillingHeader);
            pnlBillingView.Dock = DockStyle.Fill;
            pnlBillingView.Location = new Point(0, 0);
            pnlBillingView.Margin = new Padding(3, 4, 3, 4);
            pnlBillingView.Name = "pnlBillingView";
            pnlBillingView.Size = new Size(1189, 809);
            pnlBillingView.TabIndex = 1;
            pnlBillingView.Visible = false;
            //
            // pnlBillingHeader
            //
            pnlBillingHeader.BackColor = Color.White;
            pnlBillingHeader.Controls.Add(lblBillingTitle);
            pnlBillingHeader.Controls.Add(pnlBillingHeaderBorder);
            pnlBillingHeader.Dock = DockStyle.Top;
            pnlBillingHeader.Location = new Point(0, 0);
            pnlBillingHeader.Name = "pnlBillingHeader";
            pnlBillingHeader.Size = new Size(1189, 62);
            pnlBillingHeader.TabIndex = 0;
            //
            // lblBillingTitle
            //
            lblBillingTitle.Location = new Point(18, 11);
            lblBillingTitle.Name = "lblBillingTitle";
            lblBillingTitle.Size = new Size(200, 40);
            lblBillingTitle.TabIndex = 0;
            lblBillingTitle.Text = "Billing";
            lblBillingTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlBillingHeaderBorder
            //
            pnlBillingHeaderBorder.Dock = DockStyle.Bottom;
            pnlBillingHeaderBorder.Location = new Point(0, 61);
            pnlBillingHeaderBorder.Name = "pnlBillingHeaderBorder";
            pnlBillingHeaderBorder.Size = new Size(1189, 1);
            pnlBillingHeaderBorder.TabIndex = 1;
            //
            // pnlBillingSearch
            //
            pnlBillingSearch.BackColor = Color.White;
            pnlBillingSearch.Controls.Add(lblBillingClient);
            pnlBillingSearch.Controls.Add(txtBillingClient);
            pnlBillingSearch.Controls.Add(chkBillingDate);
            pnlBillingSearch.Controls.Add(dtpBillingDate);
            pnlBillingSearch.Controls.Add(btnBillingSearch);
            pnlBillingSearch.Controls.Add(pnlBillingSearchBorder);
            pnlBillingSearch.Dock = DockStyle.Top;
            pnlBillingSearch.Location = new Point(0, 62);
            pnlBillingSearch.Name = "pnlBillingSearch";
            pnlBillingSearch.Padding = new Padding(18, 8, 18, 0);
            pnlBillingSearch.Size = new Size(1189, 56);
            pnlBillingSearch.TabIndex = 1;
            //
            // lblBillingClient
            //
            lblBillingClient.Location = new Point(20, 14);
            lblBillingClient.Name = "lblBillingClient";
            lblBillingClient.Size = new Size(50, 20);
            lblBillingClient.TabIndex = 0;
            lblBillingClient.Text = "Client:";
            lblBillingClient.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtBillingClient
            //
            txtBillingClient.Location = new Point(80, 11);
            txtBillingClient.Name = "txtBillingClient";
            txtBillingClient.Size = new Size(300, 27);
            txtBillingClient.TabIndex = 1;
            //
            // chkBillingDate
            //
            chkBillingDate.AutoSize = true;
            chkBillingDate.Location = new Point(390, 14);
            chkBillingDate.Name = "chkBillingDate";
            chkBillingDate.Size = new Size(70, 24);
            chkBillingDate.TabIndex = 2;
            chkBillingDate.Text = "By date";
            chkBillingDate.CheckedChanged += chkBillingDate_CheckedChanged;
            //
            // dtpBillingDate
            //
            dtpBillingDate.Enabled = false;
            dtpBillingDate.Format = DateTimePickerFormat.Short;
            dtpBillingDate.Location = new Point(480, 11);
            dtpBillingDate.Name = "dtpBillingDate";
            dtpBillingDate.Size = new Size(160, 27);
            dtpBillingDate.TabIndex = 3;
            //
            // btnBillingSearch
            //
            btnBillingSearch.Location = new Point(650, 9);
            btnBillingSearch.Name = "btnBillingSearch";
            btnBillingSearch.Size = new Size(90, 32);
            btnBillingSearch.TabIndex = 4;
            btnBillingSearch.Text = "Search";
            btnBillingSearch.Click += btnBillingSearch_Click;
            //
            // pnlBillingSearchBorder
            //
            pnlBillingSearchBorder.Dock = DockStyle.Bottom;
            pnlBillingSearchBorder.Location = new Point(18, 55);
            pnlBillingSearchBorder.Name = "pnlBillingSearchBorder";
            pnlBillingSearchBorder.Size = new Size(1153, 1);
            pnlBillingSearchBorder.TabIndex = 5;
            //
            // pnlBillingResults
            //
            pnlBillingResults.AutoScroll = true;
            pnlBillingResults.BackColor = Color.White;
            pnlBillingResults.Dock = DockStyle.Fill;
            pnlBillingResults.Location = new Point(0, 118);
            pnlBillingResults.Name = "pnlBillingResults";
            pnlBillingResults.Size = new Size(1189, 691);
            pnlBillingResults.TabIndex = 2;
            //
            // pnlReportsView
            //
            pnlReportsView.Controls.Add(lblReportsPlaceholder);
            pnlReportsView.Dock = DockStyle.Fill;
            pnlReportsView.Location = new Point(0, 0);
            pnlReportsView.Margin = new Padding(3, 4, 3, 4);
            pnlReportsView.Name = "pnlReportsView";
            pnlReportsView.Size = new Size(1189, 809);
            pnlReportsView.TabIndex = 2;
            pnlReportsView.Visible = false;
            //
            // lblReportsPlaceholder
            //
            lblReportsPlaceholder.Dock = DockStyle.Fill;
            lblReportsPlaceholder.Location = new Point(0, 0);
            lblReportsPlaceholder.Name = "lblReportsPlaceholder";
            lblReportsPlaceholder.Size = new Size(1189, 809);
            lblReportsPlaceholder.TabIndex = 0;
            lblReportsPlaceholder.Text = "Reports — coming soon.";
            lblReportsPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlIntakeView
            //
            pnlIntakeView.BackColor = Color.FromArgb(245, 247, 250);
            pnlIntakeView.Dock = DockStyle.Fill;
            pnlIntakeView.Location = new Point(0, 0);
            pnlIntakeView.Name = "pnlIntakeView";
            pnlIntakeView.Size = new Size(1189, 809);
            pnlIntakeView.TabIndex = 3;
            pnlIntakeView.Visible = false;
            //
            // pnlSidebar
            //
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.Controls.Add(btnNewService);
            pnlSidebar.Controls.Add(btnNewClient);
            pnlSidebar.Controls.Add(pnlSidebarBorder);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(3, 4, 3, 4);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(123, 809);
            pnlSidebar.TabIndex = 1;
            //
            // btnNewService
            //
            btnNewService.Location = new Point(14, 27);
            btnNewService.Margin = new Padding(3, 4, 3, 4);
            btnNewService.Name = "btnNewService";
            btnNewService.Size = new Size(96, 96);
            btnNewService.TabIndex = 0;
            btnNewService.Text = "+\nNew Service";
            btnNewService.Click += btnNewService_Click;
            //
            // btnNewClient
            //
            btnNewClient.Location = new Point(14, 144);
            btnNewClient.Margin = new Padding(3, 4, 3, 4);
            btnNewClient.Name = "btnNewClient";
            btnNewClient.Size = new Size(96, 96);
            btnNewClient.TabIndex = 1;
            btnNewClient.Text = "👤\nNew Client";
            btnNewClient.Click += btnNewDog_Click;
            //
            // pnlSidebarBorder
            //
            pnlSidebarBorder.Dock = DockStyle.Right;
            pnlSidebarBorder.Location = new Point(122, 0);
            pnlSidebarBorder.Margin = new Padding(3, 4, 3, 4);
            pnlSidebarBorder.Name = "pnlSidebarBorder";
            pnlSidebarBorder.Size = new Size(1, 809);
            pnlSidebarBorder.TabIndex = 3;
            //
            // MainDashboardWalkerForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1312, 953);
            Controls.Add(pnlBody);
            Controls.Add(pnlNav);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1026, 784);
            Name = "MainDashboardWalkerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PawsTrack";
            pnlHeader.ResumeLayout(false);
            pnlNav.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            pnlScheduleView.ResumeLayout(false);
            pnlScheduleHeader.ResumeLayout(false);
            pnlBillingView.ResumeLayout(false);
            pnlBillingHeader.ResumeLayout(false);
            pnlBillingSearch.ResumeLayout(false);
            pnlBillingSearch.PerformLayout();
            pnlReportsView.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
