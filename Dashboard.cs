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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm("Patient");
            loginForm.Show();
            this.Hide();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm("Doctor");
            loginForm.Show();
            this.Hide();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm("Manager");
            loginForm.Show();
            this.Hide();
        }
    }
}
