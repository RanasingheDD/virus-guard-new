namespace VirusGuard
{
    partial class FAQ
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAQ));
            label7 = new Label();
            btnToggle1 = new Guna.UI2.WinForms.Guna2Button();
            faqPanel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblAnswer1 = new Label();
            faqTimer1 = new System.Windows.Forms.Timer(components);
            faqPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(35, 30);
            label7.Name = "label7";
            label7.Size = new Size(53, 24);
            label7.TabIndex = 23;
            label7.Text = "FAQ";
            label7.Click += label7_Click;
            // 
            // btnToggle1
            // 
            btnToggle1.CustomizableEdges = customizableEdges1;
            btnToggle1.DisabledState.BorderColor = Color.DarkGray;
            btnToggle1.DisabledState.CustomBorderColor = Color.DarkGray;
            btnToggle1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnToggle1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnToggle1.FillColor = Color.Transparent;
            btnToggle1.Font = new Font("Lato", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnToggle1.ForeColor = Color.White;
            btnToggle1.Location = new Point(0, 3);
            btnToggle1.Name = "btnToggle1";
            btnToggle1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnToggle1.Size = new Size(493, 34);
            btnToggle1.TabIndex = 24;
            btnToggle1.Text = "1. What is Virus Guard?";
            btnToggle1.TextAlign = HorizontalAlignment.Left;
            btnToggle1.Click += btnToggle1_Click;
            // 
            // faqPanel1
            // 
            faqPanel1.AutoScroll = true;
            faqPanel1.Controls.Add(lblAnswer1);
            faqPanel1.Controls.Add(btnToggle1);
            faqPanel1.CustomizableEdges = customizableEdges3;
            faqPanel1.Location = new Point(35, 86);
            faqPanel1.Name = "faqPanel1";
            faqPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            faqPanel1.Size = new Size(646, 94);
            faqPanel1.TabIndex = 25;
            // 
            // lblAnswer1
            // 
            lblAnswer1.AutoSize = true;
            lblAnswer1.Font = new Font("Lato", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAnswer1.ForeColor = Color.White;
            lblAnswer1.Location = new Point(15, 40);
            lblAnswer1.MaximumSize = new Size(600, 0);
            lblAnswer1.Name = "lblAnswer1";
            lblAnswer1.Size = new Size(599, 48);
            lblAnswer1.TabIndex = 26;
            lblAnswer1.Text = resources.GetString("lblAnswer1.Text");
            lblAnswer1.Visible = false;
            lblAnswer1.Click += lblAnswer1_Click;
            // 
            // faqTimer1
            // 
            faqTimer1.Interval = 10;
            // 
            // FAQ
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            ClientSize = new Size(709, 543);
            Controls.Add(faqPanel1);
            Controls.Add(label7);
            Name = "FAQ";
            Text = "FAQ";
            faqPanel1.ResumeLayout(false);
            faqPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Guna.UI2.WinForms.Guna2Button btnToggle1;
        private Guna.UI2.WinForms.Guna2Panel faqPanel1;
        private Label lblAnswer1;
        private System.Windows.Forms.Timer faqTimer1;
    }
}