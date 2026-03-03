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
    public partial class DoctorPanel : Form
    {
        private int doctorId;
        private string doctorName;

        public DoctorPanel(int doctorId, string doctorName)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            this.doctorName = doctorName;
            this.lblWelcome.Text = "Welcome, Dr. " + doctorName;
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string query = "SELECT a.appointment_id, p.fullname as patient_name, s.service_name, a.date_time, a.status " +
                              "FROM APPOINTMENT a " +
                              "JOIN PATIENT p ON a.patient = p.patient_id " +
                              "JOIN SERVICE s ON a.service = s.service_id " +
                              "WHERE a.doctor = " + doctorId + " " +
                              "ORDER BY a.date_time DESC";
                
                DataTable appointments = db.ExecuteQuery(query);
                dgvAppointments.DataSource = appointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to approve.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["appointment_id"].Value);
            string currentStatus = dgvAppointments.SelectedRows[0].Cells["status"].Value.ToString();

            if (currentStatus == "Approved")
            {
                MessageBox.Show("This appointment is already approved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentStatus == "Denied")
            {
                MessageBox.Show("This appointment was denied. Cannot approve denied appointments.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string updateQuery = "UPDATE APPOINTMENT SET status = 'Approved' WHERE appointment_id = " + appointmentId;
                db.ExecuteNonQuery(updateQuery);
                
                MessageBox.Show("Appointment approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to deny.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["appointment_id"].Value);
            string currentStatus = dgvAppointments.SelectedRows[0].Cells["status"].Value.ToString();

            if (currentStatus == "Denied")
            {
                MessageBox.Show("This appointment is already denied.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentStatus == "Approved")
            {
                DialogResult result = MessageBox.Show("This appointment is already approved. Are you sure you want to deny it?", 
                    "Confirm Deny", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string updateQuery = "UPDATE APPOINTMENT SET status = 'Denied' WHERE appointment_id = " + appointmentId;
                db.ExecuteNonQuery(updateQuery);
                
                MessageBox.Show("Appointment denied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error denying appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
