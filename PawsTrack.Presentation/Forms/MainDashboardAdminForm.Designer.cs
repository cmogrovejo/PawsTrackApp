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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboardAdminForm));
            pnlHeader = new Panel();
            lblAppTitle = new Label();
            lblUserInfo = new Label();
            btnLogout = new Button();
            pnlContent = new Panel();
            pnlWalkerResults = new Panel();
            pnlSearchBar = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            pnlSearchBorder = new Panel();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlSearchBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblUserInfo);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1371, 85);
            pnlHeader.TabIndex = 1;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Location = new Point(27, 13);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(183, 32);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "PawsTrack";
            // 
            // lblUserInfo
            // 
            lblUserInfo.Location = new Point(27, 48);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(686, 24);
            lblUserInfo.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(1100, 19);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(114, 48);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Log Out";
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Controls.Add(pnlWalkerResults);
            pnlContent.Controls.Add(pnlSearchBar);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 85);
            pnlContent.Margin = new Padding(3, 4, 3, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1371, 915);
            pnlContent.TabIndex = 0;
            // 
            // pnlWalkerResults
            // 
            pnlWalkerResults.AutoScroll = true;
            pnlWalkerResults.BackColor = Color.White;
            pnlWalkerResults.Dock = DockStyle.Fill;
            pnlWalkerResults.Location = new Point(40, 75);
            pnlWalkerResults.Margin = new Padding(3, 4, 3, 4);
            pnlWalkerResults.Name = "pnlWalkerResults";
            pnlWalkerResults.Size = new Size(1371, 840);
            pnlWalkerResults.TabIndex = 0;
            // 
            // pnlSearchBar
            // 
            pnlSearchBar.BackColor = Color.White;
            pnlSearchBar.Controls.Add(lblSearch);
            pnlSearchBar.Controls.Add(txtSearch);
            pnlSearchBar.Controls.Add(btnSearch);
            pnlSearchBar.Controls.Add(pnlSearchBorder);
            pnlSearchBar.Dock = DockStyle.Top;
            pnlSearchBar.Location = new Point(0, 0);
            pnlSearchBar.Margin = new Padding(3, 4, 3, 4);
            pnlSearchBar.Name = "pnlSearchBar";
            pnlSearchBar.Size = new Size(1371, 75);
            pnlSearchBar.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(21, 24);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(149, 27);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search walkers:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(177, 19);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(297, 27);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(486, 16);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 43);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlSearchBorder
            // 
            pnlSearchBorder.Dock = DockStyle.Bottom;
            pnlSearchBorder.Location = new Point(0, 74);
            pnlSearchBorder.Margin = new Padding(3, 4, 3, 4);
            pnlSearchBorder.Name = "pnlSearchBorder";
            pnlSearchBorder.Size = new Size(1371, 1);
            pnlSearchBorder.TabIndex = 2;
            // 
            // MainDashboardAdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1000);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1255, 918);
            Name = "MainDashboardAdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PawsTrack - Admin Dashboard";
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlSearchBar.ResumeLayout(false);
            pnlSearchBar.PerformLayout();
            ResumeLayout(false);
        }
    }
}
