using PawsTrack.Application.DTOs;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class ViewServiceForm : Form
    {
        public ViewServiceForm(WalkServiceCreatedDto dto)
        {
            InitializeComponent();
            ApplyStyles();
            PopulateFields(dto);
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            pnlCard.BackColor  = AppStyles.SurfaceColor;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;

            lblTitle.Font      = AppStyles.SubtitleFont;
            lblTitle.ForeColor = AppStyles.TextPrimary;

            pnlSep.BackColor = AppStyles.BorderColor;

            foreach (var lbl in new[]
            {
                lblOwnerCaption, lblDogCaption, lblDateCaption,
                lblFromCaption,  lblToCaption,  lblStatusCaption
            })
            {
                lbl.Font      = AppStyles.LabelAccentFont;
                lbl.ForeColor = AppStyles.TextSecondary;
            }

            foreach (var lbl in new[]
            {
                lblOwnerValue, lblDogValue, lblDateValue,
                lblFromValue,  lblToValue,  lblStatusValue
            })
            {
                lbl.Font      = AppStyles.LabelFont;
                lbl.ForeColor = AppStyles.TextPrimary;
            }

            btnClose.FlatStyle                  = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnClose.BackColor                  = Color.White;
            btnClose.ForeColor                  = AppStyles.TextPrimary;
            btnClose.Font                       = AppStyles.ButtonFont;
            btnClose.Cursor                     = Cursors.Hand;
        }

        private void PopulateFields(WalkServiceCreatedDto dto)
        {
            lblOwnerValue.Text  = dto.ClientName;
            lblDogValue.Text    = dto.DogName;
            lblDateValue.Text   = dto.StartTime.ToString("dddd, MMMM d, yyyy");
            lblFromValue.Text   = dto.StartTime.ToString("HH:mm");
            lblToValue.Text     = dto.EndTime.ToString("HH:mm");
            lblStatusValue.Text = dto.Status;

            lblStatusValue.ForeColor = dto.Status switch
            {
                "Created"    => AppStyles.AccentColor,
                "InProgress" => AppStyles.SuccessColor,
                "Completed"  => AppStyles.TextSecondary,
                _            => AppStyles.TextPrimary
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
