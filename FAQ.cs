using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusGuard
{
    public partial class FAQ : Form
    {
        bool isExpanded = false;
        int expandedHeight = 150;  // Total height when expanded
        int collapsedHeight = 60;  // Height when collapsed
        public FAQ()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnToggle1_Click(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                // Collapse
                faqPanel1.Height = collapsedHeight;
                lblAnswer1.Visible = false;
                //btnToggle1.Text = "▼ Show Answer";
                isExpanded = false;
            }
            else
            {
                // Expand
                lblAnswer1.Visible = true;
                faqPanel1.Height = expandedHeight;
                //btnToggle1.Text = "▲ Hide Answer";
                isExpanded = true;
            }
        }


        private void lblAnswer1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                // Collapse
                faqPanel2.Height = collapsedHeight;
                lblAnswer2.Visible = false;
                //btnToggle1.Text = "▼ Show Answer";
                isExpanded = false;
            }
            else
            {
                // Expand
                lblAnswer2.Visible = true;
                faqPanel2.Height = expandedHeight;
                //btnToggle1.Text = "▲ Hide Answer";
                isExpanded = true;
            }
        }

        private void FAQ_Load(object sender, EventArgs e)
        {

        }

        private void lblAnswer3_Click(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                // Collapse
                faqPanel3.Height = collapsedHeight;
                label1.Visible = false;
                //btnToggle1.Text = "▼ Show Answer";
                isExpanded = false;
            }
            else
            {
                // Expand
                label1.Visible = true;
                faqPanel3.Height = expandedHeight;
                //btnToggle1.Text = "▲ Hide Answer";
                isExpanded = true;
            }
        }
    }
}
