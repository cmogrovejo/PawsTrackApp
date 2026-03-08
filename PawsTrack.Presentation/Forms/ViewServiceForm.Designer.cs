namespace PawsTrack.Presentation.Forms
{
    partial class ViewServiceForm
    {
        private System.Windows.Forms.Panel  pnlCard;
        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Panel  pnlSep;

        private System.Windows.Forms.Label  lblOwnerCaption;
        private System.Windows.Forms.Label  lblOwnerValue;
        private System.Windows.Forms.Label  lblDogCaption;
        private System.Windows.Forms.Label  lblDogValue;
        private System.Windows.Forms.Label  lblDateCaption;
        private System.Windows.Forms.Label  lblDateValue;
        private System.Windows.Forms.Label  lblFromCaption;
        private System.Windows.Forms.Label  lblFromValue;
        private System.Windows.Forms.Label  lblToCaption;
        private System.Windows.Forms.Label  lblToValue;
        private System.Windows.Forms.Label  lblStatusCaption;
        private System.Windows.Forms.Label  lblStatusValue;

        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing) => base.Dispose(disposing);

        private void InitializeComponent()
        {
            pnlCard        = new System.Windows.Forms.Panel();
            lblTitle       = new System.Windows.Forms.Label();
            pnlSep         = new System.Windows.Forms.Panel();

            lblOwnerCaption  = new System.Windows.Forms.Label();
            lblOwnerValue    = new System.Windows.Forms.Label();
            lblDogCaption    = new System.Windows.Forms.Label();
            lblDogValue      = new System.Windows.Forms.Label();
            lblDateCaption   = new System.Windows.Forms.Label();
            lblDateValue     = new System.Windows.Forms.Label();
            lblFromCaption   = new System.Windows.Forms.Label();
            lblFromValue     = new System.Windows.Forms.Label();
            lblToCaption     = new System.Windows.Forms.Label();
            lblToValue       = new System.Windows.Forms.Label();
            lblStatusCaption = new System.Windows.Forms.Label();
            lblStatusValue   = new System.Windows.Forms.Label();

            btnClose = new System.Windows.Forms.Button();

            // ── card layout constants ───────────────────────────────────────────
            const int col1X  = 16;
            const int col2X  = 110;
            const int rowH   = 28;
            int       rowY   = 56;

            // ── pnlCard ────────────────────────────────────────────────────────
            lblTitle.Text      = "Walk Service Details";
            lblTitle.Location  = new System.Drawing.Point(16, 14);
            lblTitle.Size      = new System.Drawing.Size(360, 24);

            pnlSep.Location = new System.Drawing.Point(16, 44);
            pnlSep.Size     = new System.Drawing.Size(388, 1);

            void AddRow(System.Windows.Forms.Label cap, System.Windows.Forms.Label val,
                        string captionText, string valueText, ref int y)
            {
                cap.Text     = captionText;
                cap.Location = new System.Drawing.Point(col1X, y);
                cap.Size     = new System.Drawing.Size(90, 20);

                val.Text     = valueText;
                val.Location = new System.Drawing.Point(col2X, y);
                val.Size     = new System.Drawing.Size(300, 20);

                pnlCard.Controls.Add(cap);
                pnlCard.Controls.Add(val);
                y += rowH;
            }

            AddRow(lblOwnerCaption,  lblOwnerValue,  "Owner:",  string.Empty, ref rowY);
            AddRow(lblDogCaption,    lblDogValue,    "Dog:",    string.Empty, ref rowY);
            AddRow(lblDateCaption,   lblDateValue,   "Date:",   string.Empty, ref rowY);
            AddRow(lblFromCaption,   lblFromValue,   "From:",   string.Empty, ref rowY);
            AddRow(lblToCaption,     lblToValue,     "To:",     string.Empty, ref rowY);
            AddRow(lblStatusCaption, lblStatusValue, "Status:", string.Empty, ref rowY);

            btnClose.Text     = "Close";
            btnClose.Location = new System.Drawing.Point(col1X, rowY + 12);
            btnClose.Size     = new System.Drawing.Size(100, 34);
            btnClose.Click   += new System.EventHandler(btnClose_Click);

            pnlCard.Location = new System.Drawing.Point(20, 20);
            pnlCard.Size     = new System.Drawing.Size(420, btnClose.Bottom + 20);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(pnlSep);
            pnlCard.Controls.Add(btnClose);

            // ── form ───────────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(460, pnlCard.Bottom + 20);
            FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            MinimizeBox         = false;
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            Text                = "View Service";
            Controls.Add(pnlCard);
        }
    }
}
