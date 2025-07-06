using Guna.UI2.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System.Data.SqlClient;
using System.Management;
using System.Media;
using System.Security.Cryptography;
using System.Security.Principal;

namespace VirusGuard
{
    public partial class Form1 : Form
    {
        private Setting setting;

        private NotifyIcon notifyIcon1;
        private FileSystemWatcher realTimeWatcher;
        private bool realTimeEnabled = false;
        private CancellationTokenSource scanCancellationTokenSource;
        private ManagementEventWatcher usbWatcher;
        public static List<VirusLog> DetectedLogs = new List<VirusLog>();
        public Label ActionLabel => action_required;

        public class VirusLog
        {
            public string ScanType { get; set; }
            public string FilePath { get; set; }
            public string DetectionType { get; set; } // e.g., "Heuristic", "Hash Match"
            public string Date { get; set; }
        }


        private readonly HashSet<string> knownMalwareHashes = new HashSet<string>();

        public Form1(Setting setting)
        {
            InitializeComponent();
            this.setting = setting;
            btnToggleRealTime.Click += btnToggleRealTime_Click;
            guna2TileButton1.Click += btnQuickScan_Click;
            guna2TileButton3.Click += btnCustomScan_Click;
            guna2TileButton2.Click += btnFullScan_Click;
            clear.Click += clear_Click;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            StartUSBMonitoring();

            DetectedLogs.Add(new VirusLog
            {
                ScanType = "Quick Scan",
                FilePath = "C:\\Users\\Dell\\Desktop\\test.txt",
                DetectionType = "Trojan",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });

        }
        private void PlayAlertSound()
        {
            SystemSounds.Exclamation.Play();  // plays Windows exclamation sound
                                              // Alternatively, use a custom sound file:
                                              // SoundPlayer player = new SoundPlayer("path_to_your_alert.wav");
                                              // player.Play();
        }
        private void StartUSBMonitoring()
        {
            try
            {
                WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");

                usbWatcher = new ManagementEventWatcher(insertQuery);
                usbWatcher.EventArrived += new EventArrivedEventHandler(USBInserted);
                usbWatcher.Start();

                SafeAppendText("[INFO] USB monitoring started.\n");
            }
            catch (Exception ex)
            {
                SafeAppendText($"[ERROR] USB monitoring failed: {ex.Message}\n");
            }
        }

