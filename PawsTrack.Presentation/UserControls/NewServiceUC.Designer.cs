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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlFooter = new Panel();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            pnlBody = new Panel();
            lblScheduleSection = new Label();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblHourFrom = new Label();
            numHourFrom = new NumericUpDown();
            lblHourTo = new Label();
            numHourTo = new NumericUpDown();
            lblClientSection = new Label();
            txtClientSearch = new TextBox();
            btnSearchClient = new Button();
            dgvClients = new DataGridView();
            lblDogSection = new Label();
            cmbDog = new ComboBox();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHourFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHourTo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 72);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(18, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(343, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "New Service";
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(lblError);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 580);
            pnlFooter.Margin = new Padding(3, 4, 3, 4);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(900, 120);
            pnlFooter.TabIndex = 1;
            // 
            // lblError
            // 
            lblError.Location = new Point(18, 8);
            lblError.Name = "lblError";
            lblError.Size = new Size(840, 24);
            lblError.TabIndex = 0;
            lblError.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(20, 45);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(183, 48);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save Service";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(230, 45);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 48);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlBody
            // 
            pnlBody.AutoScroll = true;
            pnlBody.AutoScrollMinSize = new Size(0, 420);
            pnlBody.Controls.Add(lblScheduleSection);
            pnlBody.Controls.Add(lblDate);
            pnlBody.Controls.Add(dtpDate);
            pnlBody.Controls.Add(lblHourFrom);
            pnlBody.Controls.Add(numHourFrom);
            pnlBody.Controls.Add(lblHourTo);
            pnlBody.Controls.Add(numHourTo);
            pnlBody.Controls.Add(lblClientSection);
            pnlBody.Controls.Add(txtClientSearch);
            pnlBody.Controls.Add(btnSearchClient);
            pnlBody.Controls.Add(dgvClients);
            pnlBody.Controls.Add(lblDogSection);
            pnlBody.Controls.Add(cmbDog);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 72);
            pnlBody.Margin = new Padding(3, 4, 3, 4);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(900, 508);
            pnlBody.TabIndex = 0;
            // 
            // lblScheduleSection
            // 
            lblScheduleSection.Location = new Point(18, 21);
            lblScheduleSection.Name = "lblScheduleSection";
            lblScheduleSection.Size = new Size(229, 29);
            lblScheduleSection.TabIndex = 0;
            lblScheduleSection.Text = "Schedule";
            // 
            // lblDate
            // 
            lblDate.Location = new Point(20, 65);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(70, 24);
            lblDate.TabIndex = 1;
            lblDate.Text = "Date *";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(96, 60);
            dtpDate.Margin = new Padding(3, 4, 3, 4);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(180, 27);
            dtpDate.TabIndex = 2;
            // 
            // lblHourFrom
            // 
            lblHourFrom.Location = new Point(300, 65);
            lblHourFrom.Name = "lblHourFrom";
            lblHourFrom.Size = new Size(91, 24);
            lblHourFrom.TabIndex = 3;
            lblHourFrom.Text = "Hour From *";
            // 
            // numHourFrom
            // 
            numHourFrom.Location = new Point(400, 60);
            numHourFrom.Margin = new Padding(3, 4, 3, 4);
            numHourFrom.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            numHourFrom.Name = "numHourFrom";
            numHourFrom.Size = new Size(64, 27);
            numHourFrom.TabIndex = 4;
            // 
            // lblHourTo
            // 
            lblHourTo.Location = new Point(510, 62);
            lblHourTo.Name = "lblHourTo";
            lblHourTo.Size = new Size(82, 24);
            lblHourTo.TabIndex = 5;
            lblHourTo.Text = "Hour To *";
            // 
            // numHourTo
            // 
            numHourTo.Location = new Point(610, 60);
            numHourTo.Margin = new Padding(3, 4, 3, 4);
            numHourTo.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            numHourTo.Name = "numHourTo";
            numHourTo.Size = new Size(64, 27);
            numHourTo.TabIndex = 6;
            numHourTo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblClientSection
            // 
            lblClientSection.Location = new Point(18, 100);
            lblClientSection.Name = "lblClientSection";
            lblClientSection.Size = new Size(60, 29);
            lblClientSection.TabIndex = 7;
            lblClientSection.Text = "Client:";
            // 
            // txtClientSearch
            // 
            txtClientSearch.Location = new Point(18, 130);
            txtClientSearch.Margin = new Padding(3, 4, 3, 4);
            txtClientSearch.Name = "txtClientSearch";
            txtClientSearch.Size = new Size(377, 27);
            txtClientSearch.TabIndex = 8;
            txtClientSearch.KeyDown += txtClientSearch_KeyDown;
            // 
            // btnSearchClient
            // 
            btnSearchClient.Location = new Point(409, 120);
            btnSearchClient.Margin = new Padding(3, 4, 3, 4);
            btnSearchClient.Name = "btnSearchClient";
            btnSearchClient.Size = new Size(101, 37);
            btnSearchClient.TabIndex = 9;
            btnSearchClient.Text = "Search";
            btnSearchClient.Click += btnSearchClient_Click;
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(18, 180);
            dgvClients.Margin = new Padding(3, 4, 3, 4);
            dgvClients.MultiSelect = false;
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 51;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(700, 173);
            dgvClients.TabIndex = 10;
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
            // 
            // lblDogSection
            // 
            lblDogSection.Location = new Point(18, 380);
            lblDogSection.Name = "lblDogSection";
            lblDogSection.Size = new Size(229, 29);
            lblDogSection.TabIndex = 11;
            lblDogSection.Text = "Dog";
            // 
            // cmbDog
            // 
            cmbDog.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDog.Enabled = false;
            cmbDog.Location = new Point(18, 420);
            cmbDog.Margin = new Padding(3, 4, 3, 4);
            cmbDog.Name = "cmbDog";
            cmbDog.Size = new Size(525, 28);
            cmbDog.TabIndex = 12;
            // 
            // NewServiceUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NewServiceUC";
            Size = new Size(900, 700);
            pnlHeader.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHourFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHourTo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }
    }
}
