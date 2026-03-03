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
    public partial class PatientPanel : Form
    {
        private int patientId;
        private string patientName;

        public PatientPanel(int patientId, string patientName)
        {
            InitializeComponent();
            this.patientId = patientId;
            this.patientName = patientName;
            this.lblWelcome.Text = "Welcome, " + patientName;
            LoadAppointments();
            LoadDoctors();
            LoadServices();
        }

        private void LoadAppointments()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string query = "SELECT a.appointment_id, d.fullname as doctor_name, s.service_name, a.date_time, a.status " +
                              "FROM APPOINTMENT a " +
                              "JOIN DOCTOR d ON a.doctor = d.doctor_id " +
                              "JOIN SERVICE s ON a.service = s.service_id " +
                              "WHERE a.patient = " + patientId + " " +
                              "ORDER BY a.date_time DESC";
                
                DataTable appointments = db.ExecuteQuery(query);
                dgvAppointments.DataSource = appointments;
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
                string query = "SELECT doctor_id, fullname FROM DOCTOR ORDER BY fullname";
                DataTable doctors = db.ExecuteQuery(query);
                
                cmbDoctors.DataSource = doctors;
                cmbDoctors.DisplayMember = "fullname";
                cmbDoctors.ValueMember = "doctor_id";
                cmbDoctors.SelectedIndex = -1;
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
                if (cmbDoctors.SelectedValue != null)
                {
                    DatabaseHelper db = new DatabaseHelper();
                    int doctorId = Convert.ToInt32(cmbDoctors.SelectedValue);
                    string query = "SELECT service_id, service_name FROM SERVICE WHERE doctor = " + doctorId + " ORDER BY service_name";
                    DataTable services = db.ExecuteQuery(query);
                    
                    cmbServices.DataSource = services;
                    cmbServices.DisplayMember = "service_name";
                    cmbServices.ValueMember = "service_id";
                    cmbServices.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            if (cmbDoctors.SelectedValue == null || cmbServices.SelectedValue == null)
            {
                MessageBox.Show("Please select both doctor and service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime appointmentDateTime = dtpAppointment.Value;
            int doctorId = Convert.ToInt32(cmbDoctors.SelectedValue);
            int serviceId = Convert.ToInt32(cmbServices.SelectedValue);

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                
                string conflictQuery = "SELECT COUNT(*) FROM APPOINTMENT WHERE doctor = " + doctorId + 
                                      " AND date_time = '" + appointmentDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                DataTable conflictCheck = db.ExecuteQuery(conflictQuery);
                
                if (Convert.ToInt32(conflictCheck.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Doctor not available at this time. Please select a different time.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertQuery = "INSERT INTO APPOINTMENT (patient, doctor, service, date_time, status) VALUES (" +
                    patientId + ", " + doctorId + ", " + serviceId + ", '" + 
                    appointmentDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', 'Pending')";

                db.ExecuteNonQuery(insertQuery);
                
                MessageBox.Show("Appointment booked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAppointments();
                
                cmbDoctors.SelectedIndex = -1;
                cmbServices.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbDoctors.SelectedValue == null || cmbServices.SelectedValue == null)
            {
                MessageBox.Show("Please select new doctor and service for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["appointment_id"].Value);
            DateTime newDateTime = dtpAppointment.Value;
            int newDoctorId = Convert.ToInt32(cmbDoctors.SelectedValue);
            int newServiceId = Convert.ToInt32(cmbServices.SelectedValue);

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                
                string conflictQuery = "SELECT COUNT(*) FROM APPOINTMENT WHERE doctor = " + newDoctorId + 
                                      " AND date_time = '" + newDateTime.ToString("yyyy-MM-dd HH:mm:ss") + 
                                      "' AND appointment_id != " + appointmentId;
                DataTable conflictCheck = db.ExecuteQuery(conflictQuery);
                
                if (Convert.ToInt32(conflictCheck.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Doctor not available at this time. Please select a different time.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string updateQuery = "UPDATE APPOINTMENT SET doctor = " + newDoctorId + ", service = " + newServiceId + 
                    ", date_time = '" + newDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE appointment_id = " + appointmentId;

                db.ExecuteNonQuery(updateQuery);
                
                MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirm Cancel", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["appointment_id"].Value);

                try
                {
                    DatabaseHelper db = new DatabaseHelper();
                    string deleteQuery = "DELETE FROM APPOINTMENT WHERE appointment_id = " + appointmentId;
                    db.ExecuteNonQuery(deleteQuery);
                    
                    MessageBox.Show("Appointment cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAppointments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error cancelling appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
            LoadDoctors();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
