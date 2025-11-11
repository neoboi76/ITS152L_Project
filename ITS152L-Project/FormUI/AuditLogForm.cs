/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 * 
 * (admin) AuditLogForm class. Main class for dealing with
 * AuditLogForm related operations
 **/


using ItemDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsUI
{
    public partial class AuditLogForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7173/")
        };

        public AuditLogForm(string userName)
        {
            InitializeComponent();
            _currentUserName = userName;
            this.Text = "Audit Log - Teleoplex Inventory System";
            this.Size = new Size(1100, 650);
        }

        private async void AuditLogForm_Load(object sender, EventArgs e)
        {
            await LoadAuditLogs();
        }

        private async Task LoadAuditLogs()
        {
            try
            {
                _allLogs = await _httpClient.GetFromJsonAsync<List<AuditLog>>("api/auditlog/all");
                DisplayLogs(_allLogs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading audit logs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayLogs(IEnumerable<AuditLog> logs)
        {
            if (logs == null) return;

            dgvAuditLog.DataSource = logs.Select(log => new
            {
                log.Id,
                log.Timestamp,
                User = log.UserName,
                log.Action,
                log.Details
            }).OrderByDescending(l => l.Timestamp).ToList();

            dgvAuditLog.Columns["Id"].Visible = false;
            dgvAuditLog.Columns["Timestamp"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
            dgvAuditLog.Columns["Timestamp"].Width = 150;
            dgvAuditLog.Columns["User"].Width = 120;
            dgvAuditLog.Columns["Action"].Width = 100;
            dgvAuditLog.Columns["Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            var filteredLogs = _allLogs.AsEnumerable();

            filteredLogs = filteredLogs.Where(log =>
                log.Timestamp.Date >= dtpFrom.Value.Date &&
                log.Timestamp.Date <= dtpTo.Value.Date
            );

            string selectedFilter = cmbFilterType.SelectedItem?.ToString() ?? "All Actions";
            filteredLogs = selectedFilter switch
            {
                "Added Only" => filteredLogs.Where(l => l.Action == "Added"),
                "Updated Only" => filteredLogs.Where(l => l.Action == "Updated"),
                "Deleted Only" => filteredLogs.Where(l => l.Action == "Deleted"),
                _ => filteredLogs
            };

            DisplayLogs(filteredLogs);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            cmbFilterType.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            DisplayLogs(_allLogs);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.FileName = $"AuditLog_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var csv = new System.Text.StringBuilder();
                        csv.AppendLine("Timestamp,User,Action,Details");

                        var logs = dgvAuditLog.DataSource as List<dynamic>;
                        if (logs != null)
                        {
                            foreach (var log in logs)
                            {
                                csv.AppendLine($"\"{log.Timestamp:MM/dd/yyyy HH:mm:ss}\"," +
                                             $"\"{log.User}\"," +
                                             $"\"{log.Action}\"," +
                                             $"\"{log.Details}\"");
                            }
                        }

                        System.IO.File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                        MessageBox.Show("Audit log exported successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
