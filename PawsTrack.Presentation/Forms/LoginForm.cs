using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Domain.Enums;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public LoginForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            lblTitle.Font = AppStyles.TitleFont;
            lblTitle.ForeColor = AppStyles.PrimaryColor;

            lblSubtitle.Font = AppStyles.SubtitleFont;
            lblSubtitle.ForeColor = AppStyles.TextSecondary;

            lblUsernameField.Font = AppStyles.LabelFont;
            lblUsernameField.ForeColor = AppStyles.TextPrimary;

            lblPasswordField.Font = AppStyles.LabelFont;
            lblPasswordField.ForeColor = AppStyles.TextPrimary;

            lblError.Font = AppStyles.SmallFont;
            lblError.ForeColor = AppStyles.ErrorColor;

            AppStyles.StyleInput(txtUsername);
            AppStyles.StyleInput(txtPassword);
            AppStyles.StylePrimaryButton(btnLogin);
            lnkRegister.Font = AppStyles.SmallFont;

            txtPassword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnLogin_Click(s, e!); };
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            btnLogin.Enabled = false;
            btnLogin.Text = "Signing in...";

            LoginResult result;
            await using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
                result = await authService.LoginAsync(txtUsername.Text.Trim(), txtPassword.Text);
            }

            if (!result.Success)
            {
                lblError.Text = result.ErrorMessage;
                lblError.Visible = true;
                btnLogin.Enabled = true;
                btnLogin.Text = "Sign In";
                return;
            }

            SessionContext.SetUser(result.User!);

            Form dashboard = result.User!.Role == UserRole.Admin
                ? Program.ServiceProvider.GetRequiredService<MainDashboardAdminForm>()
                : Program.ServiceProvider.GetRequiredService<MainDashboardWalkerForm>();

            dashboard.FormClosed += (s, args) =>
            {
                SessionContext.Clear();
                ResetForm();
                Show();
            };
            dashboard.Show();
            Hide();
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.ServiceProvider.GetRequiredService<RegisterWalkerForm>().ShowDialog(this);
        }

        private void ResetForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            lblError.Visible = false;
            btnLogin.Enabled = true;
            btnLogin.Text = "Sign In";
        }
    }
}
