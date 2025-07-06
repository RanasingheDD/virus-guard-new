namespace VirusGuard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnQuickScan = new Button();
            btnFullScan = new Button();
            label1 = new Label();
            btnCustomScan = new Button();
            richTextBox1 = new RichTextBox();
            btnToggleRealTime = new Button();
            clear = new Button();
            btnStop = new Button();
            button1 = new Button();
            label2 = new Label();
            guna2TileButton3 = new Guna.UI2.WinForms.Guna2TileButton();
            guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            label3 = new Label();
            progressBar1 = new ProgressBar();
            Scan = new Label();
            SuspendLayout();
            // 
            // btnQuickScan
            // 
            btnQuickScan.BackColor = Color.Green;
            btnQuickScan.Cursor = Cursors.Hand;
            btnQuickScan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuickScan.ForeColor = SystemColors.HighlightText;
            btnQuickScan.Location = new Point(45, 444);
            btnQuickScan.Margin = new Padding(3, 2, 3, 2);
            btnQuickScan.Name = "btnQuickScan";
            btnQuickScan.Size = new Size(94, 29);
            btnQuickScan.TabIndex = 0;
            btnQuickScan.Text = "Quick Scan";
            btnQuickScan.UseVisualStyleBackColor = false;
            // 
            // btnFullScan
            // 
            btnFullScan.BackColor = Color.Black;
            btnFullScan.Cursor = Cursors.Hand;
            btnFullScan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFullScan.ForeColor = SystemColors.HighlightText;
            btnFullScan.Location = new Point(160, 444);
            btnFullScan.Margin = new Padding(3, 2, 3, 2);
            btnFullScan.Name = "btnFullScan";
            btnFullScan.Size = new Size(82, 29);
            btnFullScan.TabIndex = 2;
            btnFullScan.Text = "Full Scan";
            btnFullScan.UseVisualStyleBackColor = false;
            //btnFullScan.Click += btnFullScan_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Engravers MT", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(261, 17);
            label1.Name = "label1";
            label1.Size = new Size(307, 35);
            label1.TabIndex = 5;
            label1.Text = "Virus Guard";
            // 
            // btnCustomScan
            // 
            btnCustomScan.BackColor = Color.LightSeaGreen;
            btnCustomScan.Cursor = Cursors.Hand;
            btnCustomScan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCustomScan.ForeColor = SystemColors.HighlightText;
            btnCustomScan.Location = new Point(12, 172);
            btnCustomScan.Margin = new Padding(3, 2, 3, 2);
            btnCustomScan.Name = "btnCustomScan";
            btnCustomScan.Size = new Size(117, 29);
            btnCustomScan.TabIndex = 6;
            btnCustomScan.Text = "Custom Scan";
            btnCustomScan.UseVisualStyleBackColor = false;
            //btnCustomScan.Click += btnCustomScan_Click_1;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Lato", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(191, 177);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.MaxLength = 200;
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(487, 33);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            richTextBox1.Visible = false;
            //richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // btnToggleRealTime
            // 
            btnToggleRealTime.BackColor = Color.Olive;
            btnToggleRealTime.Cursor = Cursors.Hand;
            btnToggleRealTime.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnToggleRealTime.ForeColor = SystemColors.HighlightText;
            btnToggleRealTime.Location = new Point(630, 50);
            btnToggleRealTime.Margin = new Padding(3, 2, 3, 2);
            btnToggleRealTime.Name = "btnToggleRealTime";
            btnToggleRealTime.Size = new Size(225, 29);
            btnToggleRealTime.TabIndex = 8;
            btnToggleRealTime.Text = "Enable Real-Time Protection";
            btnToggleRealTime.UseVisualStyleBackColor = false;
            // 
            // clear
            // 
            clear.BackColor = Color.DarkOrange;
            clear.Cursor = Cursors.Hand;
            clear.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clear.ForeColor = SystemColors.HighlightText;
            clear.Location = new Point(702, 449);
            clear.Margin = new Padding(3, 2, 3, 2);
            clear.Name = "clear";
            clear.Size = new Size(82, 29);
            clear.TabIndex = 9;
            clear.Text = "Clear";
            clear.UseVisualStyleBackColor = false;
            clear.Click += clear_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Red;
            btnStop.Cursor = Cursors.Hand;
            btnStop.FlatAppearance.BorderColor = Color.Red;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStop.ForeColor = SystemColors.HighlightText;
            btnStop.Location = new Point(714, 130);
            btnStop.Margin = new Padding(3, 2, 3, 2);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(82, 29);
            btnStop.TabIndex = 10;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Visible = false;
            btnStop.Click += btnStop_Click;
            // 
            // button1
            // 
            button1.Location = new Point(54, 29);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lato", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 229, 76);
            label2.Location = new Point(189, 118);
            label2.Name = "label2";
            label2.Size = new Size(489, 57);
            label2.TabIndex = 12;
            label2.Text = "✅ You Are Protected";
            label2.Click += label2_Click;
            // 
            // guna2TileButton3
            // 
            guna2TileButton3.BorderColor = Color.White;
            guna2TileButton3.BorderRadius = 10;
            guna2TileButton3.BorderThickness = 1;
            guna2TileButton3.CustomBorderColor = Color.White;
            guna2TileButton3.CustomizableEdges = customizableEdges1;
            guna2TileButton3.DisabledState.BorderColor = Color.DarkGray;
            guna2TileButton3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2TileButton3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2TileButton3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2TileButton3.FillColor = Color.FromArgb(44, 44, 44);
            guna2TileButton3.Font = new Font("Lato Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2TileButton3.ForeColor = Color.White;
            guna2TileButton3.HoverState.BorderColor = Color.DimGray;
            guna2TileButton3.HoverState.FillColor = Color.DimGray;
            guna2TileButton3.Location = new Point(598, 215);
            guna2TileButton3.Name = "guna2TileButton3";
            guna2TileButton3.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TileButton3.Size = new Size(168, 171);
            guna2TileButton3.TabIndex = 15;
            guna2TileButton3.Text = "Custom Scan";
            // 
            // guna2TileButton1
            // 
            guna2TileButton1.BorderColor = Color.White;
            guna2TileButton1.BorderRadius = 10;
            guna2TileButton1.BorderThickness = 1;
            guna2TileButton1.CustomBorderColor = Color.White;
            guna2TileButton1.CustomizableEdges = customizableEdges3;
            guna2TileButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2TileButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2TileButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2TileButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2TileButton1.FillColor = Color.FromArgb(44, 44, 44);
            guna2TileButton1.Font = new Font("Lato Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2TileButton1.ForeColor = Color.White;
            guna2TileButton1.HoverState.BorderColor = Color.DimGray;
            guna2TileButton1.HoverState.FillColor = Color.DimGray;
            guna2TileButton1.Location = new Point(138, 215);
            guna2TileButton1.Name = "guna2TileButton1";
            guna2TileButton1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2TileButton1.Size = new Size(168, 171);
            guna2TileButton1.TabIndex = 16;
            guna2TileButton1.Text = "Quick Scan";
            guna2TileButton1.Click += guna2TileButton1_Click;
            // 
            // guna2TileButton2
            // 
            guna2TileButton2.BorderColor = Color.White;
            guna2TileButton2.BorderRadius = 10;
            guna2TileButton2.BorderThickness = 1;
            guna2TileButton2.CustomBorderColor = Color.White;
            guna2TileButton2.CustomizableEdges = customizableEdges5;
            guna2TileButton2.DisabledState.BorderColor = Color.DarkGray;
            guna2TileButton2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2TileButton2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2TileButton2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2TileButton2.FillColor = Color.FromArgb(44, 44, 44);
            guna2TileButton2.Font = new Font("Lato Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2TileButton2.ForeColor = Color.White;
            guna2TileButton2.HoverState.BorderColor = Color.DimGray;
            guna2TileButton2.HoverState.FillColor = Color.DimGray;
            guna2TileButton2.Location = new Point(373, 215);
            guna2TileButton2.Name = "guna2TileButton2";
            guna2TileButton2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2TileButton2.Size = new Size(168, 171);
            guna2TileButton2.TabIndex = 17;
            guna2TileButton2.Text = "Full Scan";
            guna2TileButton2.Click += guna2TileButton2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 229, 76);
            label3.Location = new Point(389, 337);
            label3.Name = "label3";
            label3.Size = new Size(125, 86);
            label3.TabIndex = 18;
            label3.Text = "🔎";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(191, 130);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(487, 29);
            progressBar1.TabIndex = 19;
            progressBar1.Visible = false;
            progressBar1.Click += progressBar1_Click;
            // 
            // Scan
            // 
            Scan.AutoSize = true;
            Scan.Font = new Font("Lato", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Scan.ForeColor = Color.White;
            Scan.Location = new Point(191, 92);
            Scan.Name = "Scan";
            Scan.Size = new Size(77, 16);
            Scan.TabIndex = 20;
            Scan.Text = "Scanning .....";
            Scan.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(909, 489);
            Controls.Add(Scan);
            Controls.Add(progressBar1);
            Controls.Add(label3);
            Controls.Add(guna2TileButton2);
            Controls.Add(guna2TileButton1);
            Controls.Add(guna2TileButton3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(btnStop);
            Controls.Add(clear);
            Controls.Add(btnToggleRealTime);
            Controls.Add(richTextBox1);
            Controls.Add(btnCustomScan);
            Controls.Add(label1);
            Controls.Add(btnFullScan);
            Controls.Add(btnQuickScan);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = resources.GetString("$this.Text");
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnQuickScan;
        private Button btnFullScan;
        private Label label1;
        private Button btnCustomScan;
        private RichTextBox richTextBox1;
        private Button btnToggleRealTime;
        private Button clear;
        private Button btnStop;
        private Button button1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton3;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton2;
        private Label label3;
        private ProgressBar progressBar1;
        private Label Scan;
    }
}
