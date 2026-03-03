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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string sex = cmbSex.SelectedItem?.ToString();
            string telephone = txtTelephone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(ageText) || 
                string.IsNullOrEmpty(sex) || string.IsNullOrEmpty(telephone) || 
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int age;
            if (!int.TryParse(ageText, out age) || age <= 0)
            {
                MessageBox.Show("Please enter a valid age.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                
                string checkEmailQuery = "SELECT COUNT(*) FROM PATIENT WHERE email = '" + email + "'";
                DataTable emailCheck = db.ExecuteQuery(checkEmailQuery);
                
                if (Convert.ToInt32(emailCheck.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedPassword = SecurityHelper.HashPassword(password);
                string insertQuery = "INSERT INTO PATIENT (fullname, age, sex, telephone, email, password) VALUES (" +
                    "'" + fullName + "', " + age + ", '" + sex + "', '" + telephone + "', '" + email + "', '" + hashedPassword + "')";

                db.ExecuteNonQuery(insertQuery);
                
                MessageBox.Show("Registration successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoginForm loginForm = new LoginForm("Patient");
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm("Patient");
            loginForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
