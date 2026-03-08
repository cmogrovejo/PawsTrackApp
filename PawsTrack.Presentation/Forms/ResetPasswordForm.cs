using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class ResetPasswordForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserSummaryDto _user;

        public ResetPasswordForm(IServiceProvider serviceProvider, UserSummaryDto user)
        {
            _serviceProvider = serviceProvider;
            _user = user;
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            lblTitle.Font      = AppStyles.SubtitleFont;
            lblTitle.ForeColor = AppStyles.TextPrimary;

            lblUserInfo.Font      = AppStyles.SmallFont;
            lblUserInfo.ForeColor = AppStyles.TextSecondary;

            pnlSep.BackColor = AppStyles.BorderColor;

            foreach (var lbl in new[] { lblNewPassword, lblConfirmPassword })
            {
                lbl.Font      = AppStyles.LabelFont;
                lbl.ForeColor = AppStyles.TextPrimary;
            }

            AppStyles.StyleInput(txtNewPassword);
            AppStyles.StyleInput(txtConfirmPassword);

            lblError.Font      = AppStyles.SmallFont;
            lblError.ForeColor = AppStyles.ErrorColor;

            AppStyles.StylePrimaryButton(btnReset);
            btnReset.BackColor = AppStyles.AccentColor;

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = AppStyles.TextPrimary;
            btnCancel.Font      = AppStyles.ButtonFont;
            btnCancel.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnCancel.FlatAppearance.BorderSize  = 1;
            btnCancel.Cursor = Cursors.Hand;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblTitle.Text    = "Reset Password";
            lblUserInfo.Text = $"{_user.FullName} (@{_user.Username})";
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ShowError("Password is required.");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Passwords do not match.");
                return;
            }

            btnReset.Enabled = false;
            btnReset.Text    = "Resetting...";

            try
            {
                await using var scope = _serviceProvider.CreateAsyncScope();
                var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
                await authService.ResetUserPasswordAsync(_user.Id, txtNewPassword.Text.Trim());

                MessageBox.Show(
                    "Password reset successfully.",
                    "PawsTrack",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
                btnReset.Enabled = true;
                btnReset.Text    = "Reset Password";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string message)
        {
            lblError.Text    = message;
            lblError.Visible = true;
        }
    }
}
