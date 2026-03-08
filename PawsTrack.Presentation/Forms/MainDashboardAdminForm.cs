using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class MainDashboardAdminForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainDashboardAdminForm(IServiceProvider serviceProvider)
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

            lblSectionActions.Font      = AppStyles.LabelFont;
            lblSectionActions.ForeColor = AppStyles.TextSecondary;

            lblPlaceholder.Font      = AppStyles.SubtitleFont;
            lblPlaceholder.ForeColor = AppStyles.TextSecondary;

            AppStyles.StylePrimaryButton(btnLogout);
            btnLogout.BackColor = Color.FromArgb(211, 47, 47);

            AppStyles.StylePrimaryButton(btnNewIntake);
            btnNewIntake.BackColor = AppStyles.AccentColor;

            AppStyles.StylePrimaryButton(btnRegisterWalker);
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
            var intake = Program.ServiceProvider.GetRequiredService<ClientIntakeUC>();
            using var dialog = new Form
            {
                Text            = "New Client & Dog Intake",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox     = false,
                MinimizeBox     = false,
                StartPosition   = FormStartPosition.CenterParent,
                AutoScaleMode   = AutoScaleMode.Font,
                ClientSize      = new Size(520, 648)
            };
            intake.Dock = DockStyle.Fill;
            intake.NavigateBack += (_, _) => dialog.Close();
            dialog.Controls.Add(intake);
            dialog.ShowDialog(this);
        }

        private void btnRegisterWalker_Click(object sender, EventArgs e)
        {
            Program.ServiceProvider.GetRequiredService<RegisterWalkerForm>().ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionContext.Clear();
            Close();
        }
    }
}
