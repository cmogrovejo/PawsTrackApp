using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class MainDashboardForm : Form
    {
        public MainDashboardForm()
        {
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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var user = SessionContext.CurrentUser!;
            lblAppTitle.Text = "PawsTrack";
            lblUserInfo.Text = $"{user.FullName}  \u00B7  {user.Role}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionContext.Clear();
            Close();
        }
    }
}
