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
            // Search panel
            pnlSearch        = new System.Windows.Forms.Panel();
            pnlSearchHeader  = new System.Windows.Forms.Panel();
            lblIntakeTitle   = new System.Windows.Forms.Label();
            lblIntakeSubtitle = new System.Windows.Forms.Label();
            btnBackToDashboard = new System.Windows.Forms.Button();
            pnlSearchBar     = new System.Windows.Forms.Panel();
            txtSearch        = new System.Windows.Forms.TextBox();
            btnSearch        = new System.Windows.Forms.Button();
            dgvClients       = new System.Windows.Forms.DataGridView();
            pnlSearchFooter  = new System.Windows.Forms.Panel();
            btnAddDogToClient = new System.Windows.Forms.Button();
            btnCreateNew     = new System.Windows.Forms.Button();

            // Form panel
            pnlForm          = new System.Windows.Forms.Panel();
            pnlFormHeader    = new System.Windows.Forms.Panel();
            btnBack          = new System.Windows.Forms.Button();
            lblFormTitle     = new System.Windows.Forms.Label();
            pnlScroll        = new System.Windows.Forms.Panel();

            pnlClientCard    = new System.Windows.Forms.Panel();
            lblClientSection = new System.Windows.Forms.Label();
            lblFullName      = new System.Windows.Forms.Label();
            txtFullName      = new System.Windows.Forms.TextBox();
            lblPhone         = new System.Windows.Forms.Label();
            txtPhone         = new System.Windows.Forms.TextBox();
            lblAddress       = new System.Windows.Forms.Label();
            txtAddress       = new System.Windows.Forms.TextBox();

            pnlDogCard       = new System.Windows.Forms.Panel();
            lblDogSection    = new System.Windows.Forms.Label();
            lblDogName       = new System.Windows.Forms.Label();
            txtDogName       = new System.Windows.Forms.TextBox();
            lblAge           = new System.Windows.Forms.Label();
            txtAge           = new System.Windows.Forms.TextBox();
            lblBreed         = new System.Windows.Forms.Label();
            cmbBreed         = new System.Windows.Forms.ComboBox();
            lblMedicalNotes  = new System.Windows.Forms.Label();
            txtMedicalNotes  = new System.Windows.Forms.TextBox();

            pnlFormFooter    = new System.Windows.Forms.Panel();
            lblError         = new System.Windows.Forms.Label();
            btnSave          = new System.Windows.Forms.Button();
            btnCancel        = new System.Windows.Forms.Button();

            // ── pnlSearchHeader ────────────────────────────────────────────────
            btnBackToDashboard.Text     = "\u2190 Return to Schedule";
            btnBackToDashboard.Location = new System.Drawing.Point(16, 16);
            btnBackToDashboard.Size     = new System.Drawing.Size(110, 28);
            btnBackToDashboard.Click   += new System.EventHandler(btnBackToDashboard_Click);

            lblIntakeTitle.Text      = "Client Intake";
            lblIntakeTitle.Location  = new System.Drawing.Point(142, 14);
            lblIntakeTitle.Size      = new System.Drawing.Size(220, 24);

            lblIntakeSubtitle.Text      = "Search an existing client or create a new one.";
            lblIntakeSubtitle.Location  = new System.Drawing.Point(142, 40);
            lblIntakeSubtitle.Size      = new System.Drawing.Size(360, 18);

            pnlSearchHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            pnlSearchHeader.Height   = 70;
            pnlSearchHeader.Controls.AddRange(new System.Windows.Forms.Control[]
                { btnBackToDashboard, lblIntakeTitle, lblIntakeSubtitle });

            // ── pnlSearchBar ───────────────────────────────────────────────────
            txtSearch.Location  = new System.Drawing.Point(16, 12);
            txtSearch.Size      = new System.Drawing.Size(350, 23);
            txtSearch.KeyDown  += new System.Windows.Forms.KeyEventHandler(txtSearch_KeyDown);

            btnSearch.Text      = "Search";
            btnSearch.Location  = new System.Drawing.Point(376, 10);
            btnSearch.Size      = new System.Drawing.Size(90, 28);
            btnSearch.Click    += new System.EventHandler(btnSearch_Click);

            pnlSearchBar.Dock   = System.Windows.Forms.DockStyle.Top;
            pnlSearchBar.Height = 50;
            pnlSearchBar.Controls.AddRange(new System.Windows.Forms.Control[]
                { txtSearch, btnSearch });

            // ── dgvClients ─────────────────────────────────────────────────────
            dgvClients.Dock                  = System.Windows.Forms.DockStyle.Fill;
            dgvClients.AllowUserToAddRows    = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.ReadOnly              = true;
            dgvClients.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect           = false;
            dgvClients.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // ── pnlSearchFooter ────────────────────────────────────────────────
            btnAddDogToClient.Text      = "Add Dog to Selected Client \u25b6";
            btnAddDogToClient.Location  = new System.Drawing.Point(16, 12);
            btnAddDogToClient.Size      = new System.Drawing.Size(240, 36);
            btnAddDogToClient.Click    += new System.EventHandler(btnAddDogToClient_Click);

            btnCreateNew.Text      = "+ Create New Client";
            btnCreateNew.Location  = new System.Drawing.Point(268, 12);
            btnCreateNew.Size      = new System.Drawing.Size(200, 36);
            btnCreateNew.Click    += new System.EventHandler(btnCreateNew_Click);

            pnlSearchFooter.Dock   = System.Windows.Forms.DockStyle.Bottom;
            pnlSearchFooter.Height = 60;
            pnlSearchFooter.Controls.AddRange(new System.Windows.Forms.Control[]
                { btnAddDogToClient, btnCreateNew });

            // ── pnlSearch (search panel root) ──────────────────────────────────
            pnlSearch.Dock    = System.Windows.Forms.DockStyle.Fill;
            pnlSearch.Visible = true;
            // Add in dock order: Top items first, then Fill, then Bottom
            pnlSearch.Controls.Add(dgvClients);         // Fill (added before other docked)
            pnlSearch.Controls.Add(pnlSearchFooter);    // Bottom
            pnlSearch.Controls.Add(pnlSearchBar);       // Top (added last = highest priority)
            pnlSearch.Controls.Add(pnlSearchHeader);    // Top

            // ── pnlClientCard ──────────────────────────────────────────────────
            lblClientSection.Text     = "Owner Details";
            lblClientSection.Location = new System.Drawing.Point(12, 12);
            lblClientSection.Size     = new System.Drawing.Size(200, 22);

            lblFullName.Text     = "Full Name *";
            lblFullName.Location = new System.Drawing.Point(12, 44);
            lblFullName.Size     = new System.Drawing.Size(120, 18);

            txtFullName.Location = new System.Drawing.Point(12, 64);
            txtFullName.Size     = new System.Drawing.Size(448, 23);

            lblPhone.Text     = "Phone *";
            lblPhone.Location = new System.Drawing.Point(12, 104);
            lblPhone.Size     = new System.Drawing.Size(120, 18);

            txtPhone.Location = new System.Drawing.Point(12, 124);
            txtPhone.Size     = new System.Drawing.Size(200, 23);

            lblAddress.Text     = "Address *";
            lblAddress.Location = new System.Drawing.Point(12, 164);
            lblAddress.Size     = new System.Drawing.Size(120, 18);

            txtAddress.Location = new System.Drawing.Point(12, 184);
            txtAddress.Size     = new System.Drawing.Size(448, 23);

            pnlClientCard.Location = new System.Drawing.Point(16, 16);
            pnlClientCard.Size     = new System.Drawing.Size(472, 222);
            pnlClientCard.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblClientSection, lblFullName, txtFullName,
                lblPhone, txtPhone, lblAddress, txtAddress
            });

            // ── pnlDogCard ─────────────────────────────────────────────────────
            lblDogSection.Text     = "Dog Details";
            lblDogSection.Location = new System.Drawing.Point(12, 12);
            lblDogSection.Size     = new System.Drawing.Size(200, 22);

            lblDogName.Text     = "Dog Name *";
            lblDogName.Location = new System.Drawing.Point(12, 44);
            lblDogName.Size     = new System.Drawing.Size(120, 18);

            txtDogName.Location = new System.Drawing.Point(12, 64);
            txtDogName.Size     = new System.Drawing.Size(200, 23);

            lblAge.Text     = "Age (years) *";
            lblAge.Location = new System.Drawing.Point(240, 44);
            lblAge.Size     = new System.Drawing.Size(100, 18);

            txtAge.Location = new System.Drawing.Point(240, 64);
            txtAge.Size     = new System.Drawing.Size(80, 23);

            lblBreed.Text     = "Breed *";
            lblBreed.Location = new System.Drawing.Point(12, 104);
            lblBreed.Size     = new System.Drawing.Size(120, 18);

            cmbBreed.Location = new System.Drawing.Point(12, 124);
            cmbBreed.Size     = new System.Drawing.Size(448, 23);

            lblMedicalNotes.Text     = "Medical Notes";
            lblMedicalNotes.Location = new System.Drawing.Point(12, 164);
            lblMedicalNotes.Size     = new System.Drawing.Size(120, 18);

            txtMedicalNotes.Location   = new System.Drawing.Point(12, 184);
            txtMedicalNotes.Size       = new System.Drawing.Size(448, 70);
            txtMedicalNotes.Multiline  = true;
            txtMedicalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            pnlDogCard.Location = new System.Drawing.Point(16, 254);
            pnlDogCard.Size     = new System.Drawing.Size(472, 270);
            pnlDogCard.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblDogSection, lblDogName, txtDogName,
                lblAge, txtAge, lblBreed, cmbBreed,
                lblMedicalNotes, txtMedicalNotes
            });

            // ── pnlScroll ──────────────────────────────────────────────────────
            pnlScroll.Dock                = System.Windows.Forms.DockStyle.Fill;
            pnlScroll.AutoScroll          = true;
            pnlScroll.AutoScrollMinSize   = new System.Drawing.Size(0, 540);
            pnlScroll.Controls.AddRange(new System.Windows.Forms.Control[]
                { pnlClientCard, pnlDogCard });

            // ── pnlFormHeader ──────────────────────────────────────────────────
            btnBack.Text      = "\u2190 Back";
            btnBack.Location  = new System.Drawing.Point(8, 10);
            btnBack.Size      = new System.Drawing.Size(72, 30);
            btnBack.Click    += new System.EventHandler(btnBack_Click);

            lblFormTitle.Text      = "New Client & Dog";
            lblFormTitle.Location  = new System.Drawing.Point(88, 14);
            lblFormTitle.Size      = new System.Drawing.Size(380, 22);

            pnlFormHeader.Dock   = System.Windows.Forms.DockStyle.Top;
            pnlFormHeader.Height = 52;
            pnlFormHeader.Controls.AddRange(new System.Windows.Forms.Control[]
                { btnBack, lblFormTitle });

            // ── pnlFormFooter ──────────────────────────────────────────────────
            lblError.Location  = new System.Drawing.Point(16, 6);
            lblError.Size      = new System.Drawing.Size(472, 18);
            lblError.Visible   = false;

            btnSave.Text     = "Save";
            btnSave.Location = new System.Drawing.Point(16, 28);
            btnSave.Size     = new System.Drawing.Size(180, 36);
            btnSave.Click   += new System.EventHandler(btnSave_Click);

            btnCancel.Text     = "Cancel";
            btnCancel.Location = new System.Drawing.Point(208, 28);
            btnCancel.Size     = new System.Drawing.Size(120, 36);
            btnCancel.Click   += new System.EventHandler(btnCancel_Click);

            pnlFormFooter.Dock   = System.Windows.Forms.DockStyle.Bottom;
            pnlFormFooter.Height = 72;
            pnlFormFooter.Controls.AddRange(new System.Windows.Forms.Control[]
                { lblError, btnSave, btnCancel });

            // ── pnlForm (form panel root) ──────────────────────────────────────
            pnlForm.Dock    = System.Windows.Forms.DockStyle.Fill;
            pnlForm.Visible = false;
            pnlForm.Controls.Add(pnlScroll);       // Fill
            pnlForm.Controls.Add(pnlFormFooter);   // Bottom
            pnlForm.Controls.Add(pnlFormHeader);   // Top

            // ── UserControl ────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            Size                = new System.Drawing.Size(520, 648);
            // pnlSearch added first so it occupies the Fill area when visible;
            // pnlForm also Fill but hidden initially.
            Controls.Add(pnlForm);
            Controls.Add(pnlSearch);
        }
    }
}
