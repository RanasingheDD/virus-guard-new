using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                faqPanel2.Height = collapsedHeight;
                lblAnswer2.Visible = false;
                isExpanded = false;
            }
            else
            {
                lblAnswer2.Visible = true;
                faqPanel2.Height = expandedHeight;
                isExpanded = true;
            }
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string feedback = txtFeedback.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(feedback))
            {
                MessageBox.Show("Please fill out all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=VirusDB;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO feedback (Name, Email, Feedback) VALUES (@Name, @Email, @Feedback)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Feedback", feedback);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtName.Clear();
                            txtEmail.Clear();
                            txtFeedback.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit feedback. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
