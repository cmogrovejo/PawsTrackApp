namespace PawsTrack.Presentation.Forms
{
    partial class MainDashboardWalkerForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;

        // Nav bar
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlNavBorder;
        private System.Windows.Forms.Button btnTabSchedule;
        private System.Windows.Forms.Button btnTabBilling;
        private System.Windows.Forms.Button btnTabReports;

        // Body
        private System.Windows.Forms.Panel pnlBody;

        // Sidebar
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlSidebarBorder;
        private System.Windows.Forms.Panel pnlIntakeView;
        private System.Windows.Forms.Button btnNewService;
        private System.Windows.Forms.Button btnNewClient;

        // Main content host
        private System.Windows.Forms.Panel pnlMainContent;

        // Schedule view
        private System.Windows.Forms.Panel pnlScheduleView;
        private System.Windows.Forms.Panel pnlScheduleHeader;
        private System.Windows.Forms.Panel pnlScheduleHeaderBorder;
        private System.Windows.Forms.Label lblScheduleTitle;
        private System.Windows.Forms.DateTimePicker dtpScheduleDate;
        private System.Windows.Forms.Panel pnlTimeSlots;

        // Billing view
        private System.Windows.Forms.Panel pnlBillingView;
        private System.Windows.Forms.Label lblBillingPlaceholder;

        // Reports view
        private System.Windows.Forms.Panel pnlReportsView;
        private System.Windows.Forms.Label lblReportsPlaceholder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblAppTitle = new Label();
            lblUserInfo = new Label();
            btnLogout = new Button();
            pnlNav = new Panel();
            btnTabSchedule = new Button();
            btnTabBilling = new Button();
            btnTabReports = new Button();
            pnlNavBorder = new Panel();
            pnlBody = new Panel();
            pnlMainContent = new Panel();
            pnlScheduleView = new Panel();
            pnlTimeSlots = new Panel();
            pnlScheduleHeader = new Panel();
            lblScheduleTitle = new Label();
            dtpScheduleDate = new DateTimePicker();
            pnlScheduleHeaderBorder = new Panel();
            pnlBillingView = new Panel();
            lblBillingPlaceholder = new Label();
            pnlReportsView = new Panel();
            lblReportsPlaceholder = new Label();
            pnlIntakeView = new Panel();
            pnlSidebar = new Panel();
            btnNewService = new Button();
            btnNewClient = new Button();
            pnlSidebarBorder = new Panel();
            pnlHeader.SuspendLayout();
            pnlNav.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlScheduleView.SuspendLayout();
            pnlScheduleHeader.SuspendLayout();
            pnlBillingView.SuspendLayout();
            pnlReportsView.SuspendLayout();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblUserInfo);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1143, 85);
            pnlHeader.TabIndex = 2;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Location = new Point(27, 13);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(183, 32);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "PawsTrack";
            // 
            // lblUserInfo
            // 
            lblUserInfo.Location = new Point(27, 48);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(686, 24);
            lblUserInfo.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new System.Drawing.Point(880, 14);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(114, 48);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Log Out";
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.White;
            pnlNav.Controls.Add(btnTabSchedule);
            pnlNav.Controls.Add(btnTabBilling);
            pnlNav.Controls.Add(btnTabReports);
            pnlNav.Controls.Add(pnlNavBorder);
            pnlNav.Dock = DockStyle.Top;
            pnlNav.Location = new Point(0, 85);
            pnlNav.Margin = new Padding(3, 4, 3, 4);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(1143, 59);
            pnlNav.TabIndex = 1;
            // 
            // btnTabSchedule
            // 
            btnTabSchedule.Location = new Point(0, 0);
            btnTabSchedule.Margin = new Padding(3, 4, 3, 4);
            btnTabSchedule.Name = "btnTabSchedule";
            btnTabSchedule.Size = new Size(206, 59);
            btnTabSchedule.TabIndex = 0;
            btnTabSchedule.Text = "Schedule && Services";
            btnTabSchedule.Click += btnTabSchedule_Click;
            // 
            // btnTabBilling
            // 
            btnTabBilling.Location = new Point(206, 0);
            btnTabBilling.Margin = new Padding(3, 4, 3, 4);
            btnTabBilling.Name = "btnTabBilling";
            btnTabBilling.Size = new Size(126, 59);
            btnTabBilling.TabIndex = 1;
            btnTabBilling.Text = "Billing";
            btnTabBilling.Click += btnTabBilling_Click;
            // 
            // btnTabReports
            // 
            btnTabReports.Location = new Point(331, 0);
            btnTabReports.Margin = new Padding(3, 4, 3, 4);
            btnTabReports.Name = "btnTabReports";
            btnTabReports.Size = new Size(126, 59);
            btnTabReports.TabIndex = 2;
            btnTabReports.Text = "Reports";
            btnTabReports.Click += btnTabReports_Click;
            // 
            // pnlNavBorder
            // 
            pnlNavBorder.Dock = DockStyle.Bottom;
            pnlNavBorder.Location = new Point(0, 58);
            pnlNavBorder.Margin = new Padding(3, 4, 3, 4);
            pnlNavBorder.Name = "pnlNavBorder";
            pnlNavBorder.Size = new Size(1143, 1);
            pnlNavBorder.TabIndex = 3;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(pnlMainContent);
            pnlBody.Controls.Add(pnlSidebar);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 144);
            pnlBody.Margin = new Padding(3, 4, 3, 4);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(1143, 723);
            pnlBody.TabIndex = 0;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlMainContent.Controls.Add(pnlScheduleView);
            pnlMainContent.Controls.Add(pnlBillingView);
            pnlMainContent.Controls.Add(pnlReportsView);
            pnlMainContent.Controls.Add(pnlIntakeView);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(123, 0);
            pnlMainContent.Margin = new Padding(3, 4, 3, 4);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1020, 723);
            pnlMainContent.TabIndex = 0;
            // 
            // pnlScheduleView
            // 
            pnlScheduleView.Controls.Add(pnlTimeSlots);
            pnlScheduleView.Controls.Add(pnlScheduleHeader);
            pnlScheduleView.Dock = DockStyle.Fill;
            pnlScheduleView.Location = new Point(0, 0);
            pnlScheduleView.Margin = new Padding(3, 4, 3, 4);
            pnlScheduleView.Name = "pnlScheduleView";
            pnlScheduleView.Size = new Size(1020, 723);
            pnlScheduleView.TabIndex = 0;
            // 
            // pnlTimeSlots
            // 
            pnlTimeSlots.AutoScroll = true;
            pnlTimeSlots.BackColor = Color.White;
            pnlTimeSlots.Dock = DockStyle.Fill;
            pnlTimeSlots.Location = new Point(0, 62);
            pnlTimeSlots.Margin = new Padding(3, 4, 3, 4);
            pnlTimeSlots.Name = "pnlTimeSlots";
            pnlTimeSlots.Size = new Size(1020, 661);
            pnlTimeSlots.TabIndex = 0;
            // 
            // pnlScheduleHeader
            // 
            pnlScheduleHeader.BackColor = Color.White;
            pnlScheduleHeader.Controls.Add(lblScheduleTitle);
            pnlScheduleHeader.Controls.Add(dtpScheduleDate);
            pnlScheduleHeader.Controls.Add(pnlScheduleHeaderBorder);
            pnlScheduleHeader.Dock = DockStyle.Top;
            pnlScheduleHeader.Location = new Point(0, 0);
            pnlScheduleHeader.Margin = new Padding(3, 4, 3, 4);
            pnlScheduleHeader.Name = "pnlScheduleHeader";
            pnlScheduleHeader.Padding = new Padding(18, 11, 18, 0);
            pnlScheduleHeader.Size = new Size(1020, 62);
            pnlScheduleHeader.TabIndex = 1;
            // 
            // lblScheduleTitle
            // 
            lblScheduleTitle.Location = new Point(18, 11);
            lblScheduleTitle.Name = "lblScheduleTitle";
            lblScheduleTitle.Size = new Size(130, 40);
            lblScheduleTitle.TabIndex = 0;
            lblScheduleTitle.Text = "Schedule For:";
            lblScheduleTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpScheduleDate
            // 
            dtpScheduleDate.CustomFormat = "dd/MM/yyyy";
            dtpScheduleDate.Format = DateTimePickerFormat.Custom;
            dtpScheduleDate.Location = new Point(165, 15);
            dtpScheduleDate.Margin = new Padding(3, 4, 3, 4);
            dtpScheduleDate.Name = "dtpScheduleDate";
            dtpScheduleDate.Size = new Size(169, 27);
            dtpScheduleDate.TabIndex = 1;
            dtpScheduleDate.ValueChanged += dtpScheduleDate_ValueChanged;
            // 
            // pnlScheduleHeaderBorder
            // 
            pnlScheduleHeaderBorder.Dock = DockStyle.Bottom;
            pnlScheduleHeaderBorder.Location = new Point(18, 61);
            pnlScheduleHeaderBorder.Margin = new Padding(3, 4, 3, 4);
            pnlScheduleHeaderBorder.Name = "pnlScheduleHeaderBorder";
            pnlScheduleHeaderBorder.Size = new Size(984, 1);
            pnlScheduleHeaderBorder.TabIndex = 2;
            // 
            // pnlBillingView
            // 
            pnlBillingView.Controls.Add(lblBillingPlaceholder);
            pnlBillingView.Dock = DockStyle.Fill;
            pnlBillingView.Location = new Point(0, 0);
            pnlBillingView.Margin = new Padding(3, 4, 3, 4);
            pnlBillingView.Name = "pnlBillingView";
            pnlBillingView.Size = new Size(1020, 723);
            pnlBillingView.TabIndex = 1;
            pnlBillingView.Visible = false;
            // 
            // lblBillingPlaceholder
            // 
            lblBillingPlaceholder.Dock = DockStyle.Fill;
            lblBillingPlaceholder.Location = new Point(0, 0);
            lblBillingPlaceholder.Name = "lblBillingPlaceholder";
            lblBillingPlaceholder.Size = new Size(1020, 723);
            lblBillingPlaceholder.TabIndex = 0;
            lblBillingPlaceholder.Text = "Billing — coming soon.";
            lblBillingPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlReportsView
            // 
            pnlReportsView.Controls.Add(lblReportsPlaceholder);
            pnlReportsView.Dock = DockStyle.Fill;
            pnlReportsView.Location = new Point(0, 0);
            pnlReportsView.Margin = new Padding(3, 4, 3, 4);
            pnlReportsView.Name = "pnlReportsView";
            pnlReportsView.Size = new Size(1020, 723);
            pnlReportsView.TabIndex = 2;
            pnlReportsView.Visible = false;
            // 
            // lblReportsPlaceholder
            // 
            lblReportsPlaceholder.Dock = DockStyle.Fill;
            lblReportsPlaceholder.Location = new Point(0, 0);
            lblReportsPlaceholder.Name = "lblReportsPlaceholder";
            lblReportsPlaceholder.Size = new Size(1020, 723);
            lblReportsPlaceholder.TabIndex = 0;
            lblReportsPlaceholder.Text = "Reports — coming soon.";
            lblReportsPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlIntakeView
            // 
            pnlIntakeView.BackColor = Color.FromArgb(245, 247, 250);
            pnlIntakeView.Dock = DockStyle.Fill;
            pnlIntakeView.Location = new Point(0, 0);
            pnlIntakeView.Name = "pnlIntakeView";
            pnlIntakeView.Size = new Size(1020, 723);
            pnlIntakeView.TabIndex = 3;
            pnlIntakeView.Visible = false;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.Controls.Add(btnNewService);
            pnlSidebar.Controls.Add(btnNewClient);
            pnlSidebar.Controls.Add(pnlSidebarBorder);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(3, 4, 3, 4);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(123, 723);
            pnlSidebar.TabIndex = 1;
            // 
            // btnNewService
            // 
            btnNewService.Location = new Point(14, 27);
            btnNewService.Margin = new Padding(3, 4, 3, 4);
            btnNewService.Name = "btnNewService";
            btnNewService.Size = new Size(96, 96);
            btnNewService.TabIndex = 0;
            btnNewService.Text = "+\nNew Service";
            btnNewService.Click += btnNewService_Click;
            // 
            // btnNewClient
            // 
            btnNewClient.Location = new Point(14, 144);
            btnNewClient.Margin = new Padding(3, 4, 3, 4);
            btnNewClient.Name = "btnNewClient";
            btnNewClient.Size = new Size(96, 96);
            btnNewClient.TabIndex = 1;
            btnNewClient.Text = "👤\nNew Client";
            btnNewClient.Click += btnNewDog_Click;
            // 
            // pnlSidebarBorder
            // 
            pnlSidebarBorder.Dock = DockStyle.Right;
            pnlSidebarBorder.Location = new Point(122, 0);
            pnlSidebarBorder.Margin = new Padding(3, 4, 3, 4);
            pnlSidebarBorder.Name = "pnlSidebarBorder";
            pnlSidebarBorder.Size = new Size(1, 723);
            pnlSidebarBorder.TabIndex = 3;
            // 
            // MainDashboardWalkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 867);
            Controls.Add(pnlBody);
            Controls.Add(pnlNav);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1026, 784);
            Name = "MainDashboardWalkerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PawsTrack";
            pnlHeader.ResumeLayout(false);
            pnlNav.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            pnlScheduleView.ResumeLayout(false);
            pnlScheduleHeader.ResumeLayout(false);
            pnlBillingView.ResumeLayout(false);
            pnlReportsView.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
