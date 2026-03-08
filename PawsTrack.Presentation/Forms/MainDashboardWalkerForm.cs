using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class MainDashboardWalkerForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainDashboardWalkerForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            // Header
            pnlHeader.BackColor   = AppStyles.PrimaryColor;
            lblAppTitle.Font      = AppStyles.ButtonFont;
            lblAppTitle.ForeColor = Color.White;
            lblUserInfo.Font      = AppStyles.SmallFont;
            lblUserInfo.ForeColor = Color.FromArgb(200, 230, 255);
            AppStyles.StylePrimaryButton(btnLogout);
            btnLogout.BackColor = Color.FromArgb(211, 47, 47);

            // Nav borders
            pnlNavBorder.BackColor     = AppStyles.BorderColor;
            pnlSidebarBorder.BackColor = AppStyles.BorderColor;

            // Tabs — Schedule active by default
            StyleTab(btnTabSchedule, active: true);
            StyleTab(btnTabBilling,  active: false);
            StyleTab(btnTabReports,  active: false);

            // Sidebar action buttons
            foreach (var btn in new[] { btnNewService, btnNewClient })
            {
                btn.FlatStyle                  = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = AppStyles.BorderColor;
                btn.FlatAppearance.BorderSize  = 1;
                btn.BackColor                  = Color.White;
                btn.ForeColor                  = AppStyles.TextPrimary;
                btn.Font                       = new Font("Segoe UI Emoji", 8.5f);
                btn.Cursor                     = Cursors.Hand;
                btn.TextAlign                  = ContentAlignment.MiddleCenter;
            }

            // Schedule header
            pnlScheduleHeaderBorder.BackColor = AppStyles.BorderColor;
            lblScheduleTitle.Font             = AppStyles.SubtitleFont;
            lblScheduleTitle.ForeColor        = AppStyles.TextPrimary;
            dtpScheduleDate.Font              = AppStyles.LabelFont;

            // Placeholder labels
            foreach (var lbl in new[] { lblBillingPlaceholder, lblReportsPlaceholder })
            {
                lbl.Font      = AppStyles.SubtitleFont;
                lbl.ForeColor = AppStyles.TextSecondary;
            }
        }

        private static void StyleTab(Button tab, bool active)
        {
            tab.FlatStyle             = FlatStyle.Flat;
            tab.FlatAppearance.BorderSize = 0;
            tab.Font                  = active ? AppStyles.LabelAccentFont : AppStyles.LabelFont;
            tab.Cursor                = Cursors.Hand;
            tab.BackColor             = active ? AppStyles.AccentColor : Color.White;
            tab.ForeColor             = active ? Color.White : AppStyles.TextPrimary;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var user = SessionContext.CurrentUser!;
            lblAppTitle.Text    = "PawsTrack";
            lblUserInfo.Text    = $"{user.FullName}  \u00B7  {user.Role}";
            dtpScheduleDate.Value = DateTime.Today;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BuildSchedule(dtpScheduleDate.Value);
        }

        // ── Schedule builder ─────────────────────────────────────────────────

        private void BuildSchedule(DateTime date)
        {
            pnlTimeSlots.SuspendLayout();

            foreach (Control old in pnlTimeSlots.Controls.Cast<Control>().ToList())
                old.Dispose();
            pnlTimeSlots.Controls.Clear();

            const int rowHeight  = 62;
            const int startHour  = 8;
            const int endHour    = 17;
            const int numHours   = endHour - startHour + 1;
            const int timeLabelW = 72;

            for (int i = 0; i < numHours; i++)
            {
                int hour = startHour + i;
                int y    = i * rowHeight;

                var pnlRow = new Panel
                {
                    Location  = new Point(0, y),
                    Size      = new Size(pnlTimeSlots.ClientSize.Width, rowHeight),
                    BackColor = Color.White,
                    Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                var lblTime = new Label
                {
                    Text      = $"{hour}:00",
                    Location  = new Point(0, 0),
                    Size      = new Size(timeLabelW, rowHeight),
                    TextAlign = ContentAlignment.TopRight,
                    Padding   = new Padding(0, 10, 10, 0),
                    Font      = AppStyles.SmallFont,
                    ForeColor = AppStyles.TextSecondary
                };

                var pnlVSep = new Panel
                {
                    Location  = new Point(timeLabelW, 0),
                    Size      = new Size(1, rowHeight),
                    BackColor = AppStyles.BorderColor
                };

                var pnlSlot = new Panel
                {
                    Location  = new Point(timeLabelW + 1, 4),
                    Size      = new Size(pnlTimeSlots.ClientSize.Width - timeLabelW - 9, rowHeight - 4),
                    BackColor = Color.White,
                    Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                var pnlHSep = new Panel
                {
                    Location  = new Point(0, rowHeight - 1),
                    Size      = new Size(pnlTimeSlots.ClientSize.Width, 1),
                    BackColor = AppStyles.BorderColor,
                    Anchor    = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
                };

                pnlRow.Controls.Add(pnlSlot);
                pnlRow.Controls.Add(pnlVSep);
                pnlRow.Controls.Add(lblTime);
                pnlRow.Controls.Add(pnlHSep);
                pnlTimeSlots.Controls.Add(pnlRow);
            }

            pnlTimeSlots.AutoScrollMinSize = new Size(0, numHours * rowHeight);
            pnlTimeSlots.ResumeLayout(true);
        }

        // ── Tab navigation ────────────────────────────────────────────────────

        private void SetActiveTab(Button activeTab)
        {
            StyleTab(btnTabSchedule, active: activeTab == btnTabSchedule);
            StyleTab(btnTabBilling,  active: activeTab == btnTabBilling);
            StyleTab(btnTabReports,  active: activeTab == btnTabReports);
            pnlScheduleView.Visible = (activeTab == btnTabSchedule);
            pnlBillingView.Visible  = (activeTab == btnTabBilling);
            pnlReportsView.Visible  = (activeTab == btnTabReports);
            pnlIntakeView.Visible   = false;
        }

        private void btnTabSchedule_Click(object sender, EventArgs e) => SetActiveTab(btnTabSchedule);
        private void btnTabBilling_Click(object sender, EventArgs e)  => SetActiveTab(btnTabBilling);
        private void btnTabReports_Click(object sender, EventArgs e)  => SetActiveTab(btnTabReports);

        // ── Date change ───────────────────────────────────────────────────────

        private void dtpScheduleDate_ValueChanged(object sender, EventArgs e)
            => BuildSchedule(dtpScheduleDate.Value);

        // ── Sidebar actions ───────────────────────────────────────────────────

        private void btnNewService_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Service scheduling \u2014 coming soon.",
                "PawsTrack",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnNewDog_Click(object sender, EventArgs e) => OpenIntakeView();

        private void btnNewOwner_Click(object sender, EventArgs e) => OpenIntakeView();

        private void OpenIntakeView()
        {
            foreach (Control old in pnlIntakeView.Controls.Cast<Control>().ToList())
                old.Dispose();
            pnlIntakeView.Controls.Clear();

            var intake = Program.ServiceProvider.GetRequiredService<ClientIntakeUC>();
            intake.Dock = DockStyle.Fill;
            intake.NavigateBack += (_, _) => SetActiveTab(btnTabSchedule);
            pnlIntakeView.Controls.Add(intake);

            StyleTab(btnTabSchedule, active: false);
            StyleTab(btnTabBilling,  active: false);
            StyleTab(btnTabReports,  active: false);
            pnlScheduleView.Visible = false;
            pnlBillingView.Visible  = false;
            pnlReportsView.Visible  = false;
            pnlIntakeView.Visible   = true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionContext.Clear();
            Close();
        }
    }
}
