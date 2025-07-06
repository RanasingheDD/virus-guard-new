using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace VirusGuard
{
    public partial class Setting : Form
    {

        public CheckBox sound => guna2CheckBox2;

        public Setting()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Setting_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Format = DateTimePickerFormat.Custom;
            guna2DateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void LoadSettings()
        {
            guna2DateTimePicker1.Format = DateTimePickerFormat.Custom;
            guna2DateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            string path = "settings.txt";
            if (File.Exists(path))
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);
                    if (lines.Length >= 3)
                    {
                        guna2CheckBox2.Checked = bool.Parse(lines[0]);
                        guna2ToggleSwitch1.Checked = bool.Parse(lines[1]);
                        guna2DateTimePicker1.Value = DateTime.Parse(lines[2]);
                        guna2DateTimePicker2.Value = DateTime.Parse(lines[3]);
                        guna2ToggleSwitch2.Checked = bool.Parse((string)lines[4]);
                        guna2ToggleSwitch3.Checked = bool.Parse((string)lines[5]);
                        guna2ToggleSwitch4.Checked = bool.Parse((string)lines[6]);
                        guna2CheckBox1.Checked = bool.Parse((string)lines[7]);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load settings:\n" + ex.Message);
                }
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
            ;
        }


        private void SetStartup(bool enable)
        {
            string appName = "VirusGuard"; // Name you want in startup registry
            string exePath = Application.ExecutablePath;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
            {
                key.SetValue(appName, exePath); // Add app to startup
            }
            else
            {
                if (key.GetValue(appName) != null)
                    key.DeleteValue(appName); // Remove app from startup
            }
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
        {
            SetStartup(guna2ToggleSwitch1.Checked);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string path = "settings.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(guna2CheckBox2.Checked);         // sound checkbox
                writer.WriteLine(guna2ToggleSwitch1.Checked);     // startup
                writer.WriteLine(guna2DateTimePicker1.Value);     // datetime
                writer.WriteLine(guna2DateTimePicker2.Value);
                writer.WriteLine(guna2ToggleSwitch2.Checked);
                writer.WriteLine(guna2ToggleSwitch3.Checked);
                writer.WriteLine(guna2ToggleSwitch4.Checked);
                writer.WriteLine(guna2CheckBox1.Checked);
            }

            MessageBox.Show("Settings saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            string path = "settings.txt";
            if (File.Exists(path))
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);
                    if (lines.Length >= 3)
                    {
                        guna2CheckBox2.Checked = false;
                        guna2ToggleSwitch1.Checked = false;
                        guna2DateTimePicker1.Value = DateTime.Now;
                        guna2DateTimePicker2.Value = DateTime.Now;
                        guna2ToggleSwitch2.Checked = false;
                        guna2ToggleSwitch3.Checked = false;
                        guna2ToggleSwitch4.Checked = false;
                        guna2CheckBox1.Checked = false;

                    }
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine(guna2CheckBox2.Checked);         // sound checkbox
                        writer.WriteLine(guna2ToggleSwitch1.Checked);     // startup
                        writer.WriteLine(guna2DateTimePicker1.Value);     // datetime
                        writer.WriteLine(guna2DateTimePicker2.Value);
                        writer.WriteLine(guna2ToggleSwitch2.Checked);
                        writer.WriteLine(guna2ToggleSwitch3.Checked);
                        writer.WriteLine(guna2ToggleSwitch4.Checked);
                        writer.WriteLine(guna2CheckBox1.Checked);
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Failed to load settings:\n" + ex.Message);
                }
            }
        }
    }
}