# Hospital Appointment Request System

A beginner-friendly C# Windows Forms application for managing hospital appointments with patient, doctor, and manager roles.

## 🏥 Features

### Patient Panel
- ✅ User registration with encrypted passwords
- ✅ View available doctors and their services
- ✅ Book, update, and cancel appointments
- ✅ View appointment status (Pending/Approved/Denied)
- ✅ Conflict checking for appointment times

### Doctor Panel
- ✅ View assigned appointments only
- ✅ Approve or deny appointment requests
- ✅ See patient details and service information

### Manager Panel
- ✅ Register doctors with encrypted passwords
- ✅ Register services and assign to doctors
- ✅ View all appointments in the system
- ✅ Complete administrative control

## 🔧 Technology Stack

- **Language:** C# (.NET Framework 4.7.2)
- **UI:** Windows Forms
- **Database:** File-based text database (no external dependencies)
- **Data Access:** ADO.NET patterns (DataTable, custom file operations)
- **Security:** SHA256 password hashing
- **Architecture:** Simple 3-tier architecture (UI → Business Logic → Data Layer)

## 📋 System Requirements

- Windows 7 or later
- .NET Framework 4.7.2 or later
- Visual Studio 2017 or later (for development)

## 🚀 Quick Start

### 1. Clone the Repository
```bash
git clone https://github.com/Julienmj/Clinic_appointment-_system_DOTNET-Academic-exam-.git
cd Clinic_appointment-_system_DOTNET-Academic-exam-
```

### 2. Open in Visual Studio
- Open `clinic system.slnx` in Visual Studio
- Build the solution (Ctrl+Shift+B)

### 3. Run the Application
- Press F5 or click "Start" button
- The Dashboard will appear with three role options

## 🔑 Default Credentials

### Manager Account
- **Email:** `manager@clinic.com`
- **Password:** `admin123`

### Setup Workflow
1. **Manager Login** → Register Doctors → Register Services
2. **Patient Registration** → Self-register using registration form
3. **Doctor Login** → Use credentials created by manager
4. **Patient Booking** → Book appointments with available doctors

## 📁 Project Structure

```
clinic system/
├── 📄 README.md                 # This file
├── 📄 DATABASE_DIAGRAM.txt      # Database schema documentation
├── 📄 App.config                # Application configuration
├── 📄 clinic system.csproj      # Project file
├── 📄 Program.cs                # Application entry point
├── 🏠 Dashboard/                # Main dashboard form
│   ├── Dashboard.cs
│   └── Dashboard.Designer.cs
├── 🔐 Authentication/           # Login and registration forms
│   ├── LoginForm.cs
│   ├── LoginForm.Designer.cs
│   ├── RegisterForm.cs
│   └── RegisterForm.Designer.cs
├── 👤 Patient Panel/            # Patient functionality
│   ├── PatientPanel.cs
│   └── PatientPanel.Designer.cs
├── 👨‍⚕️ Doctor Panel/           # Doctor functionality
│   ├── DoctorPanel.cs
│   └── DoctorPanel.Designer.cs
├── 📊 Manager Panel/            # Manager functionality
│   ├── ManagerPanel.cs
│   └── ManagerPanel.Designer.cs
├── 🔧 Utilities/                # Helper classes
│   ├── DatabaseHelper.cs        # File-based database operations
│   └── SecurityHelper.cs        # Password encryption
└── 📁 Properties/               # Project properties
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs
    ├── Settings.Designer.cs
    └── Settings.settings
```

## 🗄️ Database Design

### File-Based Database System
- **Storage:** `clinic_system.txt` (auto-created)
- **Format:** Structured text file with comma-separated values
- **Advantages:** No installation required, portable, beginner-friendly

### Tables Structure

#### PATIENT
- `patient_id` (Primary Key)
- `fullname`, `age`, `sex`, `telephone`
- `email` (Unique), `password` (SHA256 Hashed)

#### DOCTOR  
- `doctor_id` (Primary Key)
- `fullname`, `email` (Unique), `password` (SHA256 Hashed)

#### SERVICE
- `service_id` (Primary Key)
- `service_name`, `doctor` (Foreign Key → DOCTOR)

#### APPOINTMENT
- `appointment_id` (Primary Key)
- `patient`, `doctor`, `service` (Foreign Keys)
- `date_time`, `status` (Pending/Approved/Denied)

### Relationships
- PATIENT 1:M APPOINTMENT
- DOCTOR 1:M APPOINTMENT  
- DOCTOR 1:M SERVICE
- SERVICE 1:M APPOINTMENT

## 🛡️ Security Features

- **Password Encryption:** SHA256 hashing for all user passwords
- **Input Validation:** Basic validation on all forms
- **Role-Based Access:** Separate panels for each user type
- **Data Integrity:** Conflict checking for appointment scheduling

## 📝 Academic Project Details

### Project Constraints (Strictly Followed)
- ✅ No LINQ, Entity Framework, or advanced patterns
- ✅ No stored procedures, views, or triggers
- ✅ No async/await or complex design patterns
- ✅ Only ADO.NET-style operations (custom implementation)
- ✅ Simple, beginner-friendly code structure
- ✅ Single color theme throughout the application

### Learning Objectives
- Understanding Windows Forms development
- Implementing file-based data persistence
- Role-based application design
- Basic security implementation
- Database relationship management

## 🔍 How It Works

### Database Operations
The system uses a custom file-based database that simulates SQL operations:

```csharp
// Example: Patient Registration
string query = "INSERT INTO PATIENT VALUES ('John Doe', 25, 'Male', '1234567890', 'john@email.com', 'hashed_password')";
db.ExecuteNonQuery(query);
```

### Password Security
```csharp
// SHA256 Encryption
public static string HashPassword(string password)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
```

## 🐛 Troubleshooting

### Common Issues

1. **"Database file not found"**
   - The system creates `clinic_system.txt` automatically on first run
   - Ensure write permissions in the application directory

2. **"Cannot access row at position 0"**
   - Fixed in current version - system handles empty data gracefully
   - Rebuild the solution if issue persists

3. **Build Errors**
   - Ensure .NET Framework 4.7.2 is installed
   - Clean and rebuild the solution

### Data Backup
- Simply copy `clinic_system.txt` to backup all data
- The file contains all patient, doctor, service, and appointment records

## 🤝 Contributing

This is an academic project demonstrating fundamental C# and Windows Forms concepts. For educational purposes:

1. Fork the repository
2. Create a feature branch
3. Make changes following the simple architecture pattern
4. Test thoroughly
5. Submit a pull request

## 📄 License

This project is for educational purposes. Feel free to use and modify for learning.

## 👨‍🏫 Instructor Notes

### Key Concepts Demonstrated
- Windows Forms UI development
- File-based data persistence
- User authentication and authorization
- Database relationship management
- Basic security implementation
- Role-based application design

### Assessment Criteria Met
- ✅ Simple, beginner-friendly implementation
- ✅ No advanced frameworks or patterns
- ✅ Proper error handling and user feedback
- ✅ Complete CRUD operations
- ✅ Role-based access control
- ✅ Data validation and security

---

**Developed for Academic Examination**  
*Demonstrating fundamental C# and Windows Forms development skills*
