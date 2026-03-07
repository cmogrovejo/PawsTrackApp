namespace PawsTrack.Presentation.Helpers
{
    /// <summary>
    /// Centralized UI constants. Changing a color or font here updates the whole application.
    /// Keeps the forms themselves free of magic strings and raw color literals.
    /// </summary>
    internal static class AppStyles
    {
        // --- Brand Colors ---
        public static readonly Color PrimaryColor = Color.FromArgb(52, 107, 161);   // Deep blue
        public static readonly Color AccentColor = Color.FromArgb(255, 138, 61);   // Warm orange (paws!)
        public static readonly Color BackgroundColor = Color.FromArgb(245, 247, 250);  // Off-white
        public static readonly Color SurfaceColor = Color.White;
        public static readonly Color TextPrimary = Color.FromArgb(30, 40, 55);
        public static readonly Color TextSecondary = Color.FromArgb(110, 120, 140);
        public static readonly Color ErrorColor = Color.FromArgb(211, 47, 47);
        public static readonly Color SuccessColor = Color.FromArgb(46, 125, 50);
        public static readonly Color BorderColor = Color.FromArgb(210, 215, 225);

        // --- Fonts ---
        public static readonly Font TitleFont = new Font("Segoe UI", 22f, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font("Segoe UI", 11f, FontStyle.Regular);
        public static readonly Font LabelFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font InputFont = new Font("Segoe UI", 10f, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font SmallFont = new Font("Segoe UI", 8.5f, FontStyle.Regular);

        // --- Dimensions ---
        public const int InputHeight = 38;
        public const int ButtonHeight = 42;
        public const int CornerRadius = 6;
        public const int FormPadding = 40;
        public const int VerticalSpacing = 16;

        /// <summary>
        /// Applies common styling to a Button control to match the app's primary button style.
        /// </summary>
        public static void StylePrimaryButton(Button btn)
        {
            btn.BackColor = PrimaryColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = ButtonFont;
            btn.Height = ButtonHeight;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Applies common styling to a TextBox to match the app's input style.
        /// </summary>
        public static void StyleInput(TextBox txt)
        {
            txt.Font = InputFont;
            txt.Height = InputHeight;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = SurfaceColor;
            txt.ForeColor = TextPrimary;
        }
    }
}
