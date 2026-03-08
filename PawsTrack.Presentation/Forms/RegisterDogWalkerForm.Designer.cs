namespace PawsTrack.Presentation.Forms
{
    partial class RegisterDogWalkerForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblError = new Label();
            btnRegister = new Button();
            btnCancel = new Button();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblFullName);
            pnlCard.Controls.Add(txtFullName);
            pnlCard.Controls.Add(lblUsername);
            pnlCard.Controls.Add(txtUsername);
            pnlCard.Controls.Add(lblPassword);
            pnlCard.Controls.Add(txtPassword);
            pnlCard.Controls.Add(lblConfirmPassword);
            pnlCard.Controls.Add(txtConfirmPassword);
            pnlCard.Controls.Add(lblError);
            pnlCard.Controls.Add(btnRegister);
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Location = new Point(46, 53);
            pnlCard.Margin = new Padding(3, 4, 3, 4);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(389, 720);
            pnlCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(23, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(343, 59);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register New Walker";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Location = new Point(23, 96);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(343, 48);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Create a dog walker account.";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFullName
            // 
            lblFullName.Location = new Point(34, 147);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(320, 27);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(34, 185);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(319, 27);
            txtFullName.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(34, 240);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(320, 27);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(34, 274);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(319, 27);
            txtUsername.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(34, 336);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(320, 27);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(34, 379);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(319, 27);
            txtPassword.TabIndex = 7;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Location = new Point(34, 434);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(320, 27);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(34, 471);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(319, 27);
            txtConfirmPassword.TabIndex = 9;
            // 
            // lblError
            // 
            lblError.Location = new Point(34, 510);
            lblError.Name = "lblError";
            lblError.Size = new Size(320, 53);
            lblError.TabIndex = 10;
            lblError.Visible = false;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(34, 574);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(320, 56);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(34, 646);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(320, 56);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // RegisterWalkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 827);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "RegisterWalkerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PawsTrack - Register Walker";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}