        private void USBInserted(object sender, EventArrivedEventArgs e)
        {
            try
            {
                string driveLetter = GetLatestUSBDrive();
                if (!string.IsNullOrEmpty(driveLetter))
                {
                    ShowNotification("USB Detected", $"Monitoring USB Drive: {driveLetter}");

                    // Start real-time protection on the USB drive
                    StartRealTimeProtection(driveLetter);
                }
            }
            catch (Exception ex)
            {
                SafeAppendText($"[ERROR] USB handling error: {ex.Message}\n");
            }
        }
        private string GetLatestUSBDrive()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable && drive.IsReady)
                {
                    return drive.RootDirectory.FullName;
                }
            }
            return null;
        }

        private void ShowNotification(string title, string message)
        {
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(3000); // Show for 3 seconds
        }
        private void LoadMalwareHashesFromDB()
        {
            string connectionString = "Data Source=192.168.8.115;Initial Catalog=VirusDB;Persist Security Info=True;User ID=SA;Password=Madushan2002@;";

            string query = "SELECT hash FROM VirusTBL";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string hash = reader["hash"].ToString().ToLowerInvariant();
                            if (!string.IsNullOrWhiteSpace(hash))
                            {
                                knownMalwareHashes.Add(hash);
                            }
                        }
                    }
                }

                SafeAppendText("[INFO] Malware hashes loaded from VirusDB.\n");
            }
            catch (Exception ex)
            {
                SafeAppendText($"[ERROR] Failed to load hashes from database: {ex.Message}\n");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (!IsRunAsAdmin())
            {
                MessageBox.Show("Please run VirusGuard as Administrator to scan system files completely.",
                    "Administrator Rights Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadMalwareHashesFromDB();
            StartRealTimeProtection(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
        }
        private bool IsRunAsAdmin()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
        private void StartRealTimeProtection(string pathToWatch)
        {
            try
            {
                // Stop existing watcher if active
                StopRealTimeProtection();

                realTimeWatcher = new FileSystemWatcher
                {
                    Path = pathToWatch,
                    IncludeSubdirectories = true,
                    Filter = "*.*",
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size,
                    EnableRaisingEvents = true
                };

                // Attach handlers
                realTimeWatcher.Created += OnFileDetected;
                realTimeWatcher.Changed += OnFileDetected;

                richTextBox1.AppendText($"[INFO] Real-Time Protection is monitoring: {pathToWatch}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"[ERROR] Failed to start real-time protection: {ex.Message}\n");
            }
        }

        private void StopRealTimeProtection()
        {
            try
            {
                if (realTimeWatcher != null)
                {
                    realTimeWatcher.EnableRaisingEvents = false;
                    realTimeWatcher.Created -= OnFileDetected;
                    realTimeWatcher.Changed -= OnFileDetected;
                    realTimeWatcher.Dispose();
                    realTimeWatcher = null;

                    richTextBox1.AppendText("[INFO] Real-Time Protection stopped.\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"[ERROR] Failed to stop real-time protection: {ex.Message}\n");
            }
        }

        private void OnFileDetected(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (File.Exists(e.FullPath)) // Only scan if it's a file
                {
                    ScanFile(e.FullPath, "[REAL-TIME]");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"[ERROR] Real-time scan failed: {ex.Message}\n");
            }
        }
        private bool ScanFile(string filePath, string prefix)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string hash = ComputeSHA256(filePath);
                    string detectionType = "";

                    if (knownMalwareHashes.Contains(hash))
                    {
                        detectionType = "Hash Match";
                        SafeAppendText($"{prefix} Infected file detected (local hash match): {filePath}\n");
                    }
                    else if (IsSuspicious(filePath))
                    {
                        detectionType = "Heuristic";
                        SafeAppendText($"{prefix} Suspicious file detected (heuristic): {filePath}\n");
                    }

                    if (!string.IsNullOrEmpty(detectionType))
                    {
                        DetectedLogs.Add(new VirusLog
                        {
                            ScanType = prefix,
                            FilePath = filePath,
                            DetectionType = detectionType,
                            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });

                        return true;
                    }
                }
            }
            catch { }

            return false;
        }



        private bool IsSuspicious(string filePath)
        {
            try
            {
                string name = Path.GetFileName(filePath).ToLower();
                string ext = Path.GetExtension(filePath).ToLower();
                long size = new FileInfo(filePath).Length;

                string[] dangerousExts = { ".exe", ".bat", ".dll", ".vbs", ".scr", ".cmd" };
                if (Array.Exists(dangerousExts, e => e == ext))
                {
                    if (name.Contains("setup") || name.Contains("crack") || name.Contains("keygen") || name.Contains(".jpg.exe"))
                        return true;

                    if (size < 10 * 1024 || size > 500 * 1024 * 1024)
                        return true;
                }
            }
            catch { }

            return false;
        }

        private void btnQuickScan_Click(object sender, EventArgs e)
        {
            string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            ScanDirectory(systemPath, "Quick Scan");
        }

        private void btnCustomScan_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    ScanDirectory(dialog.SelectedPath, "Custom Scan");
            }
        }

        private void btnFullScan_Click(object sender, EventArgs e)
        {
            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory);
            ScanDirectory(rootDrive, "Full Scan");
        }

        private async void ScanDirectory(string path, string scanType)
        {
            int threatCount = 0;

            progressBar1.Invoke(new Action(() =>
            {
                progressBar1.Value = 0;
                label2.Visible = false;
                progressBar1.Visible = true;
                richTextBox1.Visible = true;
                Scan.Visible = true;
                btnStop.Visible = true;
                action_required.Visible = false;
                guna2TileButton1.Visible = false;
                guna2TileButton2.Visible = false;
                guna2TileButton3.Visible = false;
                label3.Visible = false;
            }));

            label1.Visible = false;
            scanCancellationTokenSource?.Cancel(); // cancel any existing scan
            scanCancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = scanCancellationTokenSource.Token;

            SafeClearText();
            SafeAppendText($"{scanType} started on: {path}\n\n");

            SetScanButtonsEnabled(false);

            try
            {
                await Task.Run(() =>
                {
                    List<string> allFiles = new List<string>();

                    // Manually walk directories to handle errors
                    Queue<string> dirs = new Queue<string>();
                    dirs.Enqueue(path);

                    while (dirs.Count > 0)
                    {
                        string currentDir = dirs.Dequeue();

                        try
                        {
                            foreach (string subDir in Directory.GetDirectories(currentDir))
                                dirs.Enqueue(subDir);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            SafeAppendText($"[WARNING] Access denied to directory: {currentDir}\n");
                            continue;
                        }

                        try
                        {
                            foreach (string file in Directory.GetFiles(currentDir))
                                allFiles.Add(file);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            SafeAppendText($"[WARNING] Access denied to files in: {currentDir}\n");
                            continue;
                        }
                    }

                    int totalFiles = allFiles.Count;
                    int scannedFiles = 0;

                    foreach (string file in allFiles)
                    {
                        if (token.IsCancellationRequested)
                        {
                            SafeAppendText($"\n{scanType} cancelled by user.\n");
                            break;
                        }

                        bool foundThreat = ScanFile(file, scanType);
                        if (foundThreat)
                        {
                            threatCount++;
                            //action_required.Visible = true;
                            if (setting.sound.Checked)
                            {
                                PlayAlertSound();
                            }
                        }

                        scannedFiles++;
                        int progress = (int)((double)scannedFiles / totalFiles * 100);
                        UpdateProgressBar(progress);

                        Thread.Sleep(50); // simulate scanning delay
                    }


                    SafeAppendText($"\n{scanType} completed.\n");
                    SafeAppendText($"\n{scanType} completed. Threats found: {threatCount}\n");

                }, token);
            }
            catch (Exception ex)
            {
                SafeAppendText($"\n[ERROR] {ex.Message}");
            }
            finally
            {
                SetScanButtonsEnabled(true);
                progressBar1.Invoke(new Action(() =>
                {
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                    richTextBox1.Visible = false;
                    Scan.Visible = false;
                    label2.Visible = true;
                    btnStop.Visible = false;
                    guna2TileButton1.Visible = true;
                    guna2TileButton2.Visible = true;
                    guna2TileButton3.Visible = true;
                    label3.Visible = true;

                }));
                if (DetectedLogs.Count > 0)
                {
                    action_required.Visible = true;
                }
                MessageBox.Show($"Scan completed.\nThreats found: {threatCount}", "Scan Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void SetScanButtonsEnabled(bool enabled)
        {
            btnToggleRealTime.Enabled = enabled;
            btnStop.Enabled = !enabled;
        }
        private void UpdateProgressBar(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() =>
                {
                    progressBar1.Value = Math.Min(value, 100);
                }));
            }
            else
            {
                progressBar1.Value = Math.Min(value, 100);
            }
        }
        private void SafeAppendText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() => richTextBox1.AppendText(text)));
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
            else
            {
                richTextBox1.AppendText(text);
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }

        private void SafeClearText()
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() => richTextBox1.Clear()));
            }
            else
            {
                richTextBox1.Clear();
            }
        }
        private string ComputeSHA256(string filePath)
        {
            try
            {
                using (SHA256 sha = SHA256.Create())
                using (FileStream stream = File.OpenRead(filePath))
                {
                    byte[] hash = sha.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        private void btnToggleRealTime_Click(object sender, EventArgs e)
        {
            if (!realTimeEnabled)
            {
                StartRealTimeProtection(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                btnToggleRealTime.Text = "Disable Real-Time Protection";
                richTextBox1.AppendText("[INFO] Real-Time Protection Enabled.\n");
            }
            else
            {
                StopRealTimeProtection();
                btnToggleRealTime.Text = "Enable Real-Time Protection";
                richTextBox1.AppendText("[INFO] Real-Time Protection Disabled.\n");
            }

            realTimeEnabled = !realTimeEnabled;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (DetectedLogs.Count > 0)
            {
                action_required.Visible = true;
            }

            scanCancellationTokenSource?.Cancel();
            StopRealTimeProtection();
            realTimeEnabled = false;
            btnToggleRealTime.Text = "Enable Real-Time Protection";
            richTextBox1.AppendText("[INFO] Scan and Real-Time Protection Stopped.\n");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Setting setting = new Setting();
            // setting.Show();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void action_required_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form2 form02 = new Form2(this);
            form02.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
        }
    }
}