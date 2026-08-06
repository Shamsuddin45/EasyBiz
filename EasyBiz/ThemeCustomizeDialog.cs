using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EasyBiz
{
    /// <summary>
    /// Lets the user pick a color for every element ThemeManager themes,
    /// then hands the resulting palette back via ResultPalette.
    /// </summary>
    public partial class ThemeCustomizeDialog : Form
    {
        private readonly ThemePalette _palette;

        private readonly List<(string Label, Func<ThemePalette, Color> Get, Action<ThemePalette, Color> Set)> _fields = new()
        {
            ("Form Background",    p => p.FormBackColor,       (p, c) => p.FormBackColor = c),
            ("Panel Background",   p => p.PanelBackColor,      (p, c) => p.PanelBackColor = c),
            ("Text Color",         p => p.ForeColor,           (p, c) => p.ForeColor = c),
            ("Control Background", p => p.ControlBackColor,    (p, c) => p.ControlBackColor = c),
            ("Control Text",       p => p.ControlForeColor,    (p, c) => p.ControlForeColor = c),
            ("Menu Background",    p => p.MenuBackColor,       (p, c) => p.MenuBackColor = c),
            ("Menu Text",          p => p.MenuForeColor,       (p, c) => p.MenuForeColor = c),
            ("Grid Header Back",   p => p.GridHeaderBackColor, (p, c) => p.GridHeaderBackColor = c),
            ("Grid Header Text",   p => p.GridHeaderForeColor, (p, c) => p.GridHeaderForeColor = c),
            ("Grid Alt Row",       p => p.GridAltRowBackColor, (p, c) => p.GridAltRowBackColor = c),
            ("Grid Background",    p => p.GridBackColor,       (p, c) => p.GridBackColor = c),
            ("Grid Text",          p => p.GridForeColor,       (p, c) => p.GridForeColor = c),
            ("Accent Color",       p => p.AccentColor,         (p, c) => p.AccentColor = c),
        };

        public ThemePalette ResultPalette { get; private set; }

        public ThemeCustomizeDialog(ThemePalette startingPalette)
        {
            // Work on a private copy so Cancel never mutates the caller's palette.
            _palette = new ThemePalette
            {
                FormBackColor = startingPalette.FormBackColor,
                PanelBackColor = startingPalette.PanelBackColor,
                ForeColor = startingPalette.ForeColor,
                ControlBackColor = startingPalette.ControlBackColor,
                ControlForeColor = startingPalette.ControlForeColor,
                MenuBackColor = startingPalette.MenuBackColor,
                MenuForeColor = startingPalette.MenuForeColor,
                GridHeaderBackColor = startingPalette.GridHeaderBackColor,
                GridHeaderForeColor = startingPalette.GridHeaderForeColor,
                GridAltRowBackColor = startingPalette.GridAltRowBackColor,
                GridBackColor = startingPalette.GridBackColor,
                GridForeColor = startingPalette.GridForeColor,
                AccentColor = startingPalette.AccentColor
            };

            Text = "Customize Theme";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(380, 40 * _fields.Count + 80);

            BuildRows();
            BuildButtons();
        }

        private void BuildRows()
        {
            int y = 15;
            foreach (var field in _fields)
            {
                var lbl = new Label
                {
                    Text = field.Label,
                    Location = new Point(15, y + 6),
                    Size = new Size(175, 24),
                    Font = new Font("Segoe UI", 9.5F)
                };

                var swatch = new Button
                {
                    Location = new Point(200, y),
                    Size = new Size(150, 32),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = field.Get(_palette),
                    Text = "Change…",
                    Font = new Font("Segoe UI", 9F),
                    Cursor = Cursors.Hand
                };
                swatch.FlatAppearance.BorderColor = Color.DarkGray;
                swatch.ForeColor = ContrastForeColor(swatch.BackColor);

                swatch.Click += (s, e) =>
                {
                    using var dlg = new ColorDialog { Color = field.Get(_palette), FullOpen = true };
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        field.Set(_palette, dlg.Color);
                        swatch.BackColor = dlg.Color;
                        swatch.ForeColor = ContrastForeColor(dlg.Color);
                    }
                };

                Controls.Add(lbl);
                Controls.Add(swatch);
                y += 40;
            }
        }

        private void BuildButtons()
        {
            int y = 40 * _fields.Count + 25;

            var btnSave = new Button
            {
                Text = "Save & Apply",
                DialogResult = DialogResult.OK,
                Location = new Point(160, y),
                Size = new Size(120, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(290, y),
                Size = new Size(80, 32),
                FlatStyle = FlatStyle.Flat
            };

            AcceptButton = btnSave;
            CancelButton = btnCancel;
            btnSave.Click += (s, e) => ResultPalette = _palette;

            Controls.Add(btnSave);
            Controls.Add(btnCancel);
        }

        private static Color ContrastForeColor(Color bg)
        {
            double luminance = (0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B) / 255;
            return luminance > 0.5 ? Color.Black : Color.White;
        }
    }
}