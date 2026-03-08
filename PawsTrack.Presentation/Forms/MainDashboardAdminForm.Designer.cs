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
        private System.Windows.Forms.Panel pnlSearchBar;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlSearchBorder;
        private System.Windows.Forms.Panel pnlWalkerResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader       = new System.Windows.Forms.Panel();
            lblAppTitle     = new System.Windows.Forms.Label();
            lblUserInfo     = new System.Windows.Forms.Label();
            btnLogout       = new System.Windows.Forms.Button();
            pnlContent      = new System.Windows.Forms.Panel();
            pnlSearchBar    = new System.Windows.Forms.Panel();
            lblSearch       = new System.Windows.Forms.Label();
            txtSearch       = new System.Windows.Forms.TextBox();
            btnSearch       = new System.Windows.Forms.Button();
            pnlSearchBorder = new System.Windows.Forms.Panel();
            pnlWalkerResults = new System.Windows.Forms.Panel();

            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlSearchBar.SuspendLayout();
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

            // ── pnlSearchBorder ──────────────────────────────────────────────
            pnlSearchBorder.Dock   = System.Windows.Forms.DockStyle.Bottom;
            pnlSearchBorder.Height = 1;

            // ── lblSearch ────────────────────────────────────────────────────
            lblSearch.Text     = "Search walkers:";
            lblSearch.Location = new System.Drawing.Point(18, 18);
            lblSearch.Size     = new System.Drawing.Size(130, 20);

            // ── txtSearch ────────────────────────────────────────────────────
            txtSearch.Location = new System.Drawing.Point(155, 14);
            txtSearch.Size     = new System.Drawing.Size(260, 27);
            txtSearch.TabIndex = 0;

            // ── btnSearch ────────────────────────────────────────────────────
            btnSearch.Text     = "Search";
            btnSearch.Location = new System.Drawing.Point(425, 12);
            btnSearch.Size     = new System.Drawing.Size(90, 32);
            btnSearch.TabIndex = 1;
            btnSearch.Click   += new System.EventHandler(btnSearch_Click);

            // ── pnlSearchBar ─────────────────────────────────────────────────
            pnlSearchBar.Controls.Add(lblSearch);
            pnlSearchBar.Controls.Add(txtSearch);
            pnlSearchBar.Controls.Add(btnSearch);
            pnlSearchBar.Controls.Add(pnlSearchBorder);
            pnlSearchBar.Dock      = System.Windows.Forms.DockStyle.Top;
            pnlSearchBar.Height    = 56;
            pnlSearchBar.BackColor = System.Drawing.Color.White;

            // ── pnlWalkerResults ─────────────────────────────────────────────
            pnlWalkerResults.Dock       = System.Windows.Forms.DockStyle.Fill;
            pnlWalkerResults.AutoScroll = true;
            pnlWalkerResults.BackColor  = System.Drawing.Color.White;

            // ── pnlContent ───────────────────────────────────────────────────
            // Fill must be added before Top so DockStyle resolves correctly
            pnlContent.Controls.Add(pnlWalkerResults);
            pnlContent.Controls.Add(pnlSearchBar);
            pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill;
            pnlContent.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            // ── MainDashboardAdminForm ───────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(1200, 750);
            MinimumSize         = new System.Drawing.Size(1100, 700);
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text                = "PawsTrack \u2014 Admin";
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);

            pnlSearchBar.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
