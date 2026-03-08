namespace PawsTrack.Presentation.Forms
{
    partial class ClientIntakeUC
    {
        private System.ComponentModel.IContainer components = null;

        // ── Search panel ───────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSearchHeader;
        private System.Windows.Forms.Label lblIntakeTitle;
        private System.Windows.Forms.Label lblIntakeSubtitle;
        private System.Windows.Forms.Button btnBackToDashboard;
        private System.Windows.Forms.Panel pnlSearchBar;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Panel pnlSearchFooter;
        private System.Windows.Forms.Button btnAddDogToClient;
        private System.Windows.Forms.Button btnCreateNew;

        // ── Form panel ─────────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlFormHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlScroll;

        // Client card
        private System.Windows.Forms.Panel pnlClientCard;
        private System.Windows.Forms.Label lblClientSection;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;

        // Dog card
        private System.Windows.Forms.Panel pnlDogCard;
        private System.Windows.Forms.Label lblDogSection;
        private System.Windows.Forms.Label lblDogName;
        private System.Windows.Forms.TextBox txtDogName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.ComboBox cmbBreed;
        private System.Windows.Forms.Label lblMedicalNotes;
        private System.Windows.Forms.TextBox txtMedicalNotes;

        // Form footer
        private System.Windows.Forms.Panel pnlFormFooter;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSearch = new Panel();
            dgvClients = new DataGridView();
            pnlSearchFooter = new Panel();
            btnAddDogToClient = new Button();
            btnCreateNew = new Button();
            pnlSearchBar = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            pnlSearchHeader = new Panel();
            btnBackToDashboard = new Button();
            lblIntakeTitle = new Label();
            lblIntakeSubtitle = new Label();
            pnlForm = new Panel();
            pnlScroll = new Panel();
            pnlClientCard = new Panel();
            lblClientSection = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            pnlDogCard = new Panel();
            lblDogSection = new Label();
            lblDogName = new Label();
            txtDogName = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblBreed = new Label();
            cmbBreed = new ComboBox();
            lblMedicalNotes = new Label();
            txtMedicalNotes = new TextBox();
            pnlFormFooter = new Panel();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            pnlFormHeader = new Panel();
            btnBack = new Button();
            lblFormTitle = new Label();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            pnlSearchFooter.SuspendLayout();
            pnlSearchBar.SuspendLayout();
            pnlSearchHeader.SuspendLayout();
            pnlForm.SuspendLayout();
            pnlScroll.SuspendLayout();
            pnlClientCard.SuspendLayout();
            pnlDogCard.SuspendLayout();
            pnlFormFooter.SuspendLayout();
            pnlFormHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(dgvClients);
            pnlSearch.Controls.Add(pnlSearchFooter);
            pnlSearch.Controls.Add(pnlSearchBar);
            pnlSearch.Controls.Add(pnlSearchHeader);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Margin = new Padding(3, 4, 3, 4);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(594, 864);
            pnlSearch.TabIndex = 1;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Dock = DockStyle.Fill;
            dgvClients.Location = new Point(0, 160);
            dgvClients.Margin = new Padding(3, 4, 3, 4);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(594, 624);
            dgvClients.TabIndex = 0;
            // 
            // pnlSearchFooter
            // 
            pnlSearchFooter.Controls.Add(btnAddDogToClient);
            pnlSearchFooter.Controls.Add(btnCreateNew);
            pnlSearchFooter.Dock = DockStyle.Bottom;
            pnlSearchFooter.Location = new Point(0, 784);
            pnlSearchFooter.Margin = new Padding(3, 4, 3, 4);
            pnlSearchFooter.Name = "pnlSearchFooter";
            pnlSearchFooter.Size = new Size(594, 80);
            pnlSearchFooter.TabIndex = 1;
            // 
            // btnAddDogToClient
            // 
            btnAddDogToClient.Location = new Point(18, 16);
            btnAddDogToClient.Margin = new Padding(3, 4, 3, 4);
            btnAddDogToClient.Name = "btnAddDogToClient";
            btnAddDogToClient.Size = new Size(274, 48);
            btnAddDogToClient.TabIndex = 0;
            btnAddDogToClient.Text = "Add Dog to Selected Client ▶";
            btnAddDogToClient.Click += btnAddDogToClient_Click;
            // 
            // btnCreateNew
            // 
            btnCreateNew.Location = new Point(306, 16);
            btnCreateNew.Margin = new Padding(3, 4, 3, 4);
            btnCreateNew.Name = "btnCreateNew";
            btnCreateNew.Size = new Size(229, 48);
            btnCreateNew.TabIndex = 1;
            btnCreateNew.Text = "+ Create New Client";
            btnCreateNew.Click += btnCreateNew_Click;
            // 
            // pnlSearchBar
            // 
            pnlSearchBar.Controls.Add(txtSearch);
            pnlSearchBar.Controls.Add(btnSearch);
            pnlSearchBar.Dock = DockStyle.Top;
            pnlSearchBar.Location = new Point(0, 93);
            pnlSearchBar.Margin = new Padding(3, 4, 3, 4);
            pnlSearchBar.Name = "pnlSearchBar";
            pnlSearchBar.Size = new Size(594, 67);
            pnlSearchBar.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(18, 16);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(399, 27);
            txtSearch.TabIndex = 0;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(430, 13);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 37);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlSearchHeader
            // 
            pnlSearchHeader.Controls.Add(btnBackToDashboard);
            pnlSearchHeader.Controls.Add(lblIntakeTitle);
            pnlSearchHeader.Controls.Add(lblIntakeSubtitle);
            pnlSearchHeader.Dock = DockStyle.Top;
            pnlSearchHeader.Location = new Point(0, 0);
            pnlSearchHeader.Margin = new Padding(3, 4, 3, 4);
            pnlSearchHeader.Name = "pnlSearchHeader";
            pnlSearchHeader.Size = new Size(594, 93);
            pnlSearchHeader.TabIndex = 3;
            // 
            // btnBackToDashboard
            // 
            btnBackToDashboard.Location = new Point(18, 21);
            btnBackToDashboard.Margin = new Padding(3, 4, 3, 4);
            btnBackToDashboard.Name = "btnBackToDashboard";
            btnBackToDashboard.Size = new Size(126, 37);
            btnBackToDashboard.TabIndex = 0;
            btnBackToDashboard.Text = "← Return to Schedule";
            btnBackToDashboard.Click += btnBackToDashboard_Click;
            // 
            // lblIntakeTitle
            // 
            lblIntakeTitle.Location = new Point(162, 19);
            lblIntakeTitle.Name = "lblIntakeTitle";
            lblIntakeTitle.Size = new Size(251, 32);
            lblIntakeTitle.TabIndex = 1;
            lblIntakeTitle.Text = "Client Intake";
            // 
            // lblIntakeSubtitle
            // 
            lblIntakeSubtitle.Location = new Point(162, 53);
            lblIntakeSubtitle.Name = "lblIntakeSubtitle";
            lblIntakeSubtitle.Size = new Size(411, 24);
            lblIntakeSubtitle.TabIndex = 2;
            lblIntakeSubtitle.Text = "Search an existing client or create a new one.";
            // 
            // pnlForm
            // 
            pnlForm.Controls.Add(pnlScroll);
            pnlForm.Controls.Add(pnlFormFooter);
            pnlForm.Controls.Add(pnlFormHeader);
            pnlForm.Dock = DockStyle.Fill;
            pnlForm.Location = new Point(0, 0);
            pnlForm.Margin = new Padding(3, 4, 3, 4);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(594, 864);
            pnlForm.TabIndex = 0;
            pnlForm.Visible = false;
            // 
            // pnlScroll
            // 
            pnlScroll.AutoScroll = true;
            pnlScroll.AutoScrollMinSize = new Size(0, 540);
            pnlScroll.Controls.Add(pnlClientCard);
            pnlScroll.Controls.Add(pnlDogCard);
            pnlScroll.Dock = DockStyle.Fill;
            pnlScroll.Location = new Point(0, 69);
            pnlScroll.Margin = new Padding(3, 4, 3, 4);
            pnlScroll.Name = "pnlScroll";
            pnlScroll.Size = new Size(594, 699);
            pnlScroll.TabIndex = 0;
            // 
            // pnlClientCard
            // 
            pnlClientCard.Controls.Add(lblClientSection);
            pnlClientCard.Controls.Add(lblFullName);
            pnlClientCard.Controls.Add(txtFullName);
            pnlClientCard.Controls.Add(lblPhone);
            pnlClientCard.Controls.Add(txtPhone);
            pnlClientCard.Controls.Add(lblAddress);
            pnlClientCard.Controls.Add(txtAddress);
            pnlClientCard.Location = new Point(18, 21);
            pnlClientCard.Margin = new Padding(3, 4, 3, 4);
            pnlClientCard.Name = "pnlClientCard";
            pnlClientCard.Size = new Size(539, 296);
            pnlClientCard.TabIndex = 0;
            // 
            // lblClientSection
            // 
            lblClientSection.Location = new Point(14, 16);
            lblClientSection.Name = "lblClientSection";
            lblClientSection.Size = new Size(229, 29);
            lblClientSection.TabIndex = 0;
            lblClientSection.Text = "Owner Details";
            // 
            // lblFullName
            // 
            lblFullName.Location = new Point(14, 59);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(137, 24);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name *";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(14, 85);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(511, 27);
            txtFullName.TabIndex = 2;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(14, 139);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(137, 24);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Phone *";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(14, 165);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(228, 27);
            txtPhone.TabIndex = 4;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(14, 219);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(137, 24);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address *";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(14, 245);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(511, 27);
            txtAddress.TabIndex = 6;
            // 
            // pnlDogCard
            // 
            pnlDogCard.Controls.Add(lblDogSection);
            pnlDogCard.Controls.Add(lblDogName);
            pnlDogCard.Controls.Add(txtDogName);
            pnlDogCard.Controls.Add(lblAge);
            pnlDogCard.Controls.Add(txtAge);
            pnlDogCard.Controls.Add(lblBreed);
            pnlDogCard.Controls.Add(cmbBreed);
            pnlDogCard.Controls.Add(lblMedicalNotes);
            pnlDogCard.Controls.Add(txtMedicalNotes);
            pnlDogCard.Location = new Point(18, 339);
            pnlDogCard.Margin = new Padding(3, 4, 3, 4);
            pnlDogCard.Name = "pnlDogCard";
            pnlDogCard.Size = new Size(539, 360);
            pnlDogCard.TabIndex = 1;
            // 
            // lblDogSection
            // 
            lblDogSection.Location = new Point(14, 16);
            lblDogSection.Name = "lblDogSection";
            lblDogSection.Size = new Size(229, 29);
            lblDogSection.TabIndex = 0;
            lblDogSection.Text = "Dog Details";
            // 
            // lblDogName
            // 
            lblDogName.Location = new Point(14, 59);
            lblDogName.Name = "lblDogName";
            lblDogName.Size = new Size(137, 24);
            lblDogName.TabIndex = 1;
            lblDogName.Text = "Dog Name *";
            // 
            // txtDogName
            // 
            txtDogName.Location = new Point(14, 85);
            txtDogName.Margin = new Padding(3, 4, 3, 4);
            txtDogName.Name = "txtDogName";
            txtDogName.Size = new Size(228, 27);
            txtDogName.TabIndex = 2;
            // 
            // lblAge
            // 
            lblAge.Location = new Point(274, 59);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(114, 24);
            lblAge.TabIndex = 3;
            lblAge.Text = "Age (years) *";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(274, 85);
            txtAge.Margin = new Padding(3, 4, 3, 4);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(91, 27);
            txtAge.TabIndex = 4;
            // 
            // lblBreed
            // 
            lblBreed.Location = new Point(14, 139);
            lblBreed.Name = "lblBreed";
            lblBreed.Size = new Size(137, 24);
            lblBreed.TabIndex = 5;
            lblBreed.Text = "Breed *";
            // 
            // cmbBreed
            // 
            cmbBreed.Location = new Point(14, 165);
            cmbBreed.Margin = new Padding(3, 4, 3, 4);
            cmbBreed.Name = "cmbBreed";
            cmbBreed.Size = new Size(511, 28);
            cmbBreed.TabIndex = 6;
            // 
            // lblMedicalNotes
            // 
            lblMedicalNotes.Location = new Point(14, 219);
            lblMedicalNotes.Name = "lblMedicalNotes";
            lblMedicalNotes.Size = new Size(137, 24);
            lblMedicalNotes.TabIndex = 7;
            lblMedicalNotes.Text = "Medical Notes";
            // 
            // txtMedicalNotes
            // 
            txtMedicalNotes.Location = new Point(14, 245);
            txtMedicalNotes.Margin = new Padding(3, 4, 3, 4);
            txtMedicalNotes.Multiline = true;
            txtMedicalNotes.Name = "txtMedicalNotes";
            txtMedicalNotes.ScrollBars = ScrollBars.Vertical;
            txtMedicalNotes.Size = new Size(511, 92);
            txtMedicalNotes.TabIndex = 8;
            // 
            // pnlFormFooter
            // 
            pnlFormFooter.Controls.Add(lblError);
            pnlFormFooter.Controls.Add(btnSave);
            pnlFormFooter.Controls.Add(btnCancel);
            pnlFormFooter.Dock = DockStyle.Bottom;
            pnlFormFooter.Location = new Point(0, 768);
            pnlFormFooter.Margin = new Padding(3, 4, 3, 4);
            pnlFormFooter.Name = "pnlFormFooter";
            pnlFormFooter.Size = new Size(594, 96);
            pnlFormFooter.TabIndex = 1;
            // 
            // lblError
            // 
            lblError.Location = new Point(18, 8);
            lblError.Name = "lblError";
            lblError.Size = new Size(539, 24);
            lblError.TabIndex = 0;
            lblError.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(18, 35);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(206, 48);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(238, 35);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 48);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlFormHeader
            // 
            pnlFormHeader.Controls.Add(btnBack);
            pnlFormHeader.Controls.Add(lblFormTitle);
            pnlFormHeader.Dock = DockStyle.Top;
            pnlFormHeader.Location = new Point(0, 0);
            pnlFormHeader.Margin = new Padding(3, 4, 3, 4);
            pnlFormHeader.Name = "pnlFormHeader";
            pnlFormHeader.Size = new Size(594, 69);
            pnlFormHeader.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(9, 13);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 40);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.Click += btnBack_Click;
            // 
            // lblFormTitle
            // 
            lblFormTitle.Location = new Point(200, 19);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(350, 29);
            lblFormTitle.TabIndex = 1;
            lblFormTitle.Text = "New Client & Dog";
            // 
            // ClientIntakeUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlForm);
            Controls.Add(pnlSearch);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ClientIntakeUC";
            Size = new Size(594, 864);
            pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            pnlSearchFooter.ResumeLayout(false);
            pnlSearchBar.ResumeLayout(false);
            pnlSearchBar.PerformLayout();
            pnlSearchHeader.ResumeLayout(false);
            pnlForm.ResumeLayout(false);
            pnlScroll.ResumeLayout(false);
            pnlClientCard.ResumeLayout(false);
            pnlClientCard.PerformLayout();
            pnlDogCard.ResumeLayout(false);
            pnlDogCard.PerformLayout();
            pnlFormFooter.ResumeLayout(false);
            pnlFormHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
