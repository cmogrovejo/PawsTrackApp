using Microsoft.Extensions.DependencyInjection;
using PawsTrack.Application.DTOs;
using PawsTrack.Application.Interfaces;
using PawsTrack.Presentation.Helpers;

namespace PawsTrack.Presentation.UserControls
{
    public partial class NewServiceUC : UserControl
    {
        private readonly IServiceProvider _serviceProvider;

        // Set when the user selects a client row; reset when search changes.
        private int? _selectedClientId;

        public event EventHandler? ServiceCreated;
        public event EventHandler? Cancelled;

        public NewServiceUC(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            ApplyStyles();
            dtpDate.MinDate = DateTime.Today;
            dtpDate.Value   = DateTime.Today;
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            pnlHeader.BackColor  = AppStyles.SurfaceColor;
            lblTitle.Font        = AppStyles.SubtitleFont;
            lblTitle.ForeColor   = AppStyles.TextPrimary;

            pnlBody.BackColor = AppStyles.BackgroundColor;

            lblScheduleSection.Font      = AppStyles.ButtonFont;
            lblScheduleSection.ForeColor = AppStyles.PrimaryColor;
            lblClientSection.Font        = AppStyles.ButtonFont;
            lblClientSection.ForeColor   = AppStyles.PrimaryColor;
            lblDogSection.Font           = AppStyles.ButtonFont;
            lblDogSection.ForeColor      = AppStyles.PrimaryColor;

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

            AppStyles.StyleInput(txtClientSearch);
            txtClientSearch.PlaceholderText = "Search by name or phone...";
            AppStyles.StylePrimaryButton(btnSearchClient);

            dgvClients.BackgroundColor        = AppStyles.BackgroundColor;
            dgvClients.BorderStyle            = BorderStyle.FixedSingle;
            dgvClients.GridColor              = AppStyles.BorderColor;
            dgvClients.DefaultCellStyle.Font  = AppStyles.LabelFont;
            dgvClients.DefaultCellStyle.ForeColor          = AppStyles.TextPrimary;
            dgvClients.DefaultCellStyle.BackColor          = Color.White;
            dgvClients.DefaultCellStyle.SelectionBackColor = AppStyles.AccentColor;
            dgvClients.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvClients.ColumnHeadersDefaultCellStyle.Font      = AppStyles.LabelAccentFont;
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = AppStyles.SurfaceColor;
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = AppStyles.TextSecondary;
            dgvClients.EnableHeadersVisualStyles = false;
            dgvClients.RowTemplate.Height        = 28;

            cmbDog.Font      = AppStyles.InputFont;
            cmbDog.BackColor = AppStyles.SurfaceColor;
            cmbDog.ForeColor = AppStyles.TextPrimary;

            pnlFooter.BackColor = AppStyles.SurfaceColor;
            lblError.Font       = AppStyles.SmallFont;
            lblError.ForeColor  = AppStyles.ErrorColor;

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

        // ── Client search ──────────────────────────────────────────────────────

        private void txtClientSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearchClient.PerformClick();
            }
        }

        private async void btnSearchClient_Click(object sender, EventArgs e)
        {
            ResetClientSelection();
            btnSearchClient.Enabled = false;
            try
            {
                IReadOnlyList<ClientSummaryDto> results;
                await using (var scope = _serviceProvider.CreateAsyncScope())
                {
                    var svc = scope.ServiceProvider.GetRequiredService<IIntakeService>();
                    results = await svc.SearchClientsAsync(txtClientSearch.Text.Trim());
                }

                dgvClients.DataSource = null;
                dgvClients.Columns.Clear();
                dgvClients.DataSource = results.ToList();

                if (dgvClients.Columns.Count > 0)
                {
                    dgvClients.Columns["Id"].Visible        = false;
                    dgvClients.Columns["FullName"].HeaderText = "Name";
                    dgvClients.Columns["Phone"].HeaderText    = "Phone";
                    dgvClients.Columns["Address"].HeaderText  = "Address";
                }
            }
            finally
            {
                btnSearchClient.Enabled = true;
            }
        }

        private async void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.DataBoundItem is not ClientSummaryDto selected)
            {
                ResetClientSelection();
                return;
            }

            _selectedClientId = selected.Id;
            await LoadDogsForClientAsync(selected.Id);
        }

        private async Task LoadDogsForClientAsync(int clientId)
        {
            cmbDog.DataSource    = null;
            cmbDog.Enabled       = false;

            IReadOnlyList<DogSummaryDto> dogs;
            await using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var svc = scope.ServiceProvider.GetRequiredService<IWalkScheduleService>();
                dogs = await svc.GetDogsByClientAsync(clientId);
            }

            cmbDog.DataSource    = dogs.ToList();
            cmbDog.DisplayMember = "Name";
            cmbDog.ValueMember   = "Id";
            cmbDog.Enabled       = dogs.Count > 0;

            if (dogs.Count == 0)
                ShowError("This client has no dogs registered. Add a dog first via Client Intake.");
            else
                lblError.Visible = false;
        }

        private void ResetClientSelection()
        {
            _selectedClientId = null;
            cmbDog.DataSource  = null;
            cmbDog.Enabled     = false;
        }

        // ── Save ───────────────────────────────────────────────────────────────

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            // Build candidate datetimes
            var date      = dtpDate.Value.Date;
            var hourFrom  = (int)numHourFrom.Value;
            var hourTo    = (int)numHourTo.Value;
            var startTime = date.AddHours(hourFrom);
            var endTime   = date.AddHours(hourTo);

            // Validate date/time
            if (startTime <= DateTime.Now)
            { ShowError("Start date and time must be after the current date and time."); return; }

            if (endTime <= startTime)
            { ShowError("Hour To must be greater than Hour From."); return; }

            // Validate client
            if (_selectedClientId is null)
            { ShowError("Please search and select a client."); return; }

            // Validate dog
            if (cmbDog.SelectedItem is not DogSummaryDto selectedDog)
            { ShowError("Please select a dog."); return; }

            btnSave.Enabled = false;
            btnSave.Text    = "Saving...";

            try
            {
                var request = new CreateWalkServiceRequest
                {
                    ClientId  = _selectedClientId.Value,
                    DogId     = selectedDog.Id,
                    StartTime = startTime,
                    EndTime   = endTime
                };

                WalkServiceCreatedDto result;
                await using (var scope = _serviceProvider.CreateAsyncScope())
                {
                    var svc = scope.ServiceProvider.GetRequiredService<IWalkScheduleService>();
                    result = await svc.CreateAsync(request);
                }

                MessageBox.Show(
                    $"Service created for \"{result.ClientName}\" \u2014 {result.DogName}\n" +
                    $"{result.StartTime:g} \u2192 {result.EndTime:g}\nStatus: {result.Status}",
                    "Service Scheduled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ServiceCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text    = "Save Service";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
            => Cancelled?.Invoke(this, EventArgs.Empty);

        private void ShowError(string message)
        {
            lblError.Text    = message;
            lblError.Visible = true;
        }
    }
}
