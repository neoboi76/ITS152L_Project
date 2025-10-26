using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FormsUI
{
    public static class UITheme
    {
        // Color Palette
        public static class Colors
        {
            // Primary colors
            public static readonly Color Primary = Color.FromArgb(37, 99, 235);
            public static readonly Color PrimaryDark = Color.FromArgb(29, 78, 216);
            public static readonly Color PrimaryLight = Color.FromArgb(59, 130, 246);

            // Success, Warning, Danger
            public static readonly Color Success = Color.FromArgb(34, 197, 94);
            public static readonly Color Warning = Color.FromArgb(234, 179, 8);
            public static readonly Color Danger = Color.FromArgb(239, 68, 68);

            // Neutral colors
            public static readonly Color White = Color.White;
            public static readonly Color Background = Color.FromArgb(248, 250, 252);
            public static readonly Color Surface = Color.White;
            public static readonly Color Border = Color.FromArgb(226, 232, 240);

            // Text colors
            public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);
            public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139);
            public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);
        }

        // Typography
        public static class Fonts
        {
            public static Font Title => new Font("Segoe UI", 20, FontStyle.Bold);
            public static Font Heading => new Font("Segoe UI", 16, FontStyle.Bold);
            public static Font Subheading => new Font("Segoe UI", 14, FontStyle.Bold);
            public static Font Body => new Font("Segoe UI", 11);
            public static Font BodyBold => new Font("Segoe UI", 11, FontStyle.Bold);
            public static Font Small => new Font("Segoe UI", 9);
            public static Font SmallItalic => new Font("Segoe UI", 9, FontStyle.Italic);
        }

        // Spacing
        public static class Spacing
        {
            public const int XSmall = 4;
            public const int Small = 8;
            public const int Medium = 16;
            public const int Large = 24;
            public const int XLarge = 32;
        }

        // Component Styling Methods
        public static void StylePrimaryButton(Button button)
        {
            button.BackColor = Colors.Primary;
            button.ForeColor = Colors.White;
            button.Font = Fonts.BodyBold;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Height = 40;

            button.MouseEnter += (s, e) => button.BackColor = Colors.PrimaryDark;
            button.MouseLeave += (s, e) => button.BackColor = Colors.Primary;
        }

        public static void StyleSecondaryButton(Button button)
        {
            button.BackColor = Colors.TextMuted;
            button.ForeColor = Colors.White;
            button.Font = Fonts.BodyBold;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Height = 40;

            button.MouseEnter += (s, e) => button.BackColor = Colors.TextSecondary;
            button.MouseLeave += (s, e) => button.BackColor = Colors.TextMuted;
        }

        public static void StyleDangerButton(Button button)
        {
            button.BackColor = Colors.Danger;
            button.ForeColor = Colors.White;
            button.Font = Fonts.BodyBold;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Height = 40;

            Color hoverColor = ControlPaint.Dark(Colors.Danger, 0.1f);
            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = Colors.Danger;
        }

        public static void StyleSuccessButton(Button button)
        {
            button.BackColor = Colors.Success;
            button.ForeColor = Colors.White;
            button.Font = Fonts.BodyBold;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Height = 40;

            Color hoverColor = ControlPaint.Dark(Colors.Success, 0.1f);
            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = Colors.Success;
        }

        public static void StyleTextBox(TextBox textBox)
        {
            textBox.Font = Fonts.Body;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Height = 32;
        }

        public static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.Font = Fonts.Body;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Height = 32;
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Colors.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            // Header style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Colors.TextPrimary;
            dgv.ColumnHeadersDefaultCellStyle.Font = Fonts.BodyBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgv.ColumnHeadersHeight = 45;

            // Cell style
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dgv.DefaultCellStyle.Font = Fonts.Body;
            dgv.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            dgv.RowTemplate.Height = 40;

            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Colors.Background;

            // Grid lines
            dgv.GridColor = Colors.Border;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        public static void StylePanel(Panel panel, bool addShadow = false)
        {
            panel.BackColor = Colors.Surface;
            panel.Padding = new Padding(Spacing.Large);

            if (addShadow)
            {
                // Note: WinForms doesn't have built-in shadow support
                // You can use custom painting or third-party libraries for shadows
            }
        }

        public static void StyleLabel(Label label, bool isHeading = false)
        {
            label.Font = isHeading ? Fonts.Subheading : Fonts.Body;
            label.ForeColor = Colors.TextPrimary;
            label.AutoSize = true;
        }

        public static void StyleLinkLabel(LinkLabel linkLabel)
        {
            linkLabel.Font = Fonts.Small;
            linkLabel.LinkColor = Colors.Primary;
            linkLabel.ActiveLinkColor = Colors.PrimaryDark;
            linkLabel.VisitedLinkColor = Colors.Primary;
        }

        // Helper method to create styled card panels
        public static Panel CreateCard(int x, int y, int width, int height)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Colors.Surface,
                Padding = new Padding(Spacing.Large)
            };
            return card;
        }

        // Helper method to create section headers
        public static Label CreateSectionHeader(string text, int x, int y)
        {
            Label header = new Label
            {
                Text = text,
                Font = Fonts.Subheading,
                ForeColor = Colors.TextPrimary,
                Location = new Point(x, y),
                AutoSize = true
            };
            return header;
        }
    }

    // Extension methods for easy styling
    public static class ControlExtensions
    {
        public static T WithPrimaryButtonStyle<T>(this T button) where T : Button
        {
            UITheme.StylePrimaryButton(button);
            return button;
        }

        public static T WithSecondaryButtonStyle<T>(this T button) where T : Button
        {
            UITheme.StyleSecondaryButton(button);
            return button;
        }

        public static T WithDangerButtonStyle<T>(this T button) where T : Button
        {
            UITheme.StyleDangerButton(button);
            return button;
        }

        public static T WithSuccessButtonStyle<T>(this T button) where T : Button
        {
            UITheme.StyleSuccessButton(button);
            return button;
        }
    }
}
