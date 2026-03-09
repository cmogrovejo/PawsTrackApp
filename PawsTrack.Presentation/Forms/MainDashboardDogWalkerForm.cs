using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;
using PawsTrack.Presentation.UserControls;

namespace PawsTrack.Presentation.Forms
{
    public partial class MainDashboardDogWalkerForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private IReadOnlyList<BillReportRowDto> _reportResults = [];

        public MainDashboardDogWalkerForm(IServiceProvider serviceProvider)
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

            // Billing controls
            lblBillingTitle.Font             = AppStyles.SubtitleFont;
            lblBillingTitle.ForeColor        = AppStyles.TextPrimary;
            pnlBillingHeaderBorder.BackColor = AppStyles.BorderColor;
            pnlBillingSearchBorder.BackColor = AppStyles.BorderColor;
            lblBillingClient.Font            = AppStyles.LabelFont;
            txtBillingClient.Font            = AppStyles.InputFont;
            chkBillingDate.Font              = AppStyles.LabelFont;
            dtpBillingDate.Font              = AppStyles.LabelFont;
            AppStyles.StylePrimaryButton(btnBillingSearch);
            btnBillingSearch.Height          = 32;

            // Reports controls
            lblReportsTitle.Font             = AppStyles.SubtitleFont;
            lblReportsTitle.ForeColor        = AppStyles.TextPrimary;
            pnlReportsHeaderBorder.BackColor = AppStyles.BorderColor;
            pnlReportsSearchBorder.BackColor = AppStyles.BorderColor;
            lblReportClient.Font = lblReportFrom.Font = lblReportTo.Font = AppStyles.LabelFont;
            txtReportClient.Font  = AppStyles.InputFont;
            dtpReportFrom.Font = dtpReportTo.Font = AppStyles.LabelFont;
            AppStyles.StylePrimaryButton(btnReportSearch);
            btnReportSearch.Height = 32;
            btnGeneratePdf.FlatStyle = FlatStyle.Flat;
            btnGeneratePdf.FlatAppearance.BorderSize = 1;
            btnGeneratePdf.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnGeneratePdf.BackColor = AppStyles.BackColor;
            btnGeneratePdf.ForeColor = AppStyles.TextSecondary;
            btnGeneratePdf.Font      = AppStyles.LabelFont;
            btnGeneratePdf.Height    = 32;
            btnGeneratePdf.Cursor    = Cursors.Hand;
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

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await BuildScheduleAsync(dtpScheduleDate.Value);
        }

        // ── Schedule builder ─────────────────────────────────────────────────

        private async Task BuildScheduleAsync(DateTime date)
        {
            pnlTimeSlots.SuspendLayout();

            foreach (Control old in pnlTimeSlots.Controls.Cast<Control>().ToList())
                old.Dispose();
            pnlTimeSlots.Controls.Clear();

            IReadOnlyList<Application.DTOs.WalkServiceCreatedDto> services;
            await using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var svc = scope.ServiceProvider.GetRequiredService<IWalkScheduleService>();
                services = await svc.GetByDateAsync(date, SessionContext.CurrentUser!.Id);
            }

            const int minRowHeight = 62;
            const int cardHeight   = 50;
            const int cardGap      = 2;
            const int slotPadTop   = 4;
            const int startHour    = 7;
            const int endHour      = 23;
            const int numHours     = endHour - startHour + 1;
            const int timeLabelW   = 72;

            int cumulativeY = 0;

            for (int i = 0; i < numHours; i++)
            {
                int hour      = startHour + i;
                var slotStart = date.Date.AddHours(hour);
                var slotEnd   = slotStart.AddHours(1);

                // Services that overlap this hour slot
                var overlapping = services
                    .Where(s => s.StartTime < slotEnd && s.EndTime > slotStart)
                    .ToList();

                // Grow row to fit all cards; minimum is the standard row height
                int contentH = overlapping.Count * (cardHeight + cardGap);
                int rowH     = Math.Max(minRowHeight, contentH + slotPadTop + cardGap);

                var pnlRow = new Panel
                {
                    Location  = new Point(0, cumulativeY),
                    Size      = new Size(pnlTimeSlots.ClientSize.Width, rowH),
                    BackColor = Color.White,
                    Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                var lblTime = new Label
                {
                    Text      = $"{hour}:00",
                    Location  = new Point(0, 0),
                    Size      = new Size(timeLabelW, rowH),
                    TextAlign = ContentAlignment.TopRight,
                    Padding   = new Padding(0, 10, 10, 0),
                    Font      = AppStyles.SmallFont,
                    ForeColor = AppStyles.TextSecondary
                };

                var pnlVSep = new Panel
                {
                    Location  = new Point(timeLabelW, 0),
                    Size      = new Size(1, rowH),
                    BackColor = AppStyles.BorderColor
                };

                int slotW = pnlTimeSlots.ClientSize.Width - timeLabelW - 9;
                var pnlSlot = new Panel
                {
                    Location  = new Point(timeLabelW + 1, slotPadTop),
                    Size      = new Size(slotW, rowH - slotPadTop),
                    BackColor = Color.White,
                    Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                int cardY = cardGap;
                foreach (var ws in overlapping)
                {
                    bool isFirstSlot = ws.StartTime >= slotStart && ws.StartTime < slotEnd;
                    var capturedWs   = ws;
                    var capturedDate = date;

                    var card = BuildServiceCard(
                        capturedWs, slotW, isFirstSlot,
                        onView: () =>
                        {
                            using var dlg = new ViewServiceForm(capturedWs);
                            dlg.ShowDialog(this);
                        },
                        onEdit: async () =>
                        {
                            using var dlg = new EditServiceForm(_serviceProvider, capturedWs);
                            if (dlg.ShowDialog(this) == DialogResult.OK)
                                await BuildScheduleAsync(capturedDate);
                        },
                        onDelete: async () =>
                        {
                            var confirm = MessageBox.Show(
                                $"Delete the walk service for \"{capturedWs.ClientName}\" \u2014 {capturedWs.DogName}?\n" +
                                "This action cannot be undone.",
                                "Confirm Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);

                            if (confirm != DialogResult.Yes) return;

                            await using var scope = _serviceProvider.CreateAsyncScope();
                            var svc = scope.ServiceProvider.GetRequiredService<IWalkScheduleService>();
                            await svc.DeleteAsync(capturedWs.Id);
                            await BuildScheduleAsync(capturedDate);
                        });

                    card.Location = new Point(2, cardY);
                    pnlSlot.Controls.Add(card);
                    cardY += cardHeight + cardGap;
                }

                var pnlHSep = new Panel
                {
                    Location  = new Point(0, rowH - 1),
                    Size      = new Size(pnlTimeSlots.ClientSize.Width, 1),
                    BackColor = AppStyles.BorderColor,
                    Anchor    = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
                };

                pnlRow.Controls.Add(pnlSlot);
                pnlRow.Controls.Add(pnlVSep);
                pnlRow.Controls.Add(lblTime);
                pnlRow.Controls.Add(pnlHSep);
                pnlTimeSlots.Controls.Add(pnlRow);

                cumulativeY += rowH;
            }

            pnlTimeSlots.AutoScrollMinSize = new Size(0, cumulativeY);
            pnlTimeSlots.ResumeLayout(true);
        }

        private static Panel BuildServiceCard(
            Application.DTOs.WalkServiceCreatedDto ws,
            int        slotWidth,
            bool       isFirstSlot,
            Action     onView,
            Func<Task> onEdit,
            Func<Task> onDelete)
        {
            const int btnW = 65;
            const int btnH = 40;
            const int btnGap = 5;

            var (accentColor, bgColor) = ws.Status switch
            {
                "Created"    => (AppStyles.AccentColor,        Color.FromArgb(232, 240, 254)),
                "InProgress" => (Color.FromArgb(46,  125, 50), Color.FromArgb(232, 245, 233)),
                "Completed"  => (Color.FromArgb(97,  97,  97), Color.FromArgb(245, 245, 245)),
                _            => (AppStyles.BorderColor,        Color.FromArgb(250, 250, 250))
            };

            var card = new Panel
            {
                //Size      = new Size(slotWidth - 6, 50),
                Size = new Size(1050, 50),
                BackColor = bgColor
            };

            card.BorderStyle = BorderStyle.FixedSingle;

            var accent = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(4, card.Height),
                BackColor = accentColor
            };

            // Text area — narrowed to leave room for the button column
            int textW = card.Width - 230;

            string timeText = isFirstSlot
                ? $"{ws.StartTime:HH:mm} \u2192 {ws.EndTime:HH:mm}"
                : $"\u2195 cont. until {ws.EndTime:HH:mm}";

            var lblOwner = new Label
            {
                Text         = $"{ws.ClientName}  \u00B7  {ws.DogName}",
                Location     = new Point(10, 6),
                Size         = new Size(textW, 18),
                Font         = AppStyles.LabelAccentFont,
                ForeColor    = AppStyles.TextPrimary,
                AutoEllipsis = true
            };

            var lblDetails = new Label
            {
                Text         = $"{timeText}   [{ws.Status}]",
                Location     = new Point(10, 26),
                Size         = new Size(textW, 16),
                Font         = AppStyles.SmallFont,
                ForeColor    = AppStyles.TextSecondary,
                AutoEllipsis = true
            };

            // Action buttons — stacked horizontally on the right
            int btnY = 5;
            int btnX = textW + 20;
            bool canEdit = ws.Status == "Created";

            Button MakeBtn(string text, int x, bool enabled, Color backColor)
            {
                var b = new Button
                {
                    Text      = text,
                    Location  = new Point(x, btnY),
                    Size      = new Size(btnW, btnH),
                    Enabled   = enabled,
                    FlatStyle = FlatStyle.Flat,
                    Font      = new Font("Segoe UI", 7f, FontStyle.Regular),
                    BackColor = enabled ? backColor : AppStyles.BackColor,
                    ForeColor = enabled ? Color.White : AppStyles.TextSecondary,
                    Cursor    = enabled ? Cursors.Hand : Cursors.Default
                };
                b.FlatAppearance.BorderSize = 0;
                return b;
            }

            var btnView   = MakeBtn("View"  , btnX                      ,    true, AppStyles.PrimaryColor);
            var btnEdit   = MakeBtn("Edit"  , btnX + btnW + btnGap      , canEdit, AppStyles.EditColor);
            var btnDelete = MakeBtn("Delete", btnX + (btnW + btnGap) * 2, canEdit, AppStyles.ErrorColor);

            btnView.Click   += (_, _) => onView();
            btnEdit.Click   += async (_, _) => await onEdit();
            btnDelete.Click += async (_, _) => await onDelete();

            card.Controls.Add(accent);
            card.Controls.Add(lblOwner);
            card.Controls.Add(lblDetails);
            card.Controls.Add(btnView);
            card.Controls.Add(btnEdit);
            card.Controls.Add(btnDelete);
            return card;
        }

        // ── Billing ───────────────────────────────────────────────────────────

        private void chkBillingDate_CheckedChanged(object sender, EventArgs e)
            => dtpBillingDate.Enabled = chkBillingDate.Checked;

        private async void btnBillingSearch_Click(object sender, EventArgs e)
            => await BuildBillingResultsAsync();

        private async Task BuildBillingResultsAsync()
        {
            pnlBillingResults.SuspendLayout();

            foreach (Control old in pnlBillingResults.Controls.Cast<Control>().ToList())
                old.Dispose();
            pnlBillingResults.Controls.Clear();

            IReadOnlyList<BillableServiceDto> services;
            await using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var svc = scope.ServiceProvider.GetRequiredService<IBillingService>();
                var dateFilter = chkBillingDate.Checked ? dtpBillingDate.Value : (DateTime?)null;
                services = await svc.SearchServicesAsync(txtBillingClient.Text.Trim(), dateFilter, SessionContext.CurrentUser!.Id);
            }

            if (services.Count == 0)
            {
                var lbl = new Label
                {
                    Text      = "No completed services found.",
                    Dock      = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font      = AppStyles.SubtitleFont,
                    ForeColor = AppStyles.TextSecondary
                };
                pnlBillingResults.Controls.Add(lbl);
            }
            else
            {
                int y = 8;
                foreach (var dto in services)
                {
                    var row = BuildBillingRow(dto);
                    row.Location = new Point(2, y);
                    pnlBillingResults.Controls.Add(row);
                    y += row.Height + 4;
                }
                pnlBillingResults.AutoScrollMinSize = new Size(0, y);
            }

            pnlBillingResults.ResumeLayout(true);
        }

        private Panel BuildBillingRow(BillableServiceDto dto)
        {
            var row = new Panel
            {
                Size      = new Size(pnlBillingResults.ClientSize.Width - 4, 52),
                BackColor = Color.White
            };
            row.BorderStyle = BorderStyle.FixedSingle;

            var accent = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(4, row.Height),
                BackColor = AppStyles.PrimaryColor
            };

            int textW = row.Width - 200;

            var lblOwner = new Label
            {
                Text         = $"{dto.ClientName}  \u00B7  {dto.DogName}",
                Location     = new Point(12, 6),
                Size         = new Size(textW, 18),
                Font         = AppStyles.LabelAccentFont,
                ForeColor    = AppStyles.TextPrimary,
                AutoEllipsis = true
            };

            var lblDetails = new Label
            {
                Text         = $"{dto.StartTime:ddd dd/MM/yyyy}   {dto.StartTime:HH:mm}\u2192{dto.EndTime:HH:mm}   {dto.DurationHours:F1} hrs",
                Location     = new Point(12, 26),
                Size         = new Size(textW, 16),
                Font         = AppStyles.SmallFont,
                ForeColor    = AppStyles.TextSecondary,
                AutoEllipsis = true
            };

            var capturedDto = dto;
            var btnBill = new Button
            {
                Text      = "Bill",
                Size      = new Size(75, 36),
                Location  = new Point(row.Width - 90, 8),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                BackColor = AppStyles.AccentColor,
                ForeColor = Color.White,
                Cursor    = Cursors.Hand
            };
            btnBill.FlatAppearance.BorderSize = 0;
            btnBill.Click += async (_, _) =>
            {
                using var dlg = new CreateBillForm(_serviceProvider, capturedDto);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    await BuildBillingResultsAsync();
            };

            row.Controls.Add(accent);
            row.Controls.Add(lblOwner);
            row.Controls.Add(lblDetails);
            row.Controls.Add(btnBill);
            return row;
        }

        // ── Reports ───────────────────────────────────────────────────────────

        private async void btnReportSearch_Click(object sender, EventArgs e)
            => await BuildReportsResultsAsync();

        private async Task BuildReportsResultsAsync()
        {
            if (dtpReportFrom.Value.Date > dtpReportTo.Value.Date)
            {
                MessageBox.Show("'From' date must be on or before 'To' date.",
                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlReportsResults.SuspendLayout();
            foreach (Control old in pnlReportsResults.Controls.Cast<Control>().ToList()) old.Dispose();
            pnlReportsResults.Controls.Clear();

            await using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var svc = scope.ServiceProvider.GetRequiredService<IBillingService>();
                _reportResults = await svc.GetReportAsync(
                    txtReportClient.Text.Trim(),
                    dtpReportFrom.Value.Date,
                    dtpReportTo.Value.Date,
                    SessionContext.CurrentUser!.Id);
            }

            bool hasData = _reportResults.Count > 0;
            btnGeneratePdf.Enabled   = hasData;
            btnGeneratePdf.BackColor = hasData ? AppStyles.AccentColor : AppStyles.BackColor;
            btnGeneratePdf.ForeColor = hasData ? Color.White : AppStyles.TextSecondary;

            if (!hasData)
            {
                pnlReportsResults.Controls.Add(new Label
                {
                    Text = "No bills found for the selected period.",
                    Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter,
                    Font = AppStyles.SubtitleFont, ForeColor = AppStyles.TextSecondary
                });
            }
            else
            {
                const int maxRows = 200;
                var displayRows = _reportResults.Count > maxRows
                    ? _reportResults.Take(maxRows).ToList()
                    : _reportResults;

                int y = 8;
                foreach (var row in displayRows)
                {
                    var card = BuildReportRow(row);
                    card.Location = new Point(2, y);
                    pnlReportsResults.Controls.Add(card);
                    y += card.Height + 4;
                }

                if (_reportResults.Count > maxRows)
                {
                    var note = new Label
                    {
                        Text = $"Showing first {maxRows} of {_reportResults.Count} results. Export to PDF for full data.",
                        Location = new Point(2, y),
                        AutoSize = true,
                        Font = AppStyles.SmallFont,
                        ForeColor = AppStyles.TextSecondary
                    };
                    pnlReportsResults.Controls.Add(note);
                    y += 20;
                }

                var totalRow = BuildReportGrandTotal(_reportResults.Sum(r => r.TotalAmount));
                totalRow.Location = new Point(2, y);
                pnlReportsResults.Controls.Add(totalRow);
                pnlReportsResults.AutoScrollMinSize = new Size(0, y + totalRow.Height + 4);
            }

            pnlReportsResults.ResumeLayout(true);
        }

        private Panel BuildReportRow(BillReportRowDto row)
        {
            var card = new Panel
            {
                Size      = new Size(pnlReportsResults.ClientSize.Width - 4, 64),
                BackColor = Color.White
            };
            card.BorderStyle = BorderStyle.FixedSingle;

            var accent = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(4, card.Height),
                BackColor = AppStyles.SuccessColor
            };

            int textW = card.Width - 200;

            var lblOwner = new Label
            {
                Text         = $"{row.ClientName}  \u00B7  {row.DogName}",
                Location     = new Point(12, 6),
                Size         = new Size(textW, 18),
                Font         = AppStyles.LabelAccentFont,
                ForeColor    = AppStyles.TextPrimary,
                AutoEllipsis = true
            };

            var lblDetails = new Label
            {
                Text         = $"{row.WalkDate:ddd dd/MM/yyyy}  {row.StartTime:HH:mm}\u2192{row.EndTime:HH:mm}  {row.DurationHours:F1} hrs  |  Rate: {row.RatePerHour:C}  Disc: {row.Discount:C}",
                Location     = new Point(12, 26),
                Size         = new Size(textW, 16),
                Font         = AppStyles.SmallFont,
                ForeColor    = AppStyles.TextSecondary,
                AutoEllipsis = true
            };

            var lblBilledAt = new Label
            {
                Text         = $"Billed: {row.BilledAt:dd/MM/yyyy}",
                Location     = new Point(12, 44),
                Size         = new Size(textW, 16),
                Font         = AppStyles.SmallFont,
                ForeColor    = AppStyles.TextSecondary,
                AutoEllipsis = true
            };

            var lblTotal = new Label
            {
                Text      = row.TotalAmount.ToString("C"),
                Location  = new Point(card.Width - 130, 18),
                Size      = new Size(120, 28),
                Font      = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = AppStyles.AccentColor,
                TextAlign = ContentAlignment.MiddleRight
            };

            card.Controls.Add(accent);
            card.Controls.Add(lblOwner);
            card.Controls.Add(lblDetails);
            card.Controls.Add(lblBilledAt);
            card.Controls.Add(lblTotal);
            return card;
        }

        private Panel BuildReportGrandTotal(decimal grandTotal)
        {
            var panel = new Panel
            {
                Size      = new Size(pnlReportsResults.ClientSize.Width - 4, 48),
                BackColor = Color.FromArgb(232, 240, 254)
            };
            panel.BorderStyle = BorderStyle.FixedSingle;

            var lblLabel = new Label
            {
                Text      = "Grand Total",
                Location  = new Point(12, 0),
                Size      = new Size(200, 48),
                Font      = AppStyles.LabelAccentFont,
                ForeColor = AppStyles.TextPrimary,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblAmount = new Label
            {
                Text      = grandTotal.ToString("C"),
                Location  = new Point(panel.Width - 160, 0),
                Size      = new Size(150, 48),
                Font      = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = AppStyles.AccentColor,
                TextAlign = ContentAlignment.MiddleRight
            };

            panel.Controls.Add(lblLabel);
            panel.Controls.Add(lblAmount);
            return panel;
        }

        private void btnGeneratePdf_Click(object sender, EventArgs e)
        {
            if (_reportResults.Count == 0) return;
            using var dlg = new SaveFileDialog
            {
                Title = "Save Billing Report PDF", Filter = "PDF Files|*.pdf",
                DefaultExt = "pdf",
                FileName = $"BillingReport_{dtpReportFrom.Value:yyyyMMdd}_{dtpReportTo.Value:yyyyMMdd}.pdf",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var clientFilter = txtReportClient.Text.Trim();
                BillingReportPdfGenerator.Generate(
                    dlg.FileName, _reportResults,
                    string.IsNullOrWhiteSpace(clientFilter) ? null : clientFilter,
                    dtpReportFrom.Value.Date, dtpReportTo.Value.Date);

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo(dlg.FileName) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate PDF.\n\n{ex.Message}",
                    "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (pnlBillingView.Visible)
            {
                btnNewService.Visible = false;
                btnNewClient.Visible  = false;
            }
            if (pnlReportsView.Visible)
            {
                btnNewService.Visible = false;
                btnNewClient.Visible  = false;
            }
             if (pnlScheduleView.Visible)
            {
                btnNewService.Visible = true;
                btnNewClient.Visible  = true;
            }
        }

        private void btnTabSchedule_Click(object sender, EventArgs e) => SetActiveTab(btnTabSchedule);
        private void btnTabBilling_Click(object sender, EventArgs e)  => SetActiveTab(btnTabBilling);
        private void btnTabReports_Click(object sender, EventArgs e)  => SetActiveTab(btnTabReports);

        // ── Date change ───────────────────────────────────────────────────────

        private async void dtpScheduleDate_ValueChanged(object sender, EventArgs e)
            => await BuildScheduleAsync(dtpScheduleDate.Value);

        // ── Sidebar actions ───────────────────────────────────────────────────

        private void btnNewService_Click(object sender, EventArgs e)
        {
            foreach (Control old in pnlIntakeView.Controls.Cast<Control>().ToList())
                old.Dispose();
            pnlIntakeView.Controls.Clear();

            var newServiceUC = Program.ServiceProvider.GetRequiredService<NewServiceUC>();
            newServiceUC.Dock = DockStyle.Fill;
            newServiceUC.ServiceCreated += async (_, _) => {
                SetActiveTab(btnTabSchedule);
                await BuildScheduleAsync(dtpScheduleDate.Value);
            };
            newServiceUC.Cancelled += (_, _) => SetActiveTab(btnTabSchedule);
            pnlIntakeView.Controls.Add(newServiceUC);

            StyleTab(btnTabSchedule, active: true);
            StyleTab(btnTabBilling,  active: false);
            StyleTab(btnTabReports,  active: false);
            pnlScheduleView.Visible = false;
            pnlBillingView.Visible  = false;
            pnlReportsView.Visible  = false;
            pnlIntakeView.Visible   = true;
        }

        private void btnNewDog_Click(object sender, EventArgs e) => OpenIntakeView();

        private void OpenIntakeView()
        {
            foreach (Control old in pnlIntakeView.Controls.Cast<Control>().ToList())
                old.Dispose();
            pnlIntakeView.Controls.Clear();

            var intake = Program.ServiceProvider.GetRequiredService<ClientIntakeUC>();
            intake.Dock = DockStyle.Fill;
            intake.NavigateBack += (_, _) => SetActiveTab(btnTabSchedule);
            pnlIntakeView.Controls.Add(intake);

            StyleTab(btnTabSchedule, active: true);
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
