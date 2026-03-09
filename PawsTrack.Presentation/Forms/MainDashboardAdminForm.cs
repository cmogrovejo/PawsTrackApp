using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
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

            AppStyles.StylePrimaryButton(btnLogout);
            btnLogout.BackColor = Color.FromArgb(211, 47, 47);

            lblSearch.Font      = AppStyles.LabelFont;
            lblSearch.ForeColor = AppStyles.TextSecondary;

            txtSearch.Font = AppStyles.InputFont;

            AppStyles.StylePrimaryButton(btnSearch);
            btnSearch.Height = 32;

            pnlSearchBorder.BackColor = AppStyles.BorderColor;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var user = SessionContext.CurrentUser!;
            lblAppTitle.Text = "PawsTrack";
            lblUserInfo.Text = $"{user.FullName}  \u00B7  {user.Role}";
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await BuildWalkerResultsAsync(null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
            => _ = BuildWalkerResultsAsync(txtSearch.Text.Trim());

        private async Task BuildWalkerResultsAsync(string? search)
        {
            pnlWalkerResults.SuspendLayout();
            foreach (Control old in pnlWalkerResults.Controls.Cast<Control>().ToList())
                old.Dispose();
            pnlWalkerResults.Controls.Clear();

            IReadOnlyList<UserSummaryDto> walkers;
            await using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var svc = scope.ServiceProvider.GetRequiredService<IAuthService>();
                walkers = await svc.GetWalkersAsync(search);
            }

            if (walkers.Count == 0)
            {
                pnlWalkerResults.Controls.Add(new Label
                {
                    Text      = "No dog walkers found.",
                    Dock      = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font      = AppStyles.SubtitleFont,
                    ForeColor = AppStyles.TextSecondary
                });
            }
            else
            {
                int y = 8;
                foreach (var walker in walkers)
                {
                    var row = BuildWalkerRow(walker);
                    row.Location = new Point(2, y);
                    pnlWalkerResults.Controls.Add(row);
                    y += row.Height + 4;
                }
                pnlWalkerResults.AutoScrollMinSize = new Size(0, y);
            }

            pnlWalkerResults.ResumeLayout(true);
        }

        private Panel BuildWalkerRow(UserSummaryDto walker)
        {
            var capturedWalker = walker;

            var row = new Panel
            {
                Size = new Size(1000, 56),
                BackColor = Color.White,
                Location = new Point(40, 75),
            };

            // Left accent strip
            var accent = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(4, 56),
                BackColor = AppStyles.PrimaryColor
            };

            // Full name
            var lblName = new Label
            {
                Text      = walker.FullName,
                Location  = new Point(14, 8),
                Size      = new Size(300, 20),
                Font      = AppStyles.LabelAccentFont,
                ForeColor = AppStyles.TextPrimary
            };

            // Username
            var lblUsername = new Label
            {
                Text      = $"@{walker.Username}",
                Location  = new Point(14, 28),
                Size      = new Size(300, 18),
                Font      = AppStyles.SmallFont,
                ForeColor = AppStyles.TextSecondary
            };

            // Status badge
            var lblStatus = new Label
            {
                Text      = walker.IsActive ? "Active" : "Inactive",
                Location  = new Point(row.Width - 200, 18),
                Size      = new Size(60, 20),
                Font      = AppStyles.SmallFont,
                ForeColor = walker.IsActive ? AppStyles.SuccessColor : AppStyles.ErrorColor,
                TextAlign = ContentAlignment.MiddleRight
            };

            // Reset Password button
            var btnReset = new Button
            {
                Text      = "Reset Password",
                Location  = new Point(row.Width - 140, 10),
                Size      = new Size(130, 36),
                BackColor = AppStyles.AccentColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = AppStyles.LabelAccentFont,
                Cursor    = Cursors.Hand
            };
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Click += (_, _) =>
            {
                using var dlg = new ResetPasswordForm(_serviceProvider, capturedWalker);
                dlg.ShowDialog(this);
            };

            row.Controls.Add(accent);
            row.Controls.Add(lblName);
            row.Controls.Add(lblUsername);
            row.Controls.Add(lblStatus);
            row.Controls.Add(btnReset);

            return row;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionContext.Clear();
            Close();
        }
    }
}
