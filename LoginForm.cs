using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_system
{
    public partial class LoginForm : Form
    {
        private string userType;

        public LoginForm(string userType)
        {
            InitializeComponent();
            this.userType = userType;
            this.lblTitle.Text = userType + " Login";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string hashedPassword = SecurityHelper.HashPassword(password);

                if (userType == "Manager")
                {
                    if (email == "manager@clinic.com" && password == "admin123")
                    {
                        ManagerPanel managerPanel = new ManagerPanel();
                        managerPanel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid manager credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (userType == "Patient")
                {
                    string query = "SELECT patient_id, fullname FROM PATIENT WHERE email = '" + email + "' AND password = '" + hashedPassword + "'";
                    DataTable result = db.ExecuteQuery(query);

                    if (result.Rows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(result.Rows[0]["patient_id"]);
                        string fullName = result.Rows[0]["fullname"].ToString();
                        PatientPanel patientPanel = new PatientPanel(patientId, fullName);
                        patientPanel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (userType == "Doctor")
                {
                    string query = "SELECT doctor_id, fullname FROM DOCTOR WHERE email = '" + email + "' AND password = '" + hashedPassword + "'";
                    DataTable result = db.ExecuteQuery(query);

                    if (result.Rows.Count > 0)
                    {
                        int doctorId = Convert.ToInt32(result.Rows[0]["doctor_id"]);
                        string fullName = result.Rows[0]["fullname"].ToString();
                        DoctorPanel doctorPanel = new DoctorPanel(doctorId, fullName);
                        doctorPanel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (userType == "Patient")
            {
                RegisterForm registerForm = new RegisterForm();
                registerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Only patients can register. Doctors and managers are registered by the manager.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
