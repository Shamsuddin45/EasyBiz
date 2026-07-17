using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EasyBiz
{
    public enum AppTheme
    {
        Light,
        Dark,
        OceanBlue,
        ForestGreen,
        Sepia,
        Pinkish,
        WarmHoney,
        RedRose
    }

    public class ThemePalette
    {
        public Color FormBackColor;
        public Color PanelBackColor;
        public Color ForeColor;
        public Color ControlBackColor;
        public Color ControlForeColor;
        public Color MenuBackColor;
        public Color MenuForeColor;
        public Color GridHeaderBackColor;
        public Color GridHeaderForeColor;
        public Color GridAltRowBackColor;
        public Color GridBackColor;
        public Color GridForeColor;
        public Color AccentColor; // used for swatch previews, etc.
    }

    /// <summary>
    /// App-wide theme engine. Palettes are baked in (no external files); the
    /// chosen theme name is persisted in a small AppSettings key/value table
    /// that this class creates for itself the first time it's needed.
    /// </summary>
    public static class ThemeManager
    {
        public static AppTheme CurrentTheme { get; private set; } = AppTheme.Light;

        /// <summary>Raised whenever SaveTheme() changes the active theme.</summary>
        public static event EventHandler ThemeChanged;

        private static readonly Dictionary<AppTheme, ThemePalette> _palettes = new()
        {
            [AppTheme.Light] = new ThemePalette
            {
                FormBackColor = Color.FromArgb(245, 246, 248),
                PanelBackColor = Color.FromArgb(245, 246, 248),
                ForeColor = Color.FromArgb(33, 37, 41),
                ControlBackColor = Color.White,
                ControlForeColor = Color.FromArgb(33, 37, 41),
                MenuBackColor = Color.FromArgb(245, 246, 248),
                MenuForeColor = Color.Black,
                GridHeaderBackColor = Color.FromArgb(52, 152, 219),
                GridHeaderForeColor = Color.White,
                GridAltRowBackColor = Color.FromArgb(248, 249, 250),
                GridBackColor = Color.White,
                GridForeColor = Color.Black,
                AccentColor = Color.FromArgb(52, 152, 219)
            },
            [AppTheme.Dark] = new ThemePalette
            {
                FormBackColor = Color.FromArgb(32, 34, 37),
                PanelBackColor = Color.FromArgb(40, 42, 46),                
                ForeColor = Color.Gainsboro,
                ControlBackColor = Color.FromArgb(54, 57, 62),
                ControlForeColor = Color.Gainsboro,
                MenuBackColor = Color.FromArgb(40, 42, 46),
                MenuForeColor = Color.Gainsboro,
                GridHeaderBackColor = Color.FromArgb(20, 21, 23),
                GridHeaderForeColor = Color.White,
                GridAltRowBackColor = Color.FromArgb(48, 50, 54),
                GridBackColor = Color.FromArgb(40, 42, 46),
                GridForeColor = Color.Gainsboro,
                AccentColor = Color.FromArgb(90, 130, 200)
            },
            [AppTheme.OceanBlue] = new ThemePalette
            {
                FormBackColor = Color.FromArgb(230, 240, 248),
                PanelBackColor = Color.FromArgb(230, 240, 248),
                ForeColor = Color.FromArgb(15, 40, 65),
                ControlBackColor = Color.White,
                ControlForeColor = Color.FromArgb(15, 40, 65),
                MenuBackColor = Color.FromArgb(30, 58, 95),
                MenuForeColor = Color.White,
                GridHeaderBackColor = Color.FromArgb(30, 58, 95),
                GridHeaderForeColor = Color.White,
                GridAltRowBackColor = Color.FromArgb(220, 235, 245),
                GridBackColor = Color.White,
                GridForeColor = Color.FromArgb(15, 40, 65),
                AccentColor = Color.FromArgb(30, 58, 95)
            },
            [AppTheme.ForestGreen] = new ThemePalette
            {
                FormBackColor = Color.FromArgb(235, 245, 237),
                PanelBackColor = Color.FromArgb(235, 245, 237),
                ForeColor = Color.FromArgb(20, 50, 30),
                ControlBackColor = Color.White,
                ControlForeColor = Color.FromArgb(20, 50, 30),
                MenuBackColor = Color.FromArgb(27, 77, 46),
                MenuForeColor = Color.White,
                GridHeaderBackColor = Color.FromArgb(27, 77, 46),
                GridHeaderForeColor = Color.White,
                GridAltRowBackColor = Color.FromArgb(224, 240, 227),
                GridBackColor = Color.White,
                GridForeColor = Color.FromArgb(20, 50, 30),
                AccentColor = Color.FromArgb(27, 77, 46)
            },
            [AppTheme.Sepia] = new ThemePalette
            {
                FormBackColor = Color.FromArgb(244, 236, 216),
                PanelBackColor = Color.FromArgb(244, 236, 216),
                ForeColor = Color.FromArgb(70, 50, 30),
                ControlBackColor = Color.FromArgb(253, 246, 227),
                ControlForeColor = Color.FromArgb(70, 50, 30),
                MenuBackColor = Color.FromArgb(120, 90, 55),
                MenuForeColor = Color.White,
                GridHeaderBackColor = Color.FromArgb(120, 90, 55),
                GridHeaderForeColor = Color.White,
                GridAltRowBackColor = Color.FromArgb(238, 227, 200),
                GridBackColor = Color.FromArgb(253, 246, 227),
                GridForeColor = Color.FromArgb(70, 50, 30),
                AccentColor = Color.FromArgb(120, 90, 55)
            },
            [AppTheme.Pinkish] = new ThemePalette
            {
                FormBackColor = Color.FromArgb(253, 242, 245),      // Soft blush pink
                PanelBackColor = Color.FromArgb(253, 242, 245),     // Soft blush pink
                ForeColor = Color.FromArgb(75, 25, 45),            // Deep berry text (high contrast)
                ControlBackColor = Color.White,                   // Clean white for inputs/cards
                ControlForeColor = Color.FromArgb(75, 25, 45),     // Deep berry text
                MenuBackColor = Color.FromArgb(180, 50, 90),       // Vibrant deep magenta/rose
                MenuForeColor = Color.White,                      // White menu text
                GridHeaderBackColor = Color.FromArgb(180, 50, 90), // Vibrant deep magenta/rose
                GridHeaderForeColor = Color.White,                 // White header text
                GridAltRowBackColor = Color.FromArgb(248, 222, 230),  // Light muted rose highlight
                GridBackColor = Color.White,                      // White main grid rows
                GridForeColor = Color.FromArgb(75, 25, 45),     // Deep berry text
                AccentColor = Color.FromArgb(180, 50, 90)          // Primary rose accent
            },
            [AppTheme.WarmHoney] = new ThemePalette
            {
                FormBackColor = Color.FromArgb(254, 250, 238),      // Pale vanilla cream
                PanelBackColor = Color.FromArgb(254, 250, 238),     // Pale vanilla cream
                ForeColor = Color.FromArgb(55, 45, 20),            // Deep golden-brown text
                ControlBackColor = Color.White,                   // Clean white for inputs/cards
                ControlForeColor = Color.FromArgb(55, 45, 20),     // Deep golden-brown text
                MenuBackColor = Color.FromArgb(195, 125, 15),      // Warm rich amber/gold
                MenuForeColor = Color.White,                      // White menu text
                GridHeaderBackColor = Color.FromArgb(195, 125, 15), // Warm rich amber/gold
                GridHeaderForeColor = Color.White,                 // White header text
                GridAltRowBackColor = Color.FromArgb(250, 238, 200),  // Light butter-yellow tint
                GridBackColor = Color.White,                      // White main grid rows
                GridForeColor = Color.FromArgb(55, 45, 20),     // Deep golden-brown text
                AccentColor = Color.FromArgb(195, 125, 15)          // Primary amber accent
            },
            [AppTheme.RedRose] = new ThemePalette
            {
                FormBackColor = Color.FromArgb(253, 242, 243),      // Soft rose-tinted blush
                PanelBackColor = Color.FromArgb(253, 242, 243),     // Soft rose-tinted blush
                ForeColor = Color.FromArgb(60, 20, 30),            // Deep wine charcoal text
                ControlBackColor = Color.White,                   // Clean white for inputs/cards
                ControlForeColor = Color.FromArgb(60, 20, 30),     // Deep wine charcoal text
                MenuBackColor = Color.FromArgb(165, 25, 45),       // Rich crimson red
                MenuForeColor = Color.White,                      // White menu text
                GridHeaderBackColor = Color.FromArgb(165, 25, 45), // Rich crimson red
                GridHeaderForeColor = Color.White,                 // White header text
                GridAltRowBackColor = Color.FromArgb(248, 218, 222),  // Delicate rose petal tint
                GridBackColor = Color.White,                      // White main grid rows
                GridForeColor = Color.FromArgb(60, 20, 30),     // Deep wine charcoal text
                AccentColor = Color.FromArgb(165, 25, 45)          // Primary rose crimson accent
            }
        };

        public static ThemePalette Current => _palettes[CurrentTheme];
        public static ThemePalette PaletteFor(AppTheme theme) => _palettes[theme];
        public static IEnumerable<AppTheme> AllThemes => _palettes.Keys;

        public static string FriendlyName(AppTheme theme) => theme switch
        {
            AppTheme.OceanBlue => "Ocean Blue",
            AppTheme.ForestGreen => "Forest Green",
            AppTheme.Sepia => "Sepia",
            AppTheme.Pinkish => "Pinkish",
            AppTheme.WarmHoney => "Warm Honey",
            AppTheme.RedRose => "Red Rose",
            _ => theme.ToString()
        };

        // ── Persistence ──────────────────────────────────────────────────
        private const string SettingKey = "AppTheme";

        private static void EnsureSettingsTable()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS AppSettings (
                    SettingKey   TEXT PRIMARY KEY,
                    SettingValue TEXT
                );";
            cmd.ExecuteNonQuery();
        }

        /// <summary>Call once at app startup (MainForm constructor) before applying.</summary>
        public static void LoadSavedTheme()
        {
            EnsureSettingsTable();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT SettingValue FROM AppSettings WHERE SettingKey = @k";
            cmd.Parameters.AddWithValue("@k", SettingKey);
            var result = cmd.ExecuteScalar();
            if (result != null && Enum.TryParse<AppTheme>(result.ToString(), out var saved))
                CurrentTheme = saved;
        }

        public static void SaveTheme(AppTheme theme)
        {
            CurrentTheme = theme;
            EnsureSettingsTable();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO AppSettings (SettingKey, SettingValue) VALUES (@k, @v)
                    ON CONFLICT(SettingKey) DO UPDATE SET SettingValue = @v";
                cmd.Parameters.AddWithValue("@k", SettingKey);
                cmd.Parameters.AddWithValue("@v", theme.ToString());
                cmd.ExecuteNonQuery();
            }

            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }

        // ── Applying to a control tree ───────────────────────────────────

        /// <summary>Recursively repaints a form (or any control) with the active theme.</summary>
        public static void ApplyTheme(Control root)
        {
            ApplyToControl(root, Current);
        }

        private static void ApplyToControl(Control control, ThemePalette p)
        {
            switch (control)
            {
                case Form form:
                    form.BackColor = p.FormBackColor;
                    break;

                case MenuStrip menu:
                    menu.BackColor = p.MenuBackColor;
                    menu.ForeColor = p.MenuForeColor;
                    break;

                case GroupBox groupBox:
                    groupBox.BackColor = p.PanelBackColor;
                    groupBox.ForeColor = p.ForeColor;
                    break;

                case TabPage tabPage:
                    tabPage.BackColor = p.PanelBackColor;
                    tabPage.ForeColor = p.ForeColor;
                    break;

                case FlowLayoutPanel flow:
                    flow.BackColor = p.PanelBackColor;
                    break;

                case Panel panel:
                    panel.BackColor = p.PanelBackColor;
                    break;

                case Label label:
                    label.ForeColor = p.ForeColor;
                    break;

                case TextBox textBox:
                    // Leave read-only "display" fields (balances, totals) alone —
                    // they often carry semantic colors (red/green) set by the form itself.
                    if (!textBox.ReadOnly)
                    {
                        textBox.BackColor = p.ControlBackColor;
                        textBox.ForeColor = p.ControlForeColor;
                    }
                    break;

                case ComboBox comboBox:
                    comboBox.BackColor = p.ControlBackColor;
                    comboBox.ForeColor = p.ControlForeColor;
                    break;

                case NumericUpDown numeric:
                    numeric.BackColor = p.ControlBackColor;
                    numeric.ForeColor = p.ControlForeColor;
                    break;

                case DataGridView grid:
                    ApplyToGrid(grid, p);
                    break;

                case CheckedListBox checkListBox:
                    checkListBox.BackColor = p.ControlBackColor;
                    checkListBox.ForeColor = p.ControlForeColor;
                    break;  
                  
                case CheckBox checkBox:
                    checkBox.BackColor = p.PanelBackColor;
                    checkBox.ForeColor = p.ForeColor;
                    break;

                case DateTimePicker dateTimePicker:
                    dateTimePicker.BackColor = p.ControlBackColor;
                    dateTimePicker.ForeColor = p.ControlForeColor;
                    break;

                case CustomButton:
                    // Save/Update/Delete/Close buttons carry deliberate semantic
                    // colors (green/orange/red) — themes don't override those.
                    break;
            }

            foreach (Control child in control.Controls)
                ApplyToControl(child, p);
        }

        private static void ApplyToGrid(DataGridView grid, ThemePalette p)
        {
            grid.BackgroundColor = p.GridBackColor;
            grid.DefaultCellStyle.BackColor = p.GridBackColor;
            grid.DefaultCellStyle.ForeColor = p.GridForeColor;
            grid.AlternatingRowsDefaultCellStyle.BackColor = p.GridAltRowBackColor;
            grid.ColumnHeadersDefaultCellStyle.BackColor = p.GridHeaderBackColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = p.GridHeaderForeColor;
        }
    }
}