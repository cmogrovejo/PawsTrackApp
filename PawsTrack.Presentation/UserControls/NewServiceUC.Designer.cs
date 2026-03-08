namespace PawsTrack.Presentation.UserControls
{
    partial class NewServiceUC
    {
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.Panel pnlBody;

        // Schedule section
        private System.Windows.Forms.Label lblScheduleSection;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblHourFrom;
        private System.Windows.Forms.NumericUpDown numHourFrom;
        private System.Windows.Forms.Label lblHourTo;
        private System.Windows.Forms.NumericUpDown numHourTo;

        // Client section
        private System.Windows.Forms.Label lblClientSection;
        private System.Windows.Forms.TextBox txtClientSearch;
        private System.Windows.Forms.Button btnSearchClient;
        private System.Windows.Forms.DataGridView dgvClients;

        // Dog section
        private System.Windows.Forms.Label lblDogSection;
        private System.Windows.Forms.ComboBox cmbDog;

        protected override void Dispose(bool disposing) => base.Dispose(disposing);

        private void InitializeComponent()
        {
            pnlHeader  = new System.Windows.Forms.Panel();
            lblTitle   = new System.Windows.Forms.Label();

            pnlFooter  = new System.Windows.Forms.Panel();
            lblError   = new System.Windows.Forms.Label();
            btnSave    = new System.Windows.Forms.Button();
            btnCancel  = new System.Windows.Forms.Button();

            pnlBody    = new System.Windows.Forms.Panel();

            lblScheduleSection = new System.Windows.Forms.Label();
            lblDate            = new System.Windows.Forms.Label();
            dtpDate            = new System.Windows.Forms.DateTimePicker();
            lblHourFrom        = new System.Windows.Forms.Label();
            numHourFrom        = new System.Windows.Forms.NumericUpDown();
            lblHourTo          = new System.Windows.Forms.Label();
            numHourTo          = new System.Windows.Forms.NumericUpDown();

            lblClientSection = new System.Windows.Forms.Label();
            txtClientSearch  = new System.Windows.Forms.TextBox();
            btnSearchClient  = new System.Windows.Forms.Button();
            dgvClients       = new System.Windows.Forms.DataGridView();

            lblDogSection = new System.Windows.Forms.Label();
            cmbDog        = new System.Windows.Forms.ComboBox();

            ((System.ComponentModel.ISupportInitialize)numHourFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHourTo).BeginInit();

            // ── pnlHeader ──────────────────────────────────────────────────────
            lblTitle.Text     = "New Service";
            lblTitle.Location = new System.Drawing.Point(16, 15);
            lblTitle.Size     = new System.Drawing.Size(300, 24);

            pnlHeader.Dock   = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Height = 54;
            pnlHeader.Controls.Add(lblTitle);

            // ── pnlFooter ──────────────────────────────────────────────────────
            lblError.Location = new System.Drawing.Point(16, 6);
            lblError.Size     = new System.Drawing.Size(472, 18);
            lblError.Visible  = false;

            btnSave.Text     = "Save Service";
            btnSave.Location = new System.Drawing.Point(16, 28);
            btnSave.Size     = new System.Drawing.Size(160, 36);
            btnSave.Click   += new System.EventHandler(btnSave_Click);

            btnCancel.Text     = "Cancel";
            btnCancel.Location = new System.Drawing.Point(190, 28);
            btnCancel.Size     = new System.Drawing.Size(100, 36);
            btnCancel.Click   += new System.EventHandler(btnCancel_Click);

            pnlFooter.Dock   = System.Windows.Forms.DockStyle.Bottom;
            pnlFooter.Height = 72;
            pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[]
                { lblError, btnSave, btnCancel });

            // ── pnlBody (scrollable content) ───────────────────────────────────
            // Schedule section
            lblScheduleSection.Text     = "Schedule";
            lblScheduleSection.Location = new System.Drawing.Point(16, 16);
            lblScheduleSection.Size     = new System.Drawing.Size(200, 22);

            lblDate.Text     = "Date *";
            lblDate.Location = new System.Drawing.Point(16, 48);
            lblDate.Size     = new System.Drawing.Size(60, 18);

            dtpDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDate.Location = new System.Drawing.Point(84, 44);
            dtpDate.Size     = new System.Drawing.Size(160, 23);

            lblHourFrom.Text     = "Hour From *";
            lblHourFrom.Location = new System.Drawing.Point(16, 84);
            lblHourFrom.Size     = new System.Drawing.Size(80, 18);

            numHourFrom.Minimum  = 0;
            numHourFrom.Maximum  = 23;
            numHourFrom.Location = new System.Drawing.Point(104, 80);
            numHourFrom.Size     = new System.Drawing.Size(56, 23);

            lblHourTo.Text     = "Hour To *";
            lblHourTo.Location = new System.Drawing.Point(180, 84);
            lblHourTo.Size     = new System.Drawing.Size(72, 18);

            numHourTo.Minimum  = 0;
            numHourTo.Maximum  = 23;
            numHourTo.Value    = 1;
            numHourTo.Location = new System.Drawing.Point(260, 80);
            numHourTo.Size     = new System.Drawing.Size(56, 23);

            // Client section
            lblClientSection.Text     = "Client";
            lblClientSection.Location = new System.Drawing.Point(16, 124);
            lblClientSection.Size     = new System.Drawing.Size(200, 22);

            txtClientSearch.Location  = new System.Drawing.Point(16, 154);
            txtClientSearch.Size      = new System.Drawing.Size(330, 23);
            txtClientSearch.KeyDown  += new System.Windows.Forms.KeyEventHandler(txtClientSearch_KeyDown);

            btnSearchClient.Text     = "Search";
            btnSearchClient.Location = new System.Drawing.Point(358, 152);
            btnSearchClient.Size     = new System.Drawing.Size(88, 28);
            btnSearchClient.Click   += new System.EventHandler(btnSearchClient_Click);

            dgvClients.Location                  = new System.Drawing.Point(16, 190);
            dgvClients.Size                      = new System.Drawing.Size(460, 130);
            dgvClients.AllowUserToAddRows        = false;
            dgvClients.AllowUserToDeleteRows     = false;
            dgvClients.ReadOnly                  = true;
            dgvClients.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect               = false;
            dgvClients.AutoSizeColumnsMode       = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.SelectionChanged          += new System.EventHandler(dgvClients_SelectionChanged);

            // Dog section
            lblDogSection.Text     = "Dog";
            lblDogSection.Location = new System.Drawing.Point(16, 338);
            lblDogSection.Size     = new System.Drawing.Size(200, 22);

            cmbDog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDog.Location      = new System.Drawing.Point(16, 368);
            cmbDog.Size          = new System.Drawing.Size(460, 23);
            cmbDog.Enabled       = false;

            pnlBody.Dock                = System.Windows.Forms.DockStyle.Fill;
            pnlBody.AutoScroll          = true;
            pnlBody.AutoScrollMinSize   = new System.Drawing.Size(0, 420);
            pnlBody.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblScheduleSection, lblDate, dtpDate,
                lblHourFrom, numHourFrom, lblHourTo, numHourTo,
                lblClientSection, txtClientSearch, btnSearchClient, dgvClients,
                lblDogSection, cmbDog
            });

            // ── UserControl ────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            Size                = new System.Drawing.Size(520, 560);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);

            ((System.ComponentModel.ISupportInitialize)numHourFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHourTo).EndInit();
        }
    }
}
