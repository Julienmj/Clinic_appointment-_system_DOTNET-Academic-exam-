# 🏥 Hospital Appointment Request System

[![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue.svg)](https://dotnet.microsoft.com/download/dotnet-framework/net472)
[![Windows Forms](https://img.shields.io/badge/Windows%20Forms-512BD4?style=flat&logo=windows&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![License](https://img.shields.io/badge/License-Educational%20Use-green.svg)](LICENSE)

A comprehensive, beginner-friendly C# Windows Forms application for managing hospital appointments with role-based access control and secure authentication.

## 📋 Table of Contents

- [🏥 Features](#-features)
- [🔧 Technology Stack](#-technology-stack)
- [📋 System Requirements](#-system-requirements)
- [🚀 Quick Start](#-quick-start)
- [🔑 Credentials](#-credentials)
- [📁 Project Structure](#-project-structure)
- [🗄️ Database Design](#️-database-design)
- [🛡️ Security Features](#-security-features)
- [📝 Academic Project Details](#-academic-project-details)
- [🔍 How It Works](#-how-it-works)
- [🐛 Troubleshooting](#-bug-troubleshooting)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)
- [👨‍🏫 Instructor Notes](#-instructor-notes)

---

## 🏥 Features

### 👤 Patient Panel
- ✅ **User Registration**: Self-registration with encrypted passwords
- ✅ **Doctor Discovery**: View available doctors and their services
- ✅ **Appointment Management**: Book, update, and cancel appointments
- ✅ **Status Tracking**: View appointment status (Pending/Approved/Denied)
- ✅ **Conflict Prevention**: Automatic checking for appointment time conflicts

### 👨‍⚕️ Doctor Panel
- ✅ **Appointment Dashboard**: View only assigned appointments
- ✅ **Decision Making**: Approve or deny appointment requests
- ✅ **Patient Information**: View patient details and service requirements
- ✅ **Schedule Management**: Organize and manage appointment workflow

### 📊 Manager Panel
- ✅ **User Management**: Register doctors with encrypted passwords
- ✅ **Service Administration**: Register services and assign to doctors
- ✅ **Global Overview**: View all appointments across the system
- ✅ **System Control**: Complete administrative control over the system

---

## 🔧 Technology Stack

| Component | Technology | Version | Purpose |
|-----------|------------|---------|---------|
| **Language** | C# | .NET Framework 4.7.2 | Core application logic |
| **UI Framework** | Windows Forms | Built-in | Desktop user interface |
| **Database** | File-based Text Database | Custom | Data persistence (no external dependencies) |
| **Data Access** | Custom ADO.NET Patterns | - | Database operations simulation |
| **Security** | SHA256 Hashing | System.Security.Cryptography | Password encryption |
| **Architecture** | 3-Tier Architecture | - | UI → Business Logic → Data Layer |

---

## 📋 System Requirements

### **Minimum Requirements**
- **Operating System**: Windows 7 SP1 or later
- **Framework**: .NET Framework 4.7.2 or later
- **Development**: Visual Studio 2017 or later (for development)
- **Memory**: 2GB RAM minimum
- **Storage**: 50MB free disk space

### **Recommended Requirements**
- **Operating System**: Windows 10 or later
- **Framework**: .NET Framework 4.8 or later
- **Development**: Visual Studio 2019 or later
- **Memory**: 4GB RAM or more
- **Storage**: 100MB free disk space

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
