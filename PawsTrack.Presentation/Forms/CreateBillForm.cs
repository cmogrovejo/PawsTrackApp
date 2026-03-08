using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class CreateBillForm : Form
    {
        private readonly IServiceProvider   _serviceProvider;
        private readonly BillableServiceDto _service;

        public CreateBillForm(IServiceProvider serviceProvider, BillableServiceDto service)
        {
            _serviceProvider = serviceProvider;
            _service         = service;
            InitializeComponent();
            ApplyStyles();
            PopulateFields();
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            lblTitle.Font      = AppStyles.SubtitleFont;
            lblTitle.ForeColor = AppStyles.TextPrimary;

            pnlSep.BackColor  = AppStyles.BorderColor;
            pnlSep2.BackColor = AppStyles.BorderColor;

            foreach (var lbl in new[] { lblOwnerCaption, lblDogCaption, lblDateCaption, lblDurationCaption })
            {
                lbl.Font      = AppStyles.SmallFont;
                lbl.ForeColor = AppStyles.TextSecondary;
            }

            foreach (var lbl in new[] { lblOwnerValue, lblDogValue, lblDateValue, lblDurationValue })
            {
                lbl.Font      = AppStyles.LabelFont;
                lbl.ForeColor = AppStyles.TextPrimary;
            }

            lblRatePerHour.Font = AppStyles.LabelFont;
            lblRatePerHour.ForeColor = AppStyles.TextPrimary;
            numRatePerHour.Font = AppStyles.InputFont;

            lblDiscount.Font = AppStyles.LabelFont;
            lblDiscount.ForeColor = AppStyles.TextPrimary;
            numDiscount.Font = AppStyles.InputFont;

            lblTotal.Font      = AppStyles.SubtitleFont;
            lblTotal.ForeColor = AppStyles.TextPrimary;

            lblError.Font = AppStyles.LabelFont;

            AppStyles.StylePrimaryButton(btnCreateBill);

            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = AppStyles.TextPrimary;
            btnCancel.Font      = AppStyles.ButtonFont;
            btnCancel.Cursor    = Cursors.Hand;
        }

        private void PopulateFields()
        {
            lblOwnerValue.Text    = _service.ClientName;
            lblDogValue.Text      = _service.DogName;
            lblDateValue.Text     = $"{_service.StartTime:ddd dd/MM/yyyy}   {_service.StartTime:HH:mm} \u2192 {_service.EndTime:HH:mm}";
            lblDurationValue.Text = $"{_service.DurationHours:F1} hrs";
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            var total = Math.Max(0m, (decimal)_service.DurationHours * numRatePerHour.Value - numDiscount.Value);
            lblTotal.Text = $"Total: {total:C}";
        }

        private void numRatePerHour_ValueChanged(object sender, EventArgs e) => UpdateTotal();
        private void numDiscount_ValueChanged(object sender, EventArgs e)    => UpdateTotal();

        private async void btnCreateBill_Click(object sender, EventArgs e)
        {
            if (numRatePerHour.Value <= 0)
            {
                ShowError("Rate per hour is required.");
                return;
            }

            lblError.Visible     = false;
            btnCreateBill.Enabled = false;
            btnCreateBill.Text   = "Creating...";

            try
            {
                BillDto dto;
                await using (var scope = _serviceProvider.CreateAsyncScope())
                {
                    var svc = scope.ServiceProvider.GetRequiredService<IBillingService>();
                    dto = await svc.CreateBillAsync(new CreateBillRequest(
                        _service.WalkServiceId,
                        numRatePerHour.Value,
                        numDiscount.Value));
                }

                MessageBox.Show(
                    $"Bill created successfully.\nTotal: {dto.TotalAmount:C}",
                    "Bill Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
                btnCreateBill.Enabled = true;
                btnCreateBill.Text    = "Create Bill";
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
