using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace EasyBiz.Forms
{
    /// <summary>
    /// Developer/admin utility form: run ad-hoc SQL against the EasyBiz SQLite database
    /// to inspect data. SELECT statements populate the grid; write statements
    /// (INSERT/UPDATE/DELETE/DDL) are blocked unless "Allow writes" is checked.
    ///
    /// Wire this up from a menu item (e.g. Tools > SQL Query Runner) that is only
    /// visible to admin users — this form has no business-logic guardrails of its own,
    /// so it should not be reachable by regular users.
    /// </summary>
    public partial class SqlQueryRunnerForm : Form
    {
        private readonly List<string> _history = new List<string>();
        private DataTable _lastResult;

        public SqlQueryRunnerForm()
        {
            InitializeComponent();
            BeautifyGrid(dgvResults); // existing app-wide grid styling helper
            ThemeManager.ApplyTheme(this); // existing app-wide theming helper
        }

        private void txtQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.Enter))
            {
                e.SuppressKeyPress = true;
                ExecuteQuery();
            }
        }

        private void btnExecute_Click(object sender, EventArgs e) => ExecuteQuery();

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuery.Clear();
            dgvResults.DataSource = null;
            _lastResult = null;
            lblStatus.Text = "Ready";
            lblRowCount.Text = "0 rows";
            lblElapsed.Text = "0 ms";
            txtQuery.Focus();
        }

        private void cboRecentQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRecentQueries.SelectedItem is string sql)
                txtQuery.Text = sql;
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (_lastResult == null || _lastResult.Rows.Count == 0)
            {
                MessageBox.Show("Run a SELECT query first — nothing to export.", "Export CSV",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                FileName = $"query_result_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            })
            {
                if (sfd.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    ExportToCsv(_lastResult, sfd.FileName);
                    MessageBox.Show("Exported successfully.", "Export CSV",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}", "Export CSV",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExecuteQuery()
        {
            string sql = txtQuery.Text.Trim();
            if (string.IsNullOrWhiteSpace(sql))
            {
                lblStatus.Text = "Enter a query first.";
                return;
            }

            bool isSelect = IsSelectLikeStatement(sql);

            if (!isSelect && !chkAllowWrites.Checked)
            {
                MessageBox.Show(
                    "This looks like a write statement (INSERT/UPDATE/DELETE/DDL/etc).\n\n" +
                    "Tick \"Allow INSERT / UPDATE / DELETE / DDL\" if you really mean to modify the database.",
                    "Write statement blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isSelect && chkAllowWrites.Checked)
            {
                var confirm = MessageBox.Show(
                    "This statement will modify the database and cannot be undone from here.\n\nRun it anyway?",
                    "Confirm write", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;
            }

            btnExecute.Enabled = false;
            lblStatus.Text = "Running...";
            Application.DoEvents();

            var sw = Stopwatch.StartNew();
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = 30;

                        if (isSelect)
                        {
                            var table = new DataTable();
                            using (var reader = cmd.ExecuteReader())
                            {
                                table.Load(reader);
                            }

                            _lastResult = table;
                            dgvResults.DataSource = table;
                            lblRowCount.Text = $"{table.Rows.Count} row(s)";
                            lblStatus.Text = "Query OK.";
                        }
                        else
                        {
                            int affected = cmd.ExecuteNonQuery();
                            dgvResults.DataSource = null;
                            _lastResult = null;
                            lblRowCount.Text = $"{affected} row(s) affected";
                            lblStatus.Text = "Statement executed.";
                        }
                    }
                }

                AddToHistory(sql);
            }
            catch (Exception ex)
            {
                dgvResults.DataSource = null;
                _lastResult = null;
                lblRowCount.Text = "0 rows";
                lblStatus.Text = "Error — see details.";
                MessageBox.Show(ex.Message, "Query failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sw.Stop();
                lblElapsed.Text = $"{sw.ElapsedMilliseconds} ms";
                btnExecute.Enabled = true;
            }
        }

        /// <summary>
        /// Rough classifier: treat SELECT / PRAGMA / EXPLAIN / WITH (CTE) as read-only.
        /// Not bulletproof (e.g. "WITH ... INSERT ..." CTEs writing), which is exactly
        /// why writes still require the explicit checkbox + confirmation above.
        /// </summary>
        private static bool IsSelectLikeStatement(string sql)
        {
            string trimmed = sql.TrimStart();
            // strip leading SQL comments so "-- note\nSELECT ..." still classifies correctly
            while (trimmed.StartsWith("--"))
            {
                int nl = trimmed.IndexOf('\n');
                if (nl < 0) { trimmed = string.Empty; break; }
                trimmed = trimmed.Substring(nl + 1).TrimStart();
            }

            string upper = trimmed.ToUpperInvariant();
            return upper.StartsWith("SELECT") ||
                   upper.StartsWith("PRAGMA") ||
                   upper.StartsWith("EXPLAIN") ||
                   upper.StartsWith("WITH");
        }

        private void AddToHistory(string sql)
        {
            _history.RemoveAll(h => h == sql);
            _history.Insert(0, sql);
            if (_history.Count > 20) _history.RemoveAt(_history.Count - 1);

            cboRecentQueries.SelectedIndexChanged -= cboRecentQueries_SelectedIndexChanged;
            cboRecentQueries.Items.Clear();
            cboRecentQueries.Items.AddRange(_history.ToArray());
            cboRecentQueries.SelectedIndexChanged += cboRecentQueries_SelectedIndexChanged;
        }

        private static void ExportToCsv(DataTable table, string path)
        {
            var sb = new StringBuilder();

            var headers = new string[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
                headers[i] = CsvEscape(table.Columns[i].ColumnName);
            sb.AppendLine(string.Join(",", headers));

            foreach (DataRow row in table.Rows)
            {
                var fields = new string[table.Columns.Count];
                for (int i = 0; i < table.Columns.Count; i++)
                    fields[i] = CsvEscape(row[i]?.ToString() ?? string.Empty);
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private static string CsvEscape(string value)
        {
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        // ---------------------------------------------------------------
        // BeautifyGrid is assumed to already exist elsewhere in EasyBiz
        // (per StockReport / other grid-using forms). If this form is the
        // first to reference it from this namespace, either add a
        // `using` for wherever it lives, or delete this call.
        // ---------------------------------------------------------------
        private void BeautifyGrid(DataGridView grid)
        {
            // If EasyBiz already has a shared BeautifyGrid(DataGridView) helper
            // (e.g. a static method on a Utils/ThemeManager class), delete this
            // method body and call that one instead — this is a minimal fallback
            // so the form compiles standalone.
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            grid.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 225, 245);
            grid.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }
    }
}