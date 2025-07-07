namespace VirusGuard
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            dataGridView1 = new DataGridView();
            label1 = new Label();
            export = new Button();
            delete = new Button();
            virusTotal = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 93);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(932, 397);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(433, 31);
            label1.Name = "label1";
            label1.Size = new Size(77, 37);
            label1.TabIndex = 3;
            label1.Text = "Logs";
            label1.Click += label1_Click;
            // 
            // export
            // 
            export.BackColor = Color.FromArgb(10, 149, 0);
            export.FlatAppearance.BorderColor = Color.FromArgb(10, 149, 0);
            export.FlatAppearance.BorderSize = 3;
            export.FlatStyle = FlatStyle.Flat;
            export.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            export.ForeColor = Color.Black;
            export.Location = new Point(653, 537);
            export.Margin = new Padding(3, 4, 3, 4);
            export.Name = "export";
            export.Size = new Size(113, 47);
            export.TabIndex = 5;
            export.Text = "Export ";
            export.UseVisualStyleBackColor = false;
            export.Click += export_Click;
            // 
            // delete
            // 
            delete.BackColor = Color.FromArgb(10, 149, 0);
            delete.FlatAppearance.BorderColor = Color.FromArgb(10, 149, 0);
            delete.FlatStyle = FlatStyle.Flat;
            delete.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            delete.ForeColor = Color.Black;
            delete.Location = new Point(246, 537);
            delete.Margin = new Padding(3, 4, 3, 4);
            delete.Name = "delete";
            delete.Size = new Size(96, 47);
            delete.TabIndex = 6;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = false;
            delete.Click += button1_Click;
            // 
            // virusTotal
            // 
            virusTotal.FlatAppearance.BorderColor = Color.FromArgb(44, 44, 44);
            virusTotal.FlatStyle = FlatStyle.Flat;
            virusTotal.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            virusTotal.ForeColor = Color.Red;
            virusTotal.Location = new Point(781, 31);
            virusTotal.Margin = new Padding(3, 4, 3, 4);
            virusTotal.Name = "virusTotal";
            virusTotal.Size = new Size(165, 32);
            virusTotal.TabIndex = 7;
            virusTotal.Text = "Check with virus Total";
            virusTotal.UseVisualStyleBackColor = true;
            virusTotal.Click += button1_Click_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            ClientSize = new Size(958, 724);
            Controls.Add(virusTotal);
            Controls.Add(delete);
            Controls.Add(export);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            ShowInTaskbar = false;
            Text = "History";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button export;
        private Button delete;
        private Button virusTotal;
    }
}