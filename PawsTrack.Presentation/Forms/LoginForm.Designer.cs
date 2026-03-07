namespace PawsTrack.Presentation.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsernameField;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPasswordField;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard          = new System.Windows.Forms.Panel();
            lblTitle         = new System.Windows.Forms.Label();
            lblSubtitle      = new System.Windows.Forms.Label();
            lblUsernameField = new System.Windows.Forms.Label();
            txtUsername      = new System.Windows.Forms.TextBox();
            lblPasswordField = new System.Windows.Forms.Label();
            txtPassword      = new System.Windows.Forms.TextBox();
            lblError         = new System.Windows.Forms.Label();
            btnLogin         = new System.Windows.Forms.Button();

            pnlCard.SuspendLayout();
            SuspendLayout();

            // ── pnlCard ──────────────────────────────────────────────────────
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblUsernameField);
            pnlCard.Controls.Add(txtUsername);
            pnlCard.Controls.Add(lblPasswordField);
            pnlCard.Controls.Add(txtPassword);
            pnlCard.Controls.Add(lblError);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Location  = new System.Drawing.Point(40, 50);
            pnlCard.Size      = new System.Drawing.Size(340, 400);
            pnlCard.BackColor = System.Drawing.Color.White;

            // ── lblTitle ─────────────────────────────────────────────────────
            lblTitle.Text      = "PawsTrack";
            lblTitle.Location  = new System.Drawing.Point(30, 28);
            lblTitle.Size      = new System.Drawing.Size(280, 44);
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblSubtitle ──────────────────────────────────────────────────
            lblSubtitle.Text      = "Sign in to your account";
            lblSubtitle.Location  = new System.Drawing.Point(30, 76);
            lblSubtitle.Size      = new System.Drawing.Size(280, 22);
            lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblUsernameField ─────────────────────────────────────────────
            lblUsernameField.Text     = "Username";
            lblUsernameField.Location = new System.Drawing.Point(30, 118);
            lblUsernameField.Size     = new System.Drawing.Size(280, 20);

            // ── txtUsername ──────────────────────────────────────────────────
            txtUsername.Location = new System.Drawing.Point(30, 140);
            txtUsername.Size     = new System.Drawing.Size(280, 38);

            // ── lblPasswordField ─────────────────────────────────────────────
            lblPasswordField.Text     = "Password";
            lblPasswordField.Location = new System.Drawing.Point(30, 196);
            lblPasswordField.Size     = new System.Drawing.Size(280, 20);

            // ── txtPassword ──────────────────────────────────────────────────
            txtPassword.Location     = new System.Drawing.Point(30, 218);
            txtPassword.Size         = new System.Drawing.Size(280, 38);
            txtPassword.PasswordChar = '*';

            // ── lblError ─────────────────────────────────────────────────────
            lblError.Location  = new System.Drawing.Point(30, 268);
            lblError.Size      = new System.Drawing.Size(280, 36);
            lblError.Visible   = false;

            // ── btnLogin ─────────────────────────────────────────────────────
            btnLogin.Text     = "Sign In";
            btnLogin.Location = new System.Drawing.Point(30, 316);
            btnLogin.Size     = new System.Drawing.Size(280, 42);
            btnLogin.Click   += new System.EventHandler(btnLogin_Click);

            // ── LoginForm ────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(420, 500);
            FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox         = false;
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text                = "PawsTrack - Login";
            Controls.Add(pnlCard);

            pnlCard.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
