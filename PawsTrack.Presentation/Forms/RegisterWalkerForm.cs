using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class RegisterWalkerForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public RegisterWalkerForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            lblTitle.Font      = AppStyles.TitleFont;
            lblTitle.ForeColor = AppStyles.PrimaryColor;

            lblSubtitle.Font      = AppStyles.SubtitleFont;
            lblSubtitle.ForeColor = AppStyles.TextSecondary;

            foreach (var lbl in new[] { lblFullName, lblUsername, lblPassword, lblConfirmPassword })
            {
                lbl.Font      = AppStyles.LabelFont;
                lbl.ForeColor = AppStyles.TextPrimary;
            }

            lblError.Font      = AppStyles.SmallFont;
            lblError.ForeColor = AppStyles.ErrorColor;

            AppStyles.StyleInput(txtFullName);
            AppStyles.StyleInput(txtUsername);
            AppStyles.StyleInput(txtPassword);
            AppStyles.StyleInput(txtConfirmPassword);
            AppStyles.StylePrimaryButton(btnRegister);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ShowError("All fields are required.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Passwords do not match.");
                return;
            }

            btnRegister.Enabled = false;
            btnRegister.Text    = "Registering...";

            try
            {
                await using var scope = _serviceProvider.CreateAsyncScope();
                var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
                await authService.CreateWalkerAsync(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtFullName.Text.Trim());

                MessageBox.Show(
                    "Walker account created. They can now log in.",
                    "PawsTrack",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
                btnRegister.Enabled = true;
                btnRegister.Text    = "Register";
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
