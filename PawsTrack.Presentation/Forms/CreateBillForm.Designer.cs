namespace PawsTrack.Presentation.Forms
{
    partial class CreateBillForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel      pnlCard;
        private System.Windows.Forms.Label      lblTitle;
        private System.Windows.Forms.Panel      pnlSep;
        private System.Windows.Forms.Label      lblOwnerCaption;
        private System.Windows.Forms.Label      lblOwnerValue;
        private System.Windows.Forms.Label      lblDogCaption;
        private System.Windows.Forms.Label      lblDogValue;
        private System.Windows.Forms.Label      lblDateCaption;
        private System.Windows.Forms.Label      lblDateValue;
        private System.Windows.Forms.Label      lblDurationCaption;
        private System.Windows.Forms.Label      lblDurationValue;
        private System.Windows.Forms.Panel      pnlSep2;
        private System.Windows.Forms.Label      lblRatePerHour;
        private System.Windows.Forms.NumericUpDown numRatePerHour;
        private System.Windows.Forms.Label      lblDiscount;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label      lblTotal;
        private System.Windows.Forms.Label      lblError;
        private System.Windows.Forms.Button     btnCreateBill;
        private System.Windows.Forms.Button     btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard         = new Panel();
            lblTitle        = new Label();
            pnlSep          = new Panel();
            lblOwnerCaption    = new Label();
            lblOwnerValue      = new Label();
            lblDogCaption      = new Label();
            lblDogValue        = new Label();
            lblDateCaption     = new Label();
            lblDateValue       = new Label();
            lblDurationCaption = new Label();
            lblDurationValue   = new Label();
            pnlSep2         = new Panel();
            lblRatePerHour  = new Label();
            numRatePerHour  = new NumericUpDown();
            lblDiscount     = new Label();
            numDiscount     = new NumericUpDown();
            lblTotal        = new Label();
            lblError        = new Label();
            btnCreateBill   = new Button();
            btnCancel       = new Button();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRatePerHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            SuspendLayout();
            //
            // pnlCard
            //
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(pnlSep);
            pnlCard.Controls.Add(lblOwnerCaption);
            pnlCard.Controls.Add(lblOwnerValue);
            pnlCard.Controls.Add(lblDogCaption);
            pnlCard.Controls.Add(lblDogValue);
            pnlCard.Controls.Add(lblDateCaption);
            pnlCard.Controls.Add(lblDateValue);
            pnlCard.Controls.Add(lblDurationCaption);
            pnlCard.Controls.Add(lblDurationValue);
            pnlCard.Controls.Add(pnlSep2);
            pnlCard.Controls.Add(lblRatePerHour);
            pnlCard.Controls.Add(numRatePerHour);
            pnlCard.Controls.Add(lblDiscount);
            pnlCard.Controls.Add(numDiscount);
            pnlCard.Controls.Add(lblTotal);
            pnlCard.Controls.Add(lblError);
            pnlCard.Controls.Add(btnCreateBill);
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Location = new Point(20, 20);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(420, 440);
            pnlCard.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.Location = new Point(16, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(388, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Bill";
            //
            // pnlSep
            //
            pnlSep.Location = new Point(16, 50);
            pnlSep.Name = "pnlSep";
            pnlSep.Size = new Size(388, 1);
            pnlSep.TabIndex = 1;
            //
            // lblOwnerCaption
            //
            lblOwnerCaption.Location = new Point(16, 60);
            lblOwnerCaption.Name = "lblOwnerCaption";
            lblOwnerCaption.Size = new Size(100, 22);
            lblOwnerCaption.TabIndex = 2;
            lblOwnerCaption.Text = "Owner:";
            //
            // lblOwnerValue
            //
            lblOwnerValue.Location = new Point(124, 60);
            lblOwnerValue.Name = "lblOwnerValue";
            lblOwnerValue.Size = new Size(280, 22);
            lblOwnerValue.TabIndex = 3;
            //
            // lblDogCaption
            //
            lblDogCaption.Location = new Point(16, 86);
            lblDogCaption.Name = "lblDogCaption";
            lblDogCaption.Size = new Size(100, 22);
            lblDogCaption.TabIndex = 4;
            lblDogCaption.Text = "Dog:";
            //
            // lblDogValue
            //
            lblDogValue.Location = new Point(124, 86);
            lblDogValue.Name = "lblDogValue";
            lblDogValue.Size = new Size(280, 22);
            lblDogValue.TabIndex = 5;
            //
            // lblDateCaption
            //
            lblDateCaption.Location = new Point(16, 112);
            lblDateCaption.Name = "lblDateCaption";
            lblDateCaption.Size = new Size(100, 22);
            lblDateCaption.TabIndex = 6;
            lblDateCaption.Text = "Date:";
            //
            // lblDateValue
            //
            lblDateValue.Location = new Point(124, 112);
            lblDateValue.Name = "lblDateValue";
            lblDateValue.Size = new Size(280, 22);
            lblDateValue.TabIndex = 7;
            //
            // lblDurationCaption
            //
            lblDurationCaption.Location = new Point(16, 138);
            lblDurationCaption.Name = "lblDurationCaption";
            lblDurationCaption.Size = new Size(100, 22);
            lblDurationCaption.TabIndex = 8;
            lblDurationCaption.Text = "Duration:";
            //
            // lblDurationValue
            //
            lblDurationValue.Location = new Point(124, 138);
            lblDurationValue.Name = "lblDurationValue";
            lblDurationValue.Size = new Size(280, 22);
            lblDurationValue.TabIndex = 9;
            //
            // pnlSep2
            //
            pnlSep2.Location = new Point(16, 170);
            pnlSep2.Name = "pnlSep2";
            pnlSep2.Size = new Size(388, 1);
            pnlSep2.TabIndex = 10;
            //
            // lblRatePerHour
            //
            lblRatePerHour.Location = new Point(16, 180);
            lblRatePerHour.Name = "lblRatePerHour";
            lblRatePerHour.Size = new Size(120, 22);
            lblRatePerHour.TabIndex = 11;
            lblRatePerHour.Text = "Rate per hour ($):";
            //
            // numRatePerHour
            //
            numRatePerHour.DecimalPlaces = 2;
            numRatePerHour.Location = new Point(160, 178);
            numRatePerHour.Maximum = 9999;
            numRatePerHour.Minimum = 0;
            numRatePerHour.Name = "numRatePerHour";
            numRatePerHour.Size = new Size(120, 27);
            numRatePerHour.TabIndex = 12;
            numRatePerHour.ValueChanged += numRatePerHour_ValueChanged;
            //
            // lblDiscount
            //
            lblDiscount.Location = new Point(16, 216);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(120, 22);
            lblDiscount.TabIndex = 13;
            lblDiscount.Text = "Discount ($):";
            //
            // numDiscount
            //
            numDiscount.DecimalPlaces = 2;
            numDiscount.Location = new Point(160, 214);
            numDiscount.Maximum = 9999;
            numDiscount.Minimum = 0;
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(120, 27);
            numDiscount.TabIndex = 14;
            numDiscount.ValueChanged += numDiscount_ValueChanged;
            //
            // lblTotal
            //
            lblTotal.Location = new Point(16, 254);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(388, 30);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total: $0.00";
            //
            // lblError
            //
            lblError.ForeColor = Color.FromArgb(211, 47, 47);
            lblError.Location = new Point(16, 290);
            lblError.Name = "lblError";
            lblError.Size = new Size(388, 22);
            lblError.TabIndex = 16;
            lblError.Visible = false;
            //
            // btnCreateBill
            //
            btnCreateBill.Location = new Point(16, 322);
            btnCreateBill.Name = "btnCreateBill";
            btnCreateBill.Size = new Size(180, 42);
            btnCreateBill.TabIndex = 17;
            btnCreateBill.Text = "Create Bill";
            btnCreateBill.Click += btnCreateBill_Click;
            //
            // btnCancel
            //
            btnCancel.Location = new Point(210, 322);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 42);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            //
            // CreateBillForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 480);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateBillForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Bill";
            pnlCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numRatePerHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ResumeLayout(false);
        }
    }
}
