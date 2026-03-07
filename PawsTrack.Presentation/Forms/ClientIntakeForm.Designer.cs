namespace PawsTrack.Presentation.Forms
{
    partial class ClientIntakeForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Label lblClientSection;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.Panel pnlDog;
        private System.Windows.Forms.Label lblDogSection;
        private System.Windows.Forms.Label lblDogName;
        private System.Windows.Forms.TextBox txtDogName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.ComboBox cmbBreed;
        private System.Windows.Forms.Label lblMedicalNotes;
        private System.Windows.Forms.TextBox txtMedicalNotes;

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
            pnlClient        = new System.Windows.Forms.Panel();
            lblClientSection = new System.Windows.Forms.Label();
            lblFullName      = new System.Windows.Forms.Label();
            txtFullName      = new System.Windows.Forms.TextBox();
            lblPhone         = new System.Windows.Forms.Label();
            txtPhone         = new System.Windows.Forms.TextBox();
            lblAddress       = new System.Windows.Forms.Label();
            txtAddress       = new System.Windows.Forms.TextBox();

            pnlDog           = new System.Windows.Forms.Panel();
            lblDogSection    = new System.Windows.Forms.Label();
            lblDogName       = new System.Windows.Forms.Label();
            txtDogName       = new System.Windows.Forms.TextBox();
            lblAge           = new System.Windows.Forms.Label();
            txtAge           = new System.Windows.Forms.TextBox();
            lblBreed         = new System.Windows.Forms.Label();
            cmbBreed         = new System.Windows.Forms.ComboBox();
            lblMedicalNotes  = new System.Windows.Forms.Label();
            txtMedicalNotes  = new System.Windows.Forms.TextBox();

            lblError         = new System.Windows.Forms.Label();
            btnSave          = new System.Windows.Forms.Button();
            btnCancel        = new System.Windows.Forms.Button();

            pnlClient.SuspendLayout();
            pnlDog.SuspendLayout();
            SuspendLayout();

            // ── pnlClient ──────────────────────────────────────────────────────
            pnlClient.BackColor = System.Drawing.Color.White;
            pnlClient.Location  = new System.Drawing.Point(24, 16);
            pnlClient.Size      = new System.Drawing.Size(472, 230);
            pnlClient.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblClientSection, lblFullName, txtFullName,
                lblPhone, txtPhone, lblAddress, txtAddress
            });

            // ── lblClientSection ───────────────────────────────────────────────
            lblClientSection.Text     = "Owner Details";
            lblClientSection.Location = new System.Drawing.Point(12, 12);
            lblClientSection.Size     = new System.Drawing.Size(200, 22);

            // ── lblFullName / txtFullName ──────────────────────────────────────
            lblFullName.Text     = "Full Name *";
            lblFullName.Location = new System.Drawing.Point(12, 44);
            lblFullName.Size     = new System.Drawing.Size(120, 18);

            txtFullName.Location = new System.Drawing.Point(12, 64);
            txtFullName.Size     = new System.Drawing.Size(448, 23);

            // ── lblPhone / txtPhone ────────────────────────────────────────────
            lblPhone.Text     = "Phone *";
            lblPhone.Location = new System.Drawing.Point(12, 104);
            lblPhone.Size     = new System.Drawing.Size(120, 18);

            txtPhone.Location = new System.Drawing.Point(12, 124);
            txtPhone.Size     = new System.Drawing.Size(200, 23);

            // ── lblAddress / txtAddress ────────────────────────────────────────
            lblAddress.Text     = "Address *";
            lblAddress.Location = new System.Drawing.Point(12, 164);
            lblAddress.Size     = new System.Drawing.Size(120, 18);

            txtAddress.Location = new System.Drawing.Point(12, 184);
            txtAddress.Size     = new System.Drawing.Size(448, 23);

            // ── pnlDog ─────────────────────────────────────────────────────────
            pnlDog.BackColor = System.Drawing.Color.White;
            pnlDog.Location  = new System.Drawing.Point(24, 262);
            pnlDog.Size      = new System.Drawing.Size(472, 280);
            pnlDog.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblDogSection, lblDogName, txtDogName,
                lblAge, txtAge, lblBreed, cmbBreed,
                lblMedicalNotes, txtMedicalNotes
            });

            // ── lblDogSection ──────────────────────────────────────────────────
            lblDogSection.Text     = "Dog Details";
            lblDogSection.Location = new System.Drawing.Point(12, 12);
            lblDogSection.Size     = new System.Drawing.Size(200, 22);

            // ── lblDogName / txtDogName ────────────────────────────────────────
            lblDogName.Text     = "Dog Name *";
            lblDogName.Location = new System.Drawing.Point(12, 44);
            lblDogName.Size     = new System.Drawing.Size(120, 18);

            txtDogName.Location = new System.Drawing.Point(12, 64);
            txtDogName.Size     = new System.Drawing.Size(200, 23);

            // ── lblAge / txtAge ────────────────────────────────────────────────
            lblAge.Text     = "Age (years) *";
            lblAge.Location = new System.Drawing.Point(240, 44);
            lblAge.Size     = new System.Drawing.Size(100, 18);

            txtAge.Location = new System.Drawing.Point(240, 64);
            txtAge.Size     = new System.Drawing.Size(80, 23);

            // ── lblBreed / cmbBreed ────────────────────────────────────────────
            lblBreed.Text     = "Breed *";
            lblBreed.Location = new System.Drawing.Point(12, 104);
            lblBreed.Size     = new System.Drawing.Size(120, 18);

            cmbBreed.Location = new System.Drawing.Point(12, 124);
            cmbBreed.Size     = new System.Drawing.Size(448, 23);

            // ── lblMedicalNotes / txtMedicalNotes ──────────────────────────────
            lblMedicalNotes.Text     = "Medical Notes";
            lblMedicalNotes.Location = new System.Drawing.Point(12, 164);
            lblMedicalNotes.Size     = new System.Drawing.Size(120, 18);

            txtMedicalNotes.Location   = new System.Drawing.Point(12, 184);
            txtMedicalNotes.Size       = new System.Drawing.Size(448, 70);
            txtMedicalNotes.Multiline  = true;
            txtMedicalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // ── lblError ───────────────────────────────────────────────────────
            lblError.Location  = new System.Drawing.Point(24, 558);
            lblError.Size      = new System.Drawing.Size(472, 18);
            lblError.Visible   = false;

            // ── btnSave ────────────────────────────────────────────────────────
            btnSave.Text     = "Save Client & Dog";
            btnSave.Location = new System.Drawing.Point(24, 584);
            btnSave.Size     = new System.Drawing.Size(220, 42);
            btnSave.Click   += new System.EventHandler(btnSave_Click);

            // ── btnCancel ──────────────────────────────────────────────────────
            btnCancel.Text     = "Cancel";
            btnCancel.Location = new System.Drawing.Point(276, 584);
            btnCancel.Size     = new System.Drawing.Size(120, 42);
            btnCancel.Click   += new System.EventHandler(btnCancel_Click);

            // ── ClientIntakeForm ───────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(520, 648);
            FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            MinimizeBox         = false;
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            Text                = "New Client & Dog Intake";
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                pnlClient, pnlDog, lblError, btnSave, btnCancel
            });

            pnlClient.ResumeLayout(false);
            pnlDog.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
