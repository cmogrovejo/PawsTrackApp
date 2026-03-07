using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class ClientIntakeForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public ClientIntakeForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            lblClientSection.Font      = AppStyles.ButtonFont;
            lblClientSection.ForeColor = AppStyles.PrimaryColor;

            lblDogSection.Font      = AppStyles.ButtonFont;
            lblDogSection.ForeColor = AppStyles.PrimaryColor;

            foreach (var lbl in new[] { lblFullName, lblPhone, lblAddress, lblDogName, lblAge, lblBreed, lblMedicalNotes })
            {
                lbl.Font      = AppStyles.LabelFont;
                lbl.ForeColor = AppStyles.TextPrimary;
            }

            AppStyles.StyleInput(txtFullName);
            AppStyles.StyleInput(txtPhone);
            AppStyles.StyleInput(txtAddress);
            AppStyles.StyleInput(txtDogName);
            AppStyles.StyleInput(txtAge);
            AppStyles.StyleInput(txtMedicalNotes);

            cmbBreed.Font      = AppStyles.InputFont;
            cmbBreed.BackColor = AppStyles.SurfaceColor;
            cmbBreed.ForeColor = AppStyles.TextPrimary;
            cmbBreed.Items.AddRange(BreedList.All);
            cmbBreed.AutoCompleteMode   = AutoCompleteMode.SuggestAppend;
            cmbBreed.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBreed.DropDownStyle      = ComboBoxStyle.DropDown;

            lblError.Font      = AppStyles.SmallFont;
            lblError.ForeColor = AppStyles.ErrorColor;

            AppStyles.StylePrimaryButton(btnSave);
            btnSave.BackColor = AppStyles.AccentColor;

            btnCancel.Font      = AppStyles.ButtonFont;
            btnCancel.Height    = AppStyles.ButtonHeight;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Cursor    = Cursors.Hand;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible  = false;
            btnSave.Enabled   = false;
            btnSave.Text      = "Saving...";

            // --- UI validation ---
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowError("Owner full name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                ShowError("Phone is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                ShowError("Address is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDogName.Text))
            {
                ShowError("Dog name is required.");
                return;
            }
            if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 0 || age > 30)
            {
                ShowError("Age must be a whole number between 0 and 30.");
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbBreed.Text))
            {
                ShowError("Breed is required.");
                return;
            }

            var clientReq = new CreateClientRequest
            {
                FullName = txtFullName.Text.Trim(),
                Phone    = txtPhone.Text.Trim(),
                Address  = txtAddress.Text.Trim()
            };
            var dogReq = new CreateDogRequest
            {
                Name         = txtDogName.Text.Trim(),
                AgeYears     = age,
                Breed        = cmbBreed.Text.Trim(),
                MedicalNotes = string.IsNullOrWhiteSpace(txtMedicalNotes.Text) ? null : txtMedicalNotes.Text.Trim()
            };

            try
            {
                ClientCreatedDto result;
                await using (var scope = _serviceProvider.CreateAsyncScope())
                {
                    var intakeService = scope.ServiceProvider.GetRequiredService<IIntakeService>();
                    result = await intakeService.CreateClientWithDogAsync(clientReq, dogReq);
                }

                MessageBox.Show(
                    $"Client \"{result.ClientFullName}\" and dog \"{result.DogName}\" saved successfully.",
                    "Intake Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
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
            btnSave.Enabled  = true;
            btnSave.Text     = "Save Client & Dog";
        }
    }
}
