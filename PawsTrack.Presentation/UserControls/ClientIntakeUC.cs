using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.Forms
{
    public partial class ClientIntakeUC : UserControl
    {
        private readonly IServiceProvider _serviceProvider;

        // null = creating a new client; non-null = adding dog to existing client
        private int? _selectedClientId;

        /// <summary>Raised when the user clicks the back-to-schedule button.</summary>
        public event EventHandler? NavigateBack;

        public ClientIntakeUC(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            ApplyStyles();
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            // Search panel
            pnlSearchHeader.BackColor  = AppStyles.BackgroundColor;

            btnBackToDashboard.FlatStyle                  = FlatStyle.Flat;
            btnBackToDashboard.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnBackToDashboard.BackColor                  = Color.White;
            btnBackToDashboard.ForeColor                  = AppStyles.TextPrimary;
            btnBackToDashboard.Font                       = AppStyles.SmallFont;
            btnBackToDashboard.Cursor                     = Cursors.Hand;

            lblIntakeTitle.Font        = AppStyles.SubtitleFont;
            lblIntakeTitle.ForeColor   = AppStyles.TextPrimary;
            lblIntakeSubtitle.Font     = AppStyles.SmallFont;
            lblIntakeSubtitle.ForeColor = AppStyles.TextSecondary;

            pnlSearchBar.BackColor = AppStyles.BackgroundColor;
            AppStyles.StyleInput(txtSearch);
            txtSearch.PlaceholderText = "Search by name or phone...";
            AppStyles.StylePrimaryButton(btnSearch);

            dgvClients.BackgroundColor       = AppStyles.BackgroundColor;
            dgvClients.BorderStyle           = BorderStyle.None;
            dgvClients.GridColor             = AppStyles.BorderColor;
            dgvClients.DefaultCellStyle.Font = AppStyles.LabelFont;
            dgvClients.DefaultCellStyle.ForeColor         = AppStyles.TextPrimary;
            dgvClients.DefaultCellStyle.BackColor         = Color.White;
            dgvClients.DefaultCellStyle.SelectionBackColor = AppStyles.AccentColor;
            dgvClients.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvClients.ColumnHeadersDefaultCellStyle.Font      = AppStyles.LabelAccentFont;
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = AppStyles.SurfaceColor;
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = AppStyles.TextSecondary;
            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.RowTemplate.Height        = 30;

            pnlSearchFooter.BackColor = AppStyles.SurfaceColor;
            AppStyles.StylePrimaryButton(btnAddDogToClient);
            btnAddDogToClient.BackColor = AppStyles.AccentColor;

            btnCreateNew.FlatStyle                  = FlatStyle.Flat;
            btnCreateNew.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnCreateNew.BackColor                  = Color.White;
            btnCreateNew.ForeColor                  = AppStyles.TextPrimary;
            btnCreateNew.Font                       = AppStyles.ButtonFont;
            btnCreateNew.Height                     = AppStyles.ButtonHeight;
            btnCreateNew.Cursor                     = Cursors.Hand;

            // Form panel
            pnlFormHeader.BackColor = AppStyles.SurfaceColor;
            btnBack.FlatStyle                  = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnBack.BackColor                  = Color.White;
            btnBack.ForeColor                  = AppStyles.TextPrimary;
            btnBack.Font                       = AppStyles.SmallFont;
            btnBack.Cursor                     = Cursors.Hand;

            lblFormTitle.Font      = AppStyles.ButtonFont;
            lblFormTitle.ForeColor = AppStyles.TextPrimary;

            pnlScroll.BackColor = AppStyles.BackgroundColor;

            pnlClientCard.BackColor = Color.White;
            pnlDogCard.BackColor    = Color.White;

            lblClientSection.Font      = AppStyles.ButtonFont;
            lblClientSection.ForeColor = AppStyles.PrimaryColor;
            lblDogSection.Font         = AppStyles.ButtonFont;
            lblDogSection.ForeColor    = AppStyles.PrimaryColor;

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

            pnlFormFooter.BackColor = AppStyles.SurfaceColor;
            lblError.Font      = AppStyles.SmallFont;
            lblError.ForeColor = AppStyles.ErrorColor;

            AppStyles.StylePrimaryButton(btnSave);
            btnSave.BackColor = AppStyles.AccentColor;

            btnCancel.FlatStyle                  = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = AppStyles.BorderColor;
            btnCancel.BackColor                  = Color.White;
            btnCancel.ForeColor                  = AppStyles.TextPrimary;
            btnCancel.Font                       = AppStyles.ButtonFont;
            btnCancel.Height                     = AppStyles.ButtonHeight;
            btnCancel.Cursor                     = Cursors.Hand;
        }

        // ── Back to dashboard ──────────────────────────────────────────────────

        private void btnBackToDashboard_Click(object sender, EventArgs e)
            => NavigateBack?.Invoke(this, EventArgs.Empty);

        // ── Search panel ───────────────────────────────────────────────────────

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await RunSearchAsync(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }

        private async Task RunSearchAsync(string term)
        {
            btnSearch.Enabled = false;
            try
            {
                IReadOnlyList<ClientSummaryDto> results;
                await using (var scope = _serviceProvider.CreateAsyncScope())
                {
                    var svc = scope.ServiceProvider.GetRequiredService<IIntakeService>();
                    results = await svc.SearchClientsAsync(term);
                }

                dgvClients.DataSource = null;
                dgvClients.Columns.Clear();
                dgvClients.DataSource = results.ToList();

                if (dgvClients.Columns.Count > 0)
                {
                    dgvClients.Columns["Id"].Visible   = false;
                    dgvClients.Columns["FullName"].HeaderText = "Name";
                    dgvClients.Columns["Phone"].HeaderText    = "Phone";
                    dgvClients.Columns["Address"].HeaderText  = "Address";
                }
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        private void btnAddDogToClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.DataBoundItem is not ClientSummaryDto selected)
            {
                MessageBox.Show(
                    "Please select a client from the list first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _selectedClientId = selected.Id;
            ShowFormPanel(
                title: $"Add Dog \u2014 {selected.FullName}",
                lockClientFields: true,
                client: selected);
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            _selectedClientId = null;
            ShowFormPanel(
                title: "New Client & Dog",
                lockClientFields: false,
                client: null);
        }

        // ── Form panel ─────────────────────────────────────────────────────────

        private void ShowFormPanel(string title, bool lockClientFields, ClientSummaryDto? client)
        {
            lblFormTitle.Text = title;

            txtFullName.Text     = client?.FullName ?? string.Empty;
            txtPhone.Text        = client?.Phone    ?? string.Empty;
            txtAddress.Text      = client?.Address  ?? string.Empty;
            txtFullName.ReadOnly = lockClientFields;
            txtPhone.ReadOnly    = lockClientFields;
            txtAddress.ReadOnly  = lockClientFields;

            // Clear dog fields
            txtDogName.Text      = string.Empty;
            txtAge.Text          = string.Empty;
            cmbBreed.Text        = string.Empty;
            txtMedicalNotes.Text = string.Empty;

            lblError.Visible = false;

            pnlSearch.Visible = false;
            pnlForm.Visible   = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlForm.Visible   = false;
            pnlSearch.Visible = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            // Validate dog fields (always required)
            if (string.IsNullOrWhiteSpace(txtDogName.Text))
            { ShowError("Dog name is required."); return; }

            if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 0 || age > 30)
            { ShowError("Age must be a whole number between 0 and 30."); return; }

            if (string.IsNullOrWhiteSpace(cmbBreed.Text))
            { ShowError("Breed is required."); return; }

            // Validate client fields only when creating a new client
            if (_selectedClientId is null)
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                { ShowError("Owner full name is required."); return; }
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                { ShowError("Phone is required."); return; }
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                { ShowError("Address is required."); return; }
            }

            btnSave.Enabled = false;
            btnSave.Text    = "Saving...";

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
                    var svc = scope.ServiceProvider.GetRequiredService<IIntakeService>();

                    if (_selectedClientId is int existingId)
                    {
                        result = await svc.AddDogToExistingClientAsync(existingId, dogReq);
                    }
                    else
                    {
                        var clientReq = new CreateClientRequest
                        {
                            FullName = txtFullName.Text.Trim(),
                            Phone    = txtPhone.Text.Trim(),
                            Address  = txtAddress.Text.Trim()
                        };
                        result = await svc.CreateClientWithDogAsync(clientReq, dogReq);
                    }
                }

                MessageBox.Show(
                    $"Dog \"{result.DogName}\" saved for client \"{result.ClientFullName}\".",
                    "Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Return to search panel and refresh
                pnlForm.Visible   = false;
                pnlSearch.Visible = true;
                await RunSearchAsync(txtSearch.Text.Trim());
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text    = "Save";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible   = false;
            pnlSearch.Visible = true;
        }

        private void ShowError(string message)
        {
            lblError.Text    = message;
            lblError.Visible = true;
        }
    }
}
