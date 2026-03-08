using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class EditServiceForm : Form
    {
        private readonly IServiceProvider        _serviceProvider;
        private readonly WalkServiceCreatedDto   _original;

        public EditServiceForm(IServiceProvider serviceProvider, WalkServiceCreatedDto original)
        {
            _serviceProvider = serviceProvider;
            _original        = original;
            InitializeComponent();
            ApplyStyles();
            PopulateExistingValues();
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            pnlCard.BackColor   = AppStyles.SurfaceColor;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;

            lblTitle.Font      = AppStyles.SubtitleFont;
            lblTitle.ForeColor = AppStyles.TextPrimary;

            pnlSep.BackColor = AppStyles.BorderColor;

            foreach (var lbl in new[] { lblOwnerCaption, lblDogCaption })
            {
                lbl.Font      = AppStyles.LabelAccentFont;
                lbl.ForeColor = AppStyles.TextSecondary;
            }

            foreach (var lbl in new[] { lblOwnerValue, lblDogValue })
            {
                lbl.Font      = AppStyles.LabelFont;
                lbl.ForeColor = AppStyles.TextPrimary;
            }

            foreach (var lbl in new[] { lblDate, lblHourFrom, lblHourTo })
            {
                lbl.Font      = AppStyles.LabelFont;
                lbl.ForeColor = AppStyles.TextPrimary;
            }

            dtpDate.Font = AppStyles.InputFont;

            numHourFrom.Font      = AppStyles.InputFont;
            numHourFrom.BackColor = AppStyles.SurfaceColor;
            numHourTo.Font        = AppStyles.InputFont;
            numHourTo.BackColor   = AppStyles.SurfaceColor;

            lblError.Font      = AppStyles.SmallFont;
            lblError.ForeColor = AppStyles.ErrorColor;

            AppStyles.StylePrimaryButton(btnSave);
            btnSave.Height = 36;

            btnCancel.FlatStyle                  = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnCancel.BackColor                  = Color.White;
            btnCancel.ForeColor                  = AppStyles.TextPrimary;
            btnCancel.Font                       = AppStyles.ButtonFont;
            btnCancel.Height                     = 36;
            btnCancel.Cursor                     = Cursors.Hand;
        }

        private void PopulateExistingValues()
        {
            lblOwnerValue.Text   = _original.ClientName;
            lblDogValue.Text     = _original.DogName;
            dtpDate.Value        = _original.StartTime.Date;
            numHourFrom.Value    = _original.StartTime.Hour;
            numHourTo.Value      = _original.EndTime.Hour;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            var date      = dtpDate.Value.Date;
            var hourFrom  = (int)numHourFrom.Value;
            var hourTo    = (int)numHourTo.Value;
            var startTime = date.AddHours(hourFrom);
            var endTime   = date.AddHours(hourTo);

            if (startTime <= DateTime.Now)
            { ShowError("Start date and time must be after the current date and time."); return; }

            if (endTime <= startTime)
            { ShowError("Hour To must be greater than Hour From."); return; }

            btnSave.Enabled = false;
            btnSave.Text    = "Saving...";
            try
            {
                var request = new UpdateWalkServiceRequest
                {
                    Id        = _original.Id,
                    StartTime = startTime,
                    EndTime   = endTime
                };

                await using (var scope = _serviceProvider.CreateAsyncScope())
                {
                    var svc = scope.ServiceProvider.GetRequiredService<IWalkScheduleService>();
                    await svc.UpdateAsync(request);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                ShowError(ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text    = "Save Changes";
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
