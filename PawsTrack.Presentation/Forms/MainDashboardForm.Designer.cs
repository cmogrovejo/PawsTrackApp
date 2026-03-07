namespace PawsTrack.Presentation.Forms
{
    partial class MainDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblPlaceholder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader      = new System.Windows.Forms.Panel();
            lblAppTitle    = new System.Windows.Forms.Label();
            lblUserInfo    = new System.Windows.Forms.Label();
            btnLogout      = new System.Windows.Forms.Button();
            pnlContent     = new System.Windows.Forms.Panel();
            lblPlaceholder = new System.Windows.Forms.Label();

            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────────
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblUserInfo);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Height   = 64;

            // ── lblAppTitle ──────────────────────────────────────────────────
            lblAppTitle.Text     = "PawsTrack";
            lblAppTitle.Location = new System.Drawing.Point(24, 10);
            lblAppTitle.Size     = new System.Drawing.Size(160, 24);

            // ── lblUserInfo ──────────────────────────────────────────────────
            lblUserInfo.Location = new System.Drawing.Point(24, 36);
            lblUserInfo.Size     = new System.Drawing.Size(600, 18);

            // ── btnLogout ────────────────────────────────────────────────────
            btnLogout.Text     = "Log Out";
            btnLogout.Size     = new System.Drawing.Size(100, 36);
            btnLogout.Anchor   = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnLogout.Location = new System.Drawing.Point(880, 14);
            btnLogout.Click   += new System.EventHandler(btnLogout_Click);

            // ── pnlContent ───────────────────────────────────────────────────
            pnlContent.Controls.Add(lblPlaceholder);
            pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill;
            pnlContent.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            // ── lblPlaceholder ───────────────────────────────────────────────
            lblPlaceholder.Text      = "Dashboard \u2014 more features coming soon.";
            lblPlaceholder.Dock      = System.Windows.Forms.DockStyle.Fill;
            lblPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── MainDashboardForm ────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(1000, 650);
            MinimumSize         = new System.Drawing.Size(900, 600);
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text                = "PawsTrack";
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
