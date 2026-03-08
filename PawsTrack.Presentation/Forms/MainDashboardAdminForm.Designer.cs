namespace PawsTrack.Presentation.Forms
{
    partial class MainDashboardAdminForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblPlaceholder;
        private System.Windows.Forms.Label lblSectionActions;
        private System.Windows.Forms.Button btnNewIntake;
        private System.Windows.Forms.Button btnRegisterWalker;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader         = new System.Windows.Forms.Panel();
            lblAppTitle       = new System.Windows.Forms.Label();
            lblUserInfo       = new System.Windows.Forms.Label();
            btnLogout         = new System.Windows.Forms.Button();
            pnlContent        = new System.Windows.Forms.Panel();
            lblSectionActions = new System.Windows.Forms.Label();
            btnNewIntake      = new System.Windows.Forms.Button();
            btnRegisterWalker = new System.Windows.Forms.Button();
            lblPlaceholder    = new System.Windows.Forms.Label();

            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();

            // ── pnlHeader ────────────────────────────────────────────────────
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblUserInfo);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Dock   = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Height = 64;

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

            // ── lblSectionActions ────────────────────────────────────────────
            lblSectionActions.Text     = "Quick Actions";
            lblSectionActions.Location = new System.Drawing.Point(24, 16);
            lblSectionActions.Size     = new System.Drawing.Size(200, 24);

            // ── btnNewIntake ─────────────────────────────────────────────────
            btnNewIntake.Text     = "New Client & Dog Intake";
            btnNewIntake.Location = new System.Drawing.Point(24, 52);
            btnNewIntake.Size     = new System.Drawing.Size(220, 42);
            btnNewIntake.Click   += new System.EventHandler(btnNewIntake_Click);

            // ── btnRegisterWalker ────────────────────────────────────────────
            btnRegisterWalker.Text     = "Register New Walker";
            btnRegisterWalker.Location = new System.Drawing.Point(256, 52);
            btnRegisterWalker.Size     = new System.Drawing.Size(200, 42);
            btnRegisterWalker.Click   += new System.EventHandler(btnRegisterWalker_Click);

            // ── lblPlaceholder ───────────────────────────────────────────────
            lblPlaceholder.Text      = "Admin Dashboard \u2014 more features coming soon.";
            lblPlaceholder.Dock      = System.Windows.Forms.DockStyle.Fill;
            lblPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── pnlContent ───────────────────────────────────────────────────
            pnlContent.Controls.Add(lblPlaceholder);
            pnlContent.Controls.Add(btnRegisterWalker);
            pnlContent.Controls.Add(btnNewIntake);
            pnlContent.Controls.Add(lblSectionActions);
            pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill;
            pnlContent.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            // ── MainDashboardAdminForm ───────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(1000, 650);
            MinimumSize         = new System.Drawing.Size(900, 600);
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text                = "PawsTrack \u2014 Admin";
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
