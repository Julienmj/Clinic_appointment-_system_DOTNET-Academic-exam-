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
    public partial class ManagerPanel : Form
    {
        public ManagerPanel()
        {
            InitializeComponent();
            LoadAllAppointments();
            LoadDoctors();
            LoadServices();
        }

        private void LoadAllAppointments()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string query = "SELECT a.appointment_id, p.fullname as patient_name, d.fullname as doctor_name, " +
                              "s.service_name, a.date_time, a.status " +
                              "FROM APPOINTMENT a " +
                              "JOIN PATIENT p ON a.patient = p.patient_id " +
                              "JOIN DOCTOR d ON a.doctor = d.doctor_id " +
                              "JOIN SERVICE s ON a.service = s.service_id " +
                              "ORDER BY a.date_time DESC";
                
                DataTable appointments = db.ExecuteQuery(query);
                dgvAllAppointments.DataSource = appointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoctors()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string query = "SELECT doctor_id, fullname, email FROM DOCTOR ORDER BY fullname";
                DataTable doctors = db.ExecuteQuery(query);
                dgvDoctors.DataSource = doctors;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadServices()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string query = "SELECT s.service_id, s.service_name, d.fullname as doctor_name " +
                              "FROM SERVICE s " +
                              "JOIN DOCTOR d ON s.doctor = d.doctor_id " +
                              "ORDER BY s.service_name";
                DataTable services = db.ExecuteQuery(query);
                dgvServices.DataSource = services;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegisterDoctor_Click(object sender, EventArgs e)
        {
            string fullName = txtDoctorName.Text.Trim();
            string email = txtDoctorEmail.Text.Trim();
            string password = txtDoctorPassword.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all doctor fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                
                string checkEmailQuery = "SELECT COUNT(*) FROM DOCTOR WHERE email = '" + email + "'";
                DataTable emailCheck = db.ExecuteQuery(checkEmailQuery);
                
                if (Convert.ToInt32(emailCheck.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedPassword = SecurityHelper.HashPassword(password);
                string insertQuery = "INSERT INTO DOCTOR (fullname, email, password) VALUES (" +
                    "'" + fullName + "', '" + email + "', '" + hashedPassword + "')";

                db.ExecuteNonQuery(insertQuery);
                
                MessageBox.Show("Doctor registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtDoctorName.Clear();
                txtDoctorEmail.Clear();
                txtDoctorPassword.Clear();
                LoadDoctors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registering doctor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegisterService_Click(object sender, EventArgs e)
        {
            string serviceName = txtServiceName.Text.Trim();

            if (string.IsNullOrEmpty(serviceName))
            {
                MessageBox.Show("Please enter service name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbDoctorForService.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor for this service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int doctorId = Convert.ToInt32(cmbDoctorForService.SelectedValue);

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                
                string checkServiceQuery = "SELECT COUNT(*) FROM SERVICE WHERE service_name = '" + serviceName + "' AND doctor = " + doctorId;
                DataTable serviceCheck = db.ExecuteQuery(checkServiceQuery);
                
                if (Convert.ToInt32(serviceCheck.Rows[0][0]) > 0)
                {
                    MessageBox.Show("This service already exists for the selected doctor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string insertQuery = "INSERT INTO SERVICE (service_name, doctor) VALUES ('" + serviceName + "', " + doctorId + ")";
                db.ExecuteNonQuery(insertQuery);
                
                MessageBox.Show("Service registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtServiceName.Clear();
                cmbDoctorForService.SelectedIndex = -1;
                LoadServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registering service: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            LoadAllAppointments();
            LoadDoctors();
            LoadServices();
            LoadDoctorsForService();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void ManagerPanel_Load(object sender, EventArgs e)
        {
            LoadDoctorsForService();
        }

        private void LoadDoctorsForService()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string query = "SELECT doctor_id, fullname FROM DOCTOR ORDER BY fullname";
                DataTable doctors = db.ExecuteQuery(query);
                
                cmbDoctorForService.DataSource = doctors;
                cmbDoctorForService.DisplayMember = "fullname";
                cmbDoctorForService.ValueMember = "doctor_id";
                cmbDoctorForService.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading doctors for service: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
