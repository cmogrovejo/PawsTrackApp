namespace PawsTrack.Presentation.Forms
{
    partial class ResetPasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel pnlSep;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle          = new System.Windows.Forms.Label();
            lblUserInfo       = new System.Windows.Forms.Label();
            pnlSep            = new System.Windows.Forms.Panel();
            lblNewPassword    = new System.Windows.Forms.Label();
            txtNewPassword    = new System.Windows.Forms.TextBox();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            lblError          = new System.Windows.Forms.Label();
            btnReset          = new System.Windows.Forms.Button();
            btnCancel         = new System.Windows.Forms.Button();

            SuspendLayout();

            // ── lblTitle ─────────────────────────────────────────────────────
            lblTitle.Location  = new System.Drawing.Point(24, 16);
            lblTitle.Size      = new System.Drawing.Size(400, 28);
            lblTitle.Text      = "Reset Password";

            // ── lblUserInfo ──────────────────────────────────────────────────
            lblUserInfo.Location = new System.Drawing.Point(24, 48);
            lblUserInfo.Size     = new System.Drawing.Size(400, 20);

            // ── pnlSep ───────────────────────────────────────────────────────
            pnlSep.Location = new System.Drawing.Point(0, 76);
            pnlSep.Size     = new System.Drawing.Size(460, 1);

            // ── lblNewPassword ───────────────────────────────────────────────
            lblNewPassword.Text     = "New Password";
            lblNewPassword.Location = new System.Drawing.Point(24, 96);
            lblNewPassword.Size     = new System.Drawing.Size(140, 22);

            // ── txtNewPassword ───────────────────────────────────────────────
            txtNewPassword.Location     = new System.Drawing.Point(176, 92);
            txtNewPassword.Size         = new System.Drawing.Size(258, 27);
            txtNewPassword.PasswordChar = '\u2022';
            txtNewPassword.TabIndex     = 0;

            // ── lblConfirmPassword ───────────────────────────────────────────
            lblConfirmPassword.Text     = "Confirm Password";
            lblConfirmPassword.Location = new System.Drawing.Point(24, 140);
            lblConfirmPassword.Size     = new System.Drawing.Size(140, 22);

            // ── txtConfirmPassword ───────────────────────────────────────────
            txtConfirmPassword.Location     = new System.Drawing.Point(176, 136);
            txtConfirmPassword.Size         = new System.Drawing.Size(258, 27);
            txtConfirmPassword.PasswordChar = '\u2022';
            txtConfirmPassword.TabIndex     = 1;

            // ── lblError ─────────────────────────────────────────────────────
            lblError.Location = new System.Drawing.Point(24, 180);
            lblError.Size     = new System.Drawing.Size(410, 40);
            lblError.Visible  = false;
            lblError.TabIndex = 2;

            // ── btnReset ─────────────────────────────────────────────────────
            btnReset.Text     = "Reset Password";
            btnReset.Location = new System.Drawing.Point(190, 236);
            btnReset.Size     = new System.Drawing.Size(130, 36);
            btnReset.Height   = 36;
            btnReset.TabIndex = 3;
            btnReset.Click   += new System.EventHandler(btnReset_Click);

            // ── btnCancel ────────────────────────────────────────────────────
            btnCancel.Text     = "Cancel";
            btnCancel.Location = new System.Drawing.Point(330, 236);
            btnCancel.Size     = new System.Drawing.Size(100, 36);
            btnCancel.Height   = 36;
            btnCancel.TabIndex = 4;
            btnCancel.Click   += new System.EventHandler(btnCancel_Click);

            // ── ResetPasswordForm ────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize          = new System.Drawing.Size(460, 300);
            FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            MinimizeBox         = false;
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            Text                = "Reset Password";
            Controls.Add(lblTitle);
            Controls.Add(lblUserInfo);
            Controls.Add(pnlSep);
            Controls.Add(lblNewPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblError);
            Controls.Add(btnReset);
            Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
