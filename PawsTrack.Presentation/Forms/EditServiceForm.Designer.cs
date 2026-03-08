namespace PawsTrack.Presentation.Forms
{
    partial class EditServiceForm
    {
        private System.Windows.Forms.Panel           pnlCard;
        private System.Windows.Forms.Label           lblTitle;
        private System.Windows.Forms.Panel           pnlSep;

        // Read-only info
        private System.Windows.Forms.Label           lblOwnerCaption;
        private System.Windows.Forms.Label           lblOwnerValue;
        private System.Windows.Forms.Label           lblDogCaption;
        private System.Windows.Forms.Label           lblDogValue;

        // Editable fields
        private System.Windows.Forms.Label           lblDate;
        private System.Windows.Forms.DateTimePicker  dtpDate;
        private System.Windows.Forms.Label           lblHourFrom;
        private System.Windows.Forms.NumericUpDown   numHourFrom;
        private System.Windows.Forms.Label           lblHourTo;
        private System.Windows.Forms.NumericUpDown   numHourTo;

        // Footer
        private System.Windows.Forms.Label           lblError;
        private System.Windows.Forms.Button          btnSave;
        private System.Windows.Forms.Button          btnCancel;

        protected override void Dispose(bool disposing) => base.Dispose(disposing);

        private void InitializeComponent()
        {
            pnlCard        = new System.Windows.Forms.Panel();
            lblTitle       = new System.Windows.Forms.Label();
            pnlSep         = new System.Windows.Forms.Panel();

            lblOwnerCaption = new System.Windows.Forms.Label();
            lblOwnerValue   = new System.Windows.Forms.Label();
            lblDogCaption   = new System.Windows.Forms.Label();
            lblDogValue     = new System.Windows.Forms.Label();

            lblDate     = new System.Windows.Forms.Label();
            dtpDate     = new System.Windows.Forms.DateTimePicker();
            lblHourFrom = new System.Windows.Forms.Label();
            numHourFrom = new System.Windows.Forms.NumericUpDown();
            lblHourTo   = new System.Windows.Forms.Label();
            numHourTo   = new System.Windows.Forms.NumericUpDown();

            lblError  = new System.Windows.Forms.Label();
            btnSave   = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)numHourFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHourTo).BeginInit();

            // ── Labels & positions ─────────────────────────────────────────────
            lblTitle.Text     = "Edit Walk Service";
            lblTitle.Location = new System.Drawing.Point(16, 14);
            lblTitle.Size     = new System.Drawing.Size(360, 24);

            pnlSep.Location = new System.Drawing.Point(16, 44);
            pnlSep.Size     = new System.Drawing.Size(388, 1);

            // read-only info
            lblOwnerCaption.Text     = "Owner:";
            lblOwnerCaption.Location = new System.Drawing.Point(16, 56);
            lblOwnerCaption.Size     = new System.Drawing.Size(80, 20);

            lblOwnerValue.Text     = string.Empty;
            lblOwnerValue.Location = new System.Drawing.Point(100, 56);
            lblOwnerValue.Size     = new System.Drawing.Size(304, 20);

            lblDogCaption.Text     = "Dog:";
            lblDogCaption.Location = new System.Drawing.Point(16, 82);
            lblDogCaption.Size     = new System.Drawing.Size(80, 20);

            lblDogValue.Text     = string.Empty;
            lblDogValue.Location = new System.Drawing.Point(100, 82);
            lblDogValue.Size     = new System.Drawing.Size(304, 20);

            // editable schedule
            lblDate.Text     = "Date *";
            lblDate.Location = new System.Drawing.Point(16, 118);
            lblDate.Size     = new System.Drawing.Size(60, 18);

            dtpDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDate.Location = new System.Drawing.Point(84, 114);
            dtpDate.Size     = new System.Drawing.Size(160, 23);
            dtpDate.MinDate  = DateTime.Today;

            lblHourFrom.Text     = "Hour From *";
            lblHourFrom.Location = new System.Drawing.Point(16, 156);
            lblHourFrom.Size     = new System.Drawing.Size(80, 18);

            numHourFrom.Minimum  = 0;
            numHourFrom.Maximum  = 23;
            numHourFrom.Location = new System.Drawing.Point(104, 152);
            numHourFrom.Size     = new System.Drawing.Size(56, 23);

            lblHourTo.Text     = "Hour To *";
            lblHourTo.Location = new System.Drawing.Point(180, 156);
            lblHourTo.Size     = new System.Drawing.Size(72, 18);

            numHourTo.Minimum  = 0;
            numHourTo.Maximum  = 23;
            numHourTo.Location = new System.Drawing.Point(260, 152);
            numHourTo.Size     = new System.Drawing.Size(56, 23);

            // footer
            lblError.Location = new System.Drawing.Point(16, 192);
            lblError.Size     = new System.Drawing.Size(388, 18);
            lblError.Visible  = false;

            btnSave.Text     = "Save Changes";
            btnSave.Location = new System.Drawing.Point(16, 216);
            btnSave.Size     = new System.Drawing.Size(150, 36);
            btnSave.Click   += new System.EventHandler(btnSave_Click);

            btnCancel.Text     = "Cancel";
            btnCancel.Location = new System.Drawing.Point(178, 216);
            btnCancel.Size     = new System.Drawing.Size(100, 36);
            btnCancel.Click   += new System.EventHandler(btnCancel_Click);

            // ── pnlCard ────────────────────────────────────────────────────────
            pnlCard.Location = new System.Drawing.Point(20, 20);
            pnlCard.Size     = new System.Drawing.Size(420, btnSave.Bottom + 20);
            pnlCard.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitle, pnlSep,
                lblOwnerCaption, lblOwnerValue,
                lblDogCaption, lblDogValue,
                lblDate, dtpDate,
                lblHourFrom, numHourFrom, lblHourTo, numHourTo,
                lblError, btnSave, btnCancel
            });

            // ── form ───────────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(460, pnlCard.Bottom + 20);
            FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            MinimizeBox         = false;
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            Text                = "Edit Service";
            Controls.Add(pnlCard);

            ((System.ComponentModel.ISupportInitialize)numHourFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHourTo).EndInit();
        }
    }
}
