using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class FirstRunSetupForm : Form
    {
        private readonly IAuthService _authService;

        public FirstRunSetupForm(IAuthService authService)
        {
            _authService = authService;
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
            AppStyles.StylePrimaryButton(btnCreate);
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("All fields are required.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Passwords do not match.");
                return;
            }

            btnCreate.Enabled = false;
            btnCreate.Text    = "Creating account...";

            try
            {
                await _authService.CreateInitialAdminAsync(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtFullName.Text.Trim());

                MessageBox.Show(
                    "Admin account created successfully. Please log in.",
                    "PawsTrack",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                var login = Program.ServiceProvider.GetRequiredService<LoginForm>();

                // When LoginForm eventually closes (user exits), this form closes too,
                // which ends Application.Run and exits the process cleanly.
                login.FormClosed += (s, args) => Close();

                login.Show();
                Hide();
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
                btnCreate.Enabled = true;
                btnCreate.Text    = "Create Account";
            }
            catch (Exception ex)
            {
                ShowError($"Unexpected error: {ex.Message}");
                btnCreate.Enabled = true;
                btnCreate.Text    = "Create Account";
            }
        }

        private void ShowError(string message)
        {
            lblError.Text    = message;
            lblError.Visible = true;
        }
    }
}
