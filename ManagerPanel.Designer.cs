namespace clinic_system
{
    partial class ManagerPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.tabDoctors = new System.Windows.Forms.TabPage();
            this.tabServices = new System.Windows.Forms.TabPage();
            this.dgvAllAppointments = new System.Windows.Forms.DataGridView();
            this.lblAllAppointments = new System.Windows.Forms.Label();
            this.dgvDoctors = new System.Windows.Forms.DataGridView();
            this.lblDoctors = new System.Windows.Forms.Label();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.lblDoctorEmail = new System.Windows.Forms.Label();
            this.txtDoctorEmail = new System.Windows.Forms.TextBox();
            this.lblDoctorPassword = new System.Windows.Forms.Label();
            this.txtDoctorPassword = new System.Windows.Forms.TextBox();
            this.btnRegisterDoctor = new System.Windows.Forms.Button();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.lblServices = new System.Windows.Forms.Label();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.lblDoctorForService = new System.Windows.Forms.Label();
            this.cmbDoctorForService = new System.Windows.Forms.ComboBox();
            this.btnRegisterService = new System.Windows.Forms.Button();
            this.btnRefreshAll = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabAppointments.SuspendLayout();
            this.tabDoctors.SuspendLayout();
            this.tabServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabAppointments);
            this.tabControl.Controls.Add(this.tabDoctors);
            this.tabControl.Controls.Add(this.tabServices);
            this.tabControl.Location = new System.Drawing.Point(20, 20);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(860, 520);
            this.tabControl.TabIndex = 0;
            // 
            // tabAppointments
            // 
            this.tabAppointments.Controls.Add(this.lblAllAppointments);
            this.tabAppointments.Controls.Add(this.dgvAllAppointments);
            this.tabAppointments.Location = new System.Drawing.Point(4, 22);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointments.Size = new System.Drawing.Size(852, 492);
            this.tabAppointments.TabIndex = 0;
            this.tabAppointments.Text = "All Appointments";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // tabDoctors
            // 
            this.tabDoctors.Controls.Add(this.lblDoctors);
            this.tabDoctors.Controls.Add(this.dgvDoctors);
            this.tabDoctors.Controls.Add(this.lblDoctorName);
            this.tabDoctors.Controls.Add(this.txtDoctorName);
            this.tabDoctors.Controls.Add(this.lblDoctorEmail);
            this.tabDoctors.Controls.Add(this.txtDoctorEmail);
            this.tabDoctors.Controls.Add(this.lblDoctorPassword);
            this.tabDoctors.Controls.Add(this.txtDoctorPassword);
            this.tabDoctors.Controls.Add(this.btnRegisterDoctor);
            this.tabDoctors.Location = new System.Drawing.Point(4, 22);
            this.tabDoctors.Name = "tabDoctors";
            this.tabDoctors.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoctors.Size = new System.Drawing.Size(852, 492);
            this.tabDoctors.TabIndex = 1;
            this.tabDoctors.Text = "Register Doctor";
            this.tabDoctors.UseVisualStyleBackColor = true;
            // 
            // tabServices
            // 
            this.tabServices.Controls.Add(this.lblServices);
            this.tabServices.Controls.Add(this.dgvServices);
            this.tabServices.Controls.Add(this.lblServiceName);
            this.tabServices.Controls.Add(this.txtServiceName);
            this.tabServices.Controls.Add(this.lblDoctorForService);
            this.tabServices.Controls.Add(this.cmbDoctorForService);
            this.tabServices.Controls.Add(this.btnRegisterService);
            this.tabServices.Location = new System.Drawing.Point(4, 22);
            this.tabServices.Name = "tabServices";
            this.tabServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabServices.Size = new System.Drawing.Size(852, 492);
            this.tabServices.TabIndex = 2;
            this.tabServices.Text = "Register Service";
            this.tabServices.UseVisualStyleBackColor = true;
            // 
            // dgvAllAppointments
            // 
            this.dgvAllAppointments.AllowUserToAddRows = false;
            this.dgvAllAppointments.AllowUserToDeleteRows = false;
            this.dgvAllAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllAppointments.Location = new System.Drawing.Point(20, 50);
            this.dgvAllAppointments.Name = "dgvAllAppointments";
            this.dgvAllAppointments.ReadOnly = true;
            this.dgvAllAppointments.Size = new System.Drawing.Size(800, 400);
            this.dgvAllAppointments.TabIndex = 0;
            // 
            // lblAllAppointments
            // 
            this.lblAllAppointments.AutoSize = true;
            this.lblAllAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllAppointments.Location = new System.Drawing.Point(20, 20);
            this.lblAllAppointments.Name = "lblAllAppointments";
            this.lblAllAppointments.Size = new System.Drawing.Size(150, 20);
            this.lblAllAppointments.TabIndex = 1;
            this.lblAllAppointments.Text = "All Appointments";
            // 
            // dgvDoctors
            // 
            this.dgvDoctors.AllowUserToAddRows = false;
            this.dgvDoctors.AllowUserToDeleteRows = false;
            this.dgvDoctors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctors.Location = new System.Drawing.Point(20, 200);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.Size = new System.Drawing.Size(800, 250);
            this.dgvDoctors.TabIndex = 0;
            // 
            // lblDoctors
            // 
            this.lblDoctors.AutoSize = true;
            this.lblDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctors.Location = new System.Drawing.Point(20, 170);
            this.lblDoctors.Name = "lblDoctors";
            this.lblDoctors.Size = new System.Drawing.Size(60, 20);
            this.lblDoctors.TabIndex = 1;
            this.lblDoctors.Text = "Doctors";
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorName.Location = new System.Drawing.Point(20, 30);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(75, 17);
            this.lblDoctorName.TabIndex = 2;
            this.lblDoctorName.Text = "Full Name:";
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctorName.Location = new System.Drawing.Point(100, 27);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.Size = new System.Drawing.Size(200, 23);
            this.txtDoctorName.TabIndex = 3;
            // 
            // lblDoctorEmail
            // 
            this.lblDoctorEmail.AutoSize = true;
            this.lblDoctorEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorEmail.Location = new System.Drawing.Point(20, 70);
            this.lblDoctorEmail.Name = "lblDoctorEmail";
            this.lblDoctorEmail.Size = new System.Drawing.Size(42, 17);
            this.lblDoctorEmail.TabIndex = 4;
            this.lblDoctorEmail.Text = "Email:";
            // 
            // txtDoctorEmail
            // 
            this.txtDoctorEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctorEmail.Location = new System.Drawing.Point(70, 67);
            this.txtDoctorEmail.Name = "txtDoctorEmail";
            this.txtDoctorEmail.Size = new System.Drawing.Size(230, 23);
            this.txtDoctorEmail.TabIndex = 5;
            // 
            // lblDoctorPassword
            // 
            this.lblDoctorPassword.AutoSize = true;
            this.lblDoctorPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorPassword.Location = new System.Drawing.Point(20, 110);
            this.lblDoctorPassword.Name = "lblDoctorPassword";
            this.lblDoctorPassword.Size = new System.Drawing.Size(71, 17);
            this.lblDoctorPassword.TabIndex = 6;
            this.lblDoctorPassword.Text = "Password:";
            // 
            // txtDoctorPassword
            // 
            this.txtDoctorPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctorPassword.Location = new System.Drawing.Point(100, 107);
            this.txtDoctorPassword.Name = "txtDoctorPassword";
            this.txtDoctorPassword.PasswordChar = '*';
            this.txtDoctorPassword.Size = new System.Drawing.Size(200, 23);
            this.txtDoctorPassword.TabIndex = 7;
            // 
            // btnRegisterDoctor
            // 
            this.btnRegisterDoctor.BackColor = System.Drawing.Color.LightGreen;
            this.btnRegisterDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterDoctor.Location = new System.Drawing.Point(100, 140);
            this.btnRegisterDoctor.Name = "btnRegisterDoctor";
            this.btnRegisterDoctor.Size = new System.Drawing.Size(150, 35);
            this.btnRegisterDoctor.TabIndex = 8;
            this.btnRegisterDoctor.Text = "Register Doctor";
            this.btnRegisterDoctor.UseVisualStyleBackColor = false;
            this.btnRegisterDoctor.Click += new System.EventHandler(this.btnRegisterDoctor_Click);
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(20, 200);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.Size = new System.Drawing.Size(800, 250);
            this.dgvServices.TabIndex = 0;
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServices.Location = new System.Drawing.Point(20, 170);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(68, 20);
            this.lblServices.TabIndex = 1;
            this.lblServices.Text = "Services";
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceName.Location = new System.Drawing.Point(20, 30);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(82, 17);
            this.lblServiceName.TabIndex = 2;
            this.lblServiceName.Text = "Service Name:";
            // 
            // txtServiceName
            // 
            this.txtServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceName.Location = new System.Drawing.Point(110, 27);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(200, 23);
            this.txtServiceName.TabIndex = 3;
            // 
            // lblDoctorForService
            // 
            this.lblDoctorForService.AutoSize = true;
            this.lblDoctorForService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorForService.Location = new System.Drawing.Point(20, 70);
            this.lblDoctorForService.Name = "lblDoctorForService";
            this.lblDoctorForService.Size = new System.Drawing.Size(51, 17);
            this.lblDoctorForService.TabIndex = 4;
            this.lblDoctorForService.Text = "Doctor:";
            // 
            // cmbDoctorForService
            // 
            this.cmbDoctorForService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctorForService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoctorForService.FormattingEnabled = true;
            this.cmbDoctorForService.Location = new System.Drawing.Point(80, 67);
            this.cmbDoctorForService.Name = "cmbDoctorForService";
            this.cmbDoctorForService.Size = new System.Drawing.Size(230, 24);
            this.cmbDoctorForService.TabIndex = 5;
            // 
            // btnRegisterService
            // 
            this.btnRegisterService.BackColor = System.Drawing.Color.LightBlue;
            this.btnRegisterService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterService.Location = new System.Drawing.Point(110, 110);
            this.btnRegisterService.Name = "btnRegisterService";
            this.btnRegisterService.Size = new System.Drawing.Size(150, 35);
            this.btnRegisterService.TabIndex = 6;
            this.btnRegisterService.Text = "Register Service";
            this.btnRegisterService.UseVisualStyleBackColor = false;
            this.btnRegisterService.Click += new System.EventHandler(this.btnRegisterService_Click);
            // 
            // btnRefreshAll
            // 
            this.btnRefreshAll.BackColor = System.Drawing.Color.LightYellow;
            this.btnRefreshAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshAll.Location = new System.Drawing.Point(720, 550);
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshAll.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshAll.TabIndex = 1;
            this.btnRefreshAll.Text = "Refresh All";
            this.btnRefreshAll.UseVisualStyleBackColor = false;
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(830, 550);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ManagerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 600);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnRefreshAll);
            this.Controls.Add(this.tabControl);
            this.Name = "ManagerPanel";
            this.Text = "Manager Panel";
            this.Load += new System.EventHandler(this.ManagerPanel_Load);
            this.tabControl.ResumeLayout(false);
            this.tabAppointments.ResumeLayout(false);
            this.tabAppointments.PerformLayout();
            this.tabDoctors.ResumeLayout(false);
            this.tabDoctors.PerformLayout();
            this.tabServices.ResumeLayout(false);
            this.tabServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.TabPage tabDoctors;
        private System.Windows.Forms.TabPage tabServices;
        private System.Windows.Forms.DataGridView dgvAllAppointments;
        private System.Windows.Forms.Label lblAllAppointments;
        private System.Windows.Forms.DataGridView dgvDoctors;
        private System.Windows.Forms.Label lblDoctors;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.Label lblDoctorEmail;
        private System.Windows.Forms.TextBox txtDoctorEmail;
        private System.Windows.Forms.Label lblDoctorPassword;
        private System.Windows.Forms.TextBox txtDoctorPassword;
        private System.Windows.Forms.Button btnRegisterDoctor;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label lblDoctorForService;
        private System.Windows.Forms.ComboBox cmbDoctorForService;
        private System.Windows.Forms.Button btnRegisterService;
        private System.Windows.Forms.Button btnRefreshAll;
        private System.Windows.Forms.Button btnLogout;
    }
}
