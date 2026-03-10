namespace PawsTrack.Presentation.Forms
{
    partial class DatabaseSetupForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblAuth;
        private System.Windows.Forms.RadioButton rdoWindows;
        private System.Windows.Forms.RadioButton rdoSqlServer;
        private System.Windows.Forms.Label lblSqlUser;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.Label lblSqlPassword;
        private System.Windows.Forms.TextBox txtSqlPassword;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnContinue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            lblServer = new System.Windows.Forms.Label();
            txtServer = new System.Windows.Forms.TextBox();
            lblDatabase = new System.Windows.Forms.Label();
            txtDatabase = new System.Windows.Forms.TextBox();
            lblAuth = new System.Windows.Forms.Label();
            rdoWindows = new System.Windows.Forms.RadioButton();
            rdoSqlServer = new System.Windows.Forms.RadioButton();
            lblSqlUser = new System.Windows.Forms.Label();
            txtSqlUser = new System.Windows.Forms.TextBox();
            lblSqlPassword = new System.Windows.Forms.Label();
            txtSqlPassword = new System.Windows.Forms.TextBox();
            lblStatus = new System.Windows.Forms.Label();
            btnTest = new System.Windows.Forms.Button();
            btnContinue = new System.Windows.Forms.Button();
            pnlCard.SuspendLayout();
            SuspendLayout();
            //
            // pnlCard
            //
            pnlCard.BackColor = System.Drawing.Color.White;
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblServer);
            pnlCard.Controls.Add(txtServer);
            pnlCard.Controls.Add(lblDatabase);
            pnlCard.Controls.Add(txtDatabase);
            pnlCard.Controls.Add(lblAuth);
            pnlCard.Controls.Add(rdoWindows);
            pnlCard.Controls.Add(rdoSqlServer);
            pnlCard.Controls.Add(lblSqlUser);
            pnlCard.Controls.Add(txtSqlUser);
            pnlCard.Controls.Add(lblSqlPassword);
            pnlCard.Controls.Add(txtSqlPassword);
            pnlCard.Controls.Add(lblStatus);
            pnlCard.Controls.Add(btnTest);
            pnlCard.Controls.Add(btnContinue);
            pnlCard.Location = new System.Drawing.Point(46, 53);
            pnlCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new System.Drawing.Size(389, 778);
            pnlCard.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.Location = new System.Drawing.Point(23, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(343, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Database Setup";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSubtitle
            //
            lblSubtitle.Location = new System.Drawing.Point(23, 96);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(343, 48);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Configure your SQL Server connection to get started.";
            lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblServer
            //
            lblServer.Location = new System.Drawing.Point(34, 163);
            lblServer.Name = "lblServer";
            lblServer.Size = new System.Drawing.Size(320, 27);
            lblServer.TabIndex = 2;
            lblServer.Text = "Server";
            //
            // txtServer
            //
            txtServer.Location = new System.Drawing.Point(34, 192);
            txtServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtServer.Name = "txtServer";
            txtServer.Size = new System.Drawing.Size(319, 27);
            txtServer.TabIndex = 3;
            txtServer.Text = "localhost";
            //
            // lblDatabase
            //
            lblDatabase.Location = new System.Drawing.Point(34, 244);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new System.Drawing.Size(320, 27);
            lblDatabase.TabIndex = 4;
            lblDatabase.Text = "Database Name";
            //
            // txtDatabase
            //
            txtDatabase.Location = new System.Drawing.Point(34, 273);
            txtDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new System.Drawing.Size(319, 27);
            txtDatabase.TabIndex = 5;
            txtDatabase.Text = "PawsTrackDb";
            //
            // lblAuth
            //
            lblAuth.Location = new System.Drawing.Point(34, 325);
            lblAuth.Name = "lblAuth";
            lblAuth.Size = new System.Drawing.Size(320, 27);
            lblAuth.TabIndex = 6;
            lblAuth.Text = "Authentication";
            //
            // rdoWindows
            //
            rdoWindows.Location = new System.Drawing.Point(34, 357);
            rdoWindows.Name = "rdoWindows";
            rdoWindows.Size = new System.Drawing.Size(319, 27);
            rdoWindows.TabIndex = 7;
            rdoWindows.Text = "Windows Authentication";
            rdoWindows.CheckedChanged += rdoWindows_CheckedChanged;
            //
            // rdoSqlServer
            //
            rdoSqlServer.Location = new System.Drawing.Point(34, 387);
            rdoSqlServer.Name = "rdoSqlServer";
            rdoSqlServer.Size = new System.Drawing.Size(319, 27);
            rdoSqlServer.TabIndex = 8;
            rdoSqlServer.Text = "SQL Server Authentication";
            rdoSqlServer.CheckedChanged += rdoSqlServer_CheckedChanged;
            //
            // lblSqlUser
            //
            lblSqlUser.Location = new System.Drawing.Point(34, 427);
            lblSqlUser.Name = "lblSqlUser";
            lblSqlUser.Size = new System.Drawing.Size(320, 27);
            lblSqlUser.TabIndex = 9;
            lblSqlUser.Text = "SQL Username";
            //
            // txtSqlUser
            //
            txtSqlUser.Location = new System.Drawing.Point(34, 456);
            txtSqlUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSqlUser.Name = "txtSqlUser";
            txtSqlUser.Size = new System.Drawing.Size(319, 27);
            txtSqlUser.TabIndex = 10;
            //
            // lblSqlPassword
            //
            lblSqlPassword.Location = new System.Drawing.Point(34, 508);
            lblSqlPassword.Name = "lblSqlPassword";
            lblSqlPassword.Size = new System.Drawing.Size(320, 27);
            lblSqlPassword.TabIndex = 11;
            lblSqlPassword.Text = "SQL Password";
            //
            // txtSqlPassword
            //
            txtSqlPassword.Location = new System.Drawing.Point(34, 537);
            txtSqlPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSqlPassword.Name = "txtSqlPassword";
            txtSqlPassword.PasswordChar = '*';
            txtSqlPassword.Size = new System.Drawing.Size(319, 27);
            txtSqlPassword.TabIndex = 12;
            //
            // lblStatus
            //
            lblStatus.Location = new System.Drawing.Point(34, 591);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(320, 40);
            lblStatus.TabIndex = 13;
            lblStatus.Visible = false;
            //
            // btnTest
            //
            btnTest.Location = new System.Drawing.Point(34, 640);
            btnTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnTest.Name = "btnTest";
            btnTest.Size = new System.Drawing.Size(320, 56);
            btnTest.TabIndex = 14;
            btnTest.Text = "Test Connection";
            btnTest.Click += btnTest_Click;
            //
            // btnContinue
            //
            btnContinue.Enabled = false;
            btnContinue.Location = new System.Drawing.Point(34, 706);
            btnContinue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new System.Drawing.Size(320, 56);
            btnContinue.TabIndex = 15;
            btnContinue.Text = "Continue \u2192";
            btnContinue.Click += btnContinue_Click;
            //
            // DatabaseSetupForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(480, 884);
            Controls.Add(pnlCard);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "DatabaseSetupForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PawsTrack - Database Setup";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}
