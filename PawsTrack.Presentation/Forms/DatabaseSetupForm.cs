using Microsoft.Data.SqlClient;
using PawsTrack.Presentation.Helpers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace PawsTrack.Presentation.Forms
{
    public partial class DatabaseSetupForm : Form
    {
        private string? _testedConnectionString;

        public DatabaseSetupForm()
        {
            InitializeComponent();
            ApplyStyles();
            rdoWindows.Checked = true;
            UpdateSqlAuthFields();
        }

        private void ApplyStyles()
        {
            BackColor = AppStyles.BackgroundColor;

            lblTitle.Font      = AppStyles.TitleFont;
            lblTitle.ForeColor = AppStyles.PrimaryColor;

            lblSubtitle.Font      = AppStyles.SubtitleFont;
            lblSubtitle.ForeColor = AppStyles.TextSecondary;

            foreach (var lbl in new[] { lblServer, lblDatabase, lblAuth, lblSqlUser, lblSqlPassword })
            {
                lbl.Font      = AppStyles.LabelFont;
                lbl.ForeColor = AppStyles.TextPrimary;
            }

            foreach (var rdo in new[] { rdoWindows, rdoSqlServer })
            {
                rdo.Font      = AppStyles.LabelFont;
                rdo.ForeColor = AppStyles.TextPrimary;
            }

            AppStyles.StyleInput(txtServer);
            AppStyles.StyleInput(txtDatabase);
            AppStyles.StyleInput(txtSqlUser);
            AppStyles.StyleInput(txtSqlPassword);

            AppStyles.StylePrimaryButton(btnContinue);

            // Test button: outlined secondary style
            btnTest.BackColor = AppStyles.SurfaceColor;
            btnTest.ForeColor = AppStyles.PrimaryColor;
            btnTest.FlatStyle = FlatStyle.Flat;
            btnTest.FlatAppearance.BorderColor = AppStyles.PrimaryColor;
            btnTest.FlatAppearance.BorderSize  = 1;
            btnTest.Font   = AppStyles.ButtonFont;
            btnTest.Height = AppStyles.ButtonHeight;
            btnTest.Cursor = Cursors.Hand;
        }

        private void rdoWindows_CheckedChanged(object sender, EventArgs e)   => UpdateSqlAuthFields();
        private void rdoSqlServer_CheckedChanged(object sender, EventArgs e) => UpdateSqlAuthFields();

        private void UpdateSqlAuthFields()
        {
            bool sqlAuth = rdoSqlServer.Checked;
            lblSqlUser.Enabled    = sqlAuth;
            txtSqlUser.Enabled    = sqlAuth;
            lblSqlPassword.Enabled = sqlAuth;
            txtSqlPassword.Enabled = sqlAuth;

            // Changing auth mode invalidates any previous test result
            _testedConnectionString = null;
            btnContinue.Enabled = false;
            lblStatus.Visible   = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text) || string.IsNullOrWhiteSpace(txtDatabase.Text))
            {
                ShowStatus("Server and Database Name are required.", success: false);
                return;
            }

            if (rdoSqlServer.Checked &&
                (string.IsNullOrWhiteSpace(txtSqlUser.Text) || string.IsNullOrWhiteSpace(txtSqlPassword.Text)))
            {
                ShowStatus("SQL Username and Password are required for SQL Server Authentication.", success: false);
                return;
            }

            btnTest.Enabled = false;
            btnTest.Text    = "Testing...";
            _testedConnectionString = null;
            btnContinue.Enabled = false;

            string cs = BuildConnectionString();

            try
            {
                using var conn = new SqlConnection(cs);
                conn.Open();
                _testedConnectionString = cs;
                ShowStatus("Connection successful!", success: true);
                btnContinue.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowStatus($"Connection failed: {ex.Message}", success: false);
            }
            finally
            {
                btnTest.Enabled = true;
                btnTest.Text    = "Test Connection";
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (_testedConnectionString == null)
            {
                ShowStatus("Please test the connection first.", success: false);
                return;
            }

            SaveConnectionString(_testedConnectionString);
            DialogResult = DialogResult.OK;
            Close();
        }

        private string BuildConnectionString()
        {
            var server   = txtServer.Text.Trim();
            var database = txtDatabase.Text.Trim();

            if (rdoWindows.Checked)
                return $"Server={server};Database={database};Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

            var user     = txtSqlUser.Text.Trim();
            var password = txtSqlPassword.Text;
            return $"Server={server};Database={database};User Id={user};Password={password};MultipleActiveResultSets=true;TrustServerCertificate=True";
        }

        private static void SaveConnectionString(string connectionString)
        {
            var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            var json = File.ReadAllText(appSettingsPath);
            var root = JsonNode.Parse(json)!.AsObject();

            root["ConnectionStrings"]!["PawsTrack"] = JsonValue.Create(connectionString);
            root["DbConfigured"] = JsonValue.Create(true);

            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(appSettingsPath, root.ToJsonString(options));
        }

        private void ShowStatus(string message, bool success)
        {
            lblStatus.Text      = message;
            lblStatus.ForeColor = success ? AppStyles.SuccessColor : AppStyles.ErrorColor;
            lblStatus.Font      = AppStyles.SmallFont;
            lblStatus.Visible   = true;
        }
    }
}
