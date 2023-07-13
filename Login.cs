using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Kianosh_Safarzadeh_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ValidateUser()
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            string query = "SELECT utype FROM users WHERE uname = @username AND password = @password";
            using (SqlConnection connection = new SqlConnection("server=(localdb)\\localhost;database=Kianosh_Safarzadeh;integrated security=true"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        connection.Open();
                        object userType = command.ExecuteScalar();

                        if (userType != null)
                        {
                            string userTypeString = userType.ToString();
                            if (userTypeString == "user")
                            {
                                // User Login
                                MessageBox.Show("User Login Successful!");
                                // Open user form or perform any user-specific actions
                                frmuser fuser = new frmuser();
                                fuser.Show();
                                this.Hide();
                            }
                            else if (userTypeString == "admin")
                            {
                                // Admin Login
                                MessageBox.Show("Admin Login Successful!");
                                // Open admin form or perform any admin-specific actions
                                frmadmin fadm = new frmadmin();
                                fadm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidateUser();
        }
    }
}
