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
        private System.Windows.Forms.LinkLabel lnkRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pnlCard = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblUsernameField = new Label();
            txtUsername = new TextBox();
            lblPasswordField = new Label();
            txtPassword = new TextBox();
            lblError = new Label();
            btnLogin = new Button();
            lnkRegister = new LinkLabel();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblUsernameField);
            pnlCard.Controls.Add(txtUsername);
            pnlCard.Controls.Add(lblPasswordField);
            pnlCard.Controls.Add(txtPassword);
            pnlCard.Controls.Add(lblError);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(lnkRegister);
            pnlCard.Location = new Point(46, 67);
            pnlCard.Margin = new Padding(3, 4, 3, 4);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(389, 552);
            pnlCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(34, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(320, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PawsTrack";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Location = new Point(34, 101);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(320, 29);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Sign in to your account";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsernameField
            // 
            lblUsernameField.Location = new Point(34, 157);
            lblUsernameField.Name = "lblUsernameField";
            lblUsernameField.Size = new Size(320, 27);
            lblUsernameField.TabIndex = 2;
            lblUsernameField.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(34, 187);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(319, 27);
            txtUsername.TabIndex = 3;
            // 
            // lblPasswordField
            // 
            lblPasswordField.Location = new Point(34, 261);
            lblPasswordField.Name = "lblPasswordField";
            lblPasswordField.Size = new Size(320, 27);
            lblPasswordField.TabIndex = 4;
            lblPasswordField.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(34, 291);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(319, 27);
            txtPassword.TabIndex = 5;
            // 
            // lblError
            // 
            lblError.Location = new Point(34, 357);
            lblError.Name = "lblError";
            lblError.Size = new Size(320, 48);
            lblError.TabIndex = 6;
            lblError.Visible = false;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(34, 421);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(320, 56);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Sign In";
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkRegister
            // 
            lnkRegister.Location = new Point(34, 493);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(320, 29);
            lnkRegister.TabIndex = 8;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Don't have a dog walker account? Create new account here.";
            lnkRegister.TextAlign = ContentAlignment.MiddleCenter;
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 685);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PawsTrack - Login";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}
