namespace PawsTrack.Presentation.Forms
{
    partial class FirstRunSetupForm
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
        private System.Windows.Forms.Button btnCreate;

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
            lblFullName      = new System.Windows.Forms.Label();
            txtFullName      = new System.Windows.Forms.TextBox();
            lblUsername      = new System.Windows.Forms.Label();
            txtUsername      = new System.Windows.Forms.TextBox();
            lblPassword      = new System.Windows.Forms.Label();
            txtPassword      = new System.Windows.Forms.TextBox();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            lblError         = new System.Windows.Forms.Label();
            btnCreate        = new System.Windows.Forms.Button();

            pnlCard.SuspendLayout();
            SuspendLayout();

            // ── pnlCard ──────────────────────────────────────────────────────
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
            pnlCard.Controls.Add(btnCreate);
            pnlCard.Location  = new System.Drawing.Point(40, 40);
            pnlCard.Size      = new System.Drawing.Size(340, 540);
            pnlCard.BackColor = System.Drawing.Color.White;

            // ── lblTitle ─────────────────────────────────────────────────────
            lblTitle.Text      = "Welcome to PawsTrack";
            lblTitle.Location  = new System.Drawing.Point(20, 24);
            lblTitle.Size      = new System.Drawing.Size(300, 44);
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblSubtitle ──────────────────────────────────────────────────
            lblSubtitle.Text      = "Create your admin account to get started.";
            lblSubtitle.Location  = new System.Drawing.Point(20, 72);
            lblSubtitle.Size      = new System.Drawing.Size(300, 36);
            lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblFullName ──────────────────────────────────────────────────
            lblFullName.Text     = "Full Name";
            lblFullName.Location = new System.Drawing.Point(30, 122);
            lblFullName.Size     = new System.Drawing.Size(280, 20);

            // ── txtFullName ──────────────────────────────────────────────────
            txtFullName.Location = new System.Drawing.Point(30, 144);
            txtFullName.Size     = new System.Drawing.Size(280, 38);

            // ── lblUsername ──────────────────────────────────────────────────
            lblUsername.Text     = "Username";
            lblUsername.Location = new System.Drawing.Point(30, 198);
            lblUsername.Size     = new System.Drawing.Size(280, 20);

            // ── txtUsername ──────────────────────────────────────────────────
            txtUsername.Location = new System.Drawing.Point(30, 220);
            txtUsername.Size     = new System.Drawing.Size(280, 38);

            // ── lblPassword ──────────────────────────────────────────────────
            lblPassword.Text     = "Password";
            lblPassword.Location = new System.Drawing.Point(30, 274);
            lblPassword.Size     = new System.Drawing.Size(280, 20);

            // ── txtPassword ──────────────────────────────────────────────────
            txtPassword.Location     = new System.Drawing.Point(30, 296);
            txtPassword.Size         = new System.Drawing.Size(280, 38);
            txtPassword.PasswordChar = '*';

            // ── lblConfirmPassword ───────────────────────────────────────────
            lblConfirmPassword.Text     = "Confirm Password";
            lblConfirmPassword.Location = new System.Drawing.Point(30, 350);
            lblConfirmPassword.Size     = new System.Drawing.Size(280, 20);

            // ── txtConfirmPassword ───────────────────────────────────────────
            txtConfirmPassword.Location     = new System.Drawing.Point(30, 372);
            txtConfirmPassword.Size         = new System.Drawing.Size(280, 38);
            txtConfirmPassword.PasswordChar = '*';

            // ── lblError ─────────────────────────────────────────────────────
            lblError.Location = new System.Drawing.Point(30, 422);
            lblError.Size     = new System.Drawing.Size(280, 40);
            lblError.Visible  = false;

            // ── btnCreate ────────────────────────────────────────────────────
            btnCreate.Text     = "Create Account";
            btnCreate.Location = new System.Drawing.Point(30, 470);
            btnCreate.Size     = new System.Drawing.Size(280, 42);
            btnCreate.Click   += new System.EventHandler(btnCreate_Click);

            // ── FirstRunSetupForm ────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(420, 620);
            FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox         = false;
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text                = "PawsTrack - First Time Setup";
            Controls.Add(pnlCard);

            pnlCard.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
