using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace VirusGuard
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // Initially disable delete button
            delete.Enabled = false;

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void LoadLogs()
        {
            dataGridView1.Columns.Clear(); // Clear any existing columns

            // Add checkbox column
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Select",
                Width = 50,
                Name = "Select"
            };
            dataGridView1.Columns.Add(checkBoxColumn);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (Form1.DetectedLogs.Count > 0)
            {
                foreach (var prop in Form1.DetectedLogs[0].GetType().GetProperties())
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = prop.Name,
                        HeaderText = prop.Name,
                        ReadOnly = true,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    dataGridView1.Columns.Add(col);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Form1.DetectedLogs;

            // Theme
            dataGridView1.BackgroundColor = Color.FromArgb(15, 25, 15);
            dataGridView1.GridColor = Color.FromArgb(40, 60, 40);

            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(30, 50, 30);
            dataGridView1.DefaultCellStyle.ForeColor = Color.LightGreen;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 80, 50);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 60, 40);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            UpdateDeleteButtonState();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.DetectedLogs.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            UpdateDeleteButtonState();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void export_Click(object sender, EventArgs e)
        {
            using (Form reportForm = new Form())
            {
                reportForm.Text = "Export Report - Detected Logs";
                reportForm.Width = 900;
                reportForm.Height = 600;
                reportForm.StartPosition = FormStartPosition.CenterParent;

                try
                {
                    var viewer = new ReportViewer
                    {
                        Dock = DockStyle.Fill,
                        ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                    };

                    viewer.LocalReport.ReportPath = "LogReport.rdlc";

                    // Prepare the data source
                    var bindingSource = new BindingSource { DataSource = Form1.DetectedLogs };

                    var reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("LogDataSet", bindingSource);

                    viewer.LocalReport.DataSources.Clear();
                    viewer.LocalReport.DataSources.Add(reportDataSource);

                    viewer.RefreshReport();
                    reportForm.Controls.Add(viewer);

                    reportForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to generate report:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> rowsToDelete = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    string path = row.Cells[2].Value?.ToString();
                    if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
                    {
                        try
                        {
                            System.IO.File.Delete(path);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to delete file: " + path + "\n" + ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    rowsToDelete.Add(row.Index);
                }
            }

            for (int i = rowsToDelete.Count - 1; i >= 0; i--)
            {
                Form1.DetectedLogs.RemoveAt(rowsToDelete[i]);
            }

            LoadLogs();
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index)
            {
                UpdateDeleteButtonState();
            }
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void UpdateDeleteButtonState()
        {
            bool anyChecked = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    anyChecked = true;
                    break;
                }
            }
            delete.Enabled = anyChecked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.virustotal.com/gui/home/upload",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open browser: " + ex.Message);
            }
        }
    }
}
