using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class MainDashboardForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainDashboardForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            pnlHeader.BackColor = AppStyles.PrimaryColor;

            lblAppTitle.Font      = AppStyles.ButtonFont;
            lblAppTitle.ForeColor = Color.White;

            lblUserInfo.Font      = AppStyles.SmallFont;
            lblUserInfo.ForeColor = Color.FromArgb(200, 230, 255);

            lblPlaceholder.Font      = AppStyles.SubtitleFont;
            lblPlaceholder.ForeColor = AppStyles.TextSecondary;

            AppStyles.StylePrimaryButton(btnLogout);
            btnLogout.BackColor = Color.FromArgb(211, 47, 47);

            AppStyles.StylePrimaryButton(btnNewIntake);
            btnNewIntake.BackColor = AppStyles.AccentColor;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var user = SessionContext.CurrentUser!;
            lblAppTitle.Text = "PawsTrack";
            lblUserInfo.Text = $"{user.FullName}  \u00B7  {user.Role}";
        }

        private void btnNewIntake_Click(object sender, EventArgs e)
        {
            Program.ServiceProvider.GetRequiredService<ClientIntakeForm>().ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionContext.Clear();
            Close();
        }
    }
}
