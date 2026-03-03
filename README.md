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

### 📥 Installation Guide

#### **Option 1: Clone and Run**
```bash
# Clone the repository
git clone https://github.com/Julienmj/Clinic_appointment-_system_DOTNET-Academic-exam-.git
cd Clinic_appointment-_system_DOTNET-Academic-exam-

# Open in Visual Studio
double-click "clinic system.slnx"

# Build and run
Ctrl+Shift+B (Build)
F5 (Run)
```

#### **Option 2: Download ZIP**
1. Visit the repository: https://github.com/Julienmj/Clinic_appointment-_system_DOTNET-Academic-exam-
2. Click "Code" → "Download ZIP"
3. Extract the ZIP file
4. Open `clinic system.slnx` in Visual Studio
5. Build and run the project

### 🎮 First Run Setup

1. **Launch Application** - The Dashboard appears with three role options
2. **Manager Login** - Use default credentials to access admin panel
3. **Register Doctors** - Add at least one doctor to the system
4. **Register Services** - Assign services to doctors
5. **Test Patient Registration** - Create a test patient account

---

## 🖼️ Application Screenshots

### **Dashboard - Main Entry Point**
```
┌─────────────────────────────────────────────────────────────┐
│              Hospital Appointment System                    │
│                                                             │
│    ┌─────────────┐  ┌─────────────┐  ┌─────────────┐       │
│    │   Patient   │  │   Doctor    │  │   Manager   │       │
│    │             │  │             │  │             │       │
│    └─────────────┘  └─────────────┘  └─────────────┘       │
└─────────────────────────────────────────────────────────────┘
```

### **Login Interface**
- Unified login form for all user types
- Email and password authentication
- Role-based redirection after successful login
- Registration link for new patients

### **Patient Panel Features**
- Doctor and service selection dropdowns
- Date/time picker for appointments
- Personal appointment history grid
- Update/cancel appointment options

### **Manager Dashboard**
- Tabbed interface for different functions
- Doctor registration form
- Service management panel
- Global appointments overview

---

## 🔑 Credentials

### 🔐 Default Manager Account
| Field | Value |
|-------|-------|
| **Email** | `manager@clinic.com` |
| **Password** | `admin123` |
| **Access** | Full system administration |
| **Functions** | Register doctors, services, view all appointments |

### 👨‍⚕️ Doctor Accounts
- **Registration**: Only Manager can create doctor accounts
- **Login**: Use email and password created by Manager
- **Access**: View their appointments, approve/deny requests
- **Functions**: Manage patient appointment requests

### 👤 Patient Accounts
- **Registration**: Patients can register themselves
- **Login**: Use email and password created during registration
- **Access**: Book appointments, view their appointments
- **Functions**: Select doctor/service, book/update/cancel appointments

---

## 🔄 Typical Workflow

### **Step 1: System Setup (Manager)**
1. Login as Manager → `manager@clinic.com` / `admin123`
2. Navigate to "Register Doctor" tab
3. Add doctors with their credentials
4. Go to "Register Service" tab
5. Create services and assign to doctors

### **Step 2: Patient Onboarding**
1. Click "Patient" button on Dashboard
2. Click "Register here" link
3. Fill registration form with personal details
4. Login with created credentials

### **Step 3: Appointment Booking**
1. Login as Patient
2. View available doctors and their services
3. Select doctor, service, date, and time
4. Book appointment (system checks for conflicts)

### **Step 4: Appointment Management**
1. Login as Doctor
2. View pending appointment requests
3. Approve or deny based on availability
4. Patient receives status update

## 📁 Project Structure

```
clinic system/
├── � Documentation/
│   ├── �📄 README.md                 # Complete project documentation
│   ├── 📄 SETUP.md                  # Quick setup guide
│   └── 📄 DATABASE_DIAGRAM.txt      # Database schema documentation
├── ⚙️ Configuration/
│   ├── 📄 App.config                # Application configuration
│   ├── 📄 clinic system.csproj      # Project file
│   └── 📄 clinic system.slnx        # Solution file
├── � Application Entry/
│   └── �📄 Program.cs                # Application entry point
├── 🏠 Dashboard/
│   ├── 📄 Dashboard.cs              # Main dashboard logic
│   └── 📄 Dashboard.Designer.cs     # Dashboard UI design
├── 🔐 Authentication/
│   ├── 📄 LoginForm.cs              # Login form logic
│   ├── 📄 LoginForm.Designer.cs     # Login UI design
│   ├── 📄 RegisterForm.cs           # Patient registration logic
│   └── 📄 RegisterForm.Designer.cs  # Registration UI design
├── 👤 Patient Panel/
│   ├── 📄 PatientPanel.cs           # Patient functionality
│   └── 📄 PatientPanel.Designer.cs  # Patient UI design
├── 👨‍⚕️ Doctor Panel/
│   ├── 📄 DoctorPanel.cs            # Doctor functionality
│   └── 📄 DoctorPanel.Designer.cs   # Doctor UI design
├── 📊 Manager Panel/
│   ├── 📄 ManagerPanel.cs           # Manager functionality
│   └── 📄 ManagerPanel.Designer.cs  # Manager UI design
├── 🔧 Utilities/
│   ├── 📄 DatabaseHelper.cs         # File-based database operations
│   └── 📄 SecurityHelper.cs         # Password encryption utilities
└── 📁 Properties/                   # Project properties
    ├── 📄 AssemblyInfo.cs           # Assembly information
    ├── 📄 Resources.Designer.cs     # Resource file designer
    ├── 📄 Resources.resx            # Application resources
    ├── 📄 Settings.Designer.cs      # Settings file designer
    └── 📄 Settings.settings         # Application settings
```

---

## 🗄️ Database Design

### 📊 File-Based Database System

#### **Database Overview**
- **Storage**: `clinic_system.txt` (auto-created on first run)
- **Format**: Structured text file with comma-separated key-value pairs
- **Advantages**: 
  - ✅ No external database server required
  - ✅ Zero installation and configuration
  - ✅ Portable - single file backup
  - ✅ Beginner-friendly and transparent

#### **Data Format Example**
```
PATIENT:id:1,fullname:John Doe,age:30,sex:Male,telephone:1234567890,email:john@email.com,password:a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3
DOCTOR:id:1,fullname:Dr. Smith,email:smith@clinic.com,password:5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8
SERVICE:id:1,service_name:General Checkup,doctor:1
APPOINTMENT:id:1,patient:1,doctor:1,service:1,datetime:2024-01-15 10:00:00,status:Pending
```

### 📋 Database Schema

#### **PATIENT Table**
| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `patient_id` | INTEGER | PRIMARY KEY AUTOINCREMENT | Unique patient identifier |
| `fullname` | TEXT | NOT NULL | Patient's full name |
| `age` | INTEGER | NOT NULL | Patient's age |
| `sex` | TEXT | NOT NULL | Gender (Male/Female) |
| `telephone` | TEXT | NOT NULL | Contact phone number |
| `email` | TEXT | UNIQUE NOT NULL | Email address (login) |
| `password` | TEXT | NOT NULL | SHA256 hashed password |

#### **DOCTOR Table**
| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `doctor_id` | INTEGER | PRIMARY KEY AUTOINCREMENT | Unique doctor identifier |
| `fullname` | TEXT | NOT NULL | Doctor's full name |
| `email` | TEXT | UNIQUE NOT NULL | Email address (login) |
| `password` | TEXT | NOT NULL | SHA256 hashed password |

#### **SERVICE Table**
| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `service_id` | INTEGER | PRIMARY KEY AUTOINCREMENT | Unique service identifier |
| `service_name` | TEXT | NOT NULL | Name of medical service |
| `doctor` | INTEGER | FOREIGN KEY → DOCTOR.doctor_id | Assigned doctor |

#### **APPOINTMENT Table**
| Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| `appointment_id` | INTEGER | PRIMARY KEY AUTOINCREMENT | Unique appointment identifier |
| `patient` | INTEGER | FOREIGN KEY → PATIENT.patient_id | Patient ID |
| `doctor` | INTEGER | FOREIGN KEY → DOCTOR.doctor_id | Doctor ID |
| `service` | INTEGER | FOREIGN KEY → SERVICE.service_id | Service ID |
| `date_time` | TEXT | NOT NULL | Appointment date and time |
| `status` | TEXT | DEFAULT 'Pending' | Appointment status |

### 🔗 Entity Relationship Diagram

```
┌─────────────────┐       ┌─────────────────┐       ┌─────────────────┐
│    PATIENT      │       │   APPOINTMENT   │       │     DOCTOR      │
│─────────────────┤       │─────────────────┤       │─────────────────┤
│ patient_id (PK) │◄──────│ appointment_id │──────►│ doctor_id (PK)  │
│ fullname        │       │ patient (FK)    │       │ fullname        │
│ age             │       │ doctor (FK)     │       │ email           │
│ sex             │       │ service (FK)    │       │ password        │
│ telephone       │       │ date_time       │       └─────────────────┘
│ email           │       │ status          │                │
│ password        │       └─────────────────┘                │
└─────────────────┘                │                         │
         │                        │                         │
         └────────────────────────┼─────────────────────────┘
                                  │
                         ┌─────────────────┐
                         │     SERVICE     │
                         │─────────────────┤
                         │ service_id (PK) │
                         │ service_name    │
                         │ doctor (FK)     │
                         └─────────────────┘
```

### 🔄 Database Operations

#### **Supported Operations**
- ✅ **CREATE**: Insert new records (patients, doctors, services, appointments)
- ✅ **READ**: Query records with filtering and joins
- ✅ **UPDATE**: Modify existing records (appointment status, details)
- ✅ **DELETE**: Remove records (appointment cancellation)
- ✅ **JOIN**: Simulated SQL joins for related data retrieval
- ✅ **AGGREGATE**: Count operations for conflict checking

#### **Query Examples**
```csharp
// Patient Registration
INSERT INTO PATIENT VALUES ('John Doe', 30, 'Male', '1234567890', 'john@email.com', 'hashed_password')

// Doctor Login Verification
SELECT doctor_id, fullname FROM DOCTOR WHERE email = 'doctor@clinic.com' AND password = 'hashed_password'

// Appointment Booking with Conflict Check
SELECT COUNT(*) FROM APPOINTMENT WHERE doctor = 1 AND date_time = '2024-01-15 10:00:00'

// Patient Appointment History
SELECT a.appointment_id, d.fullname, s.service_name, a.date_time, a.status 
FROM APPOINTMENT a JOIN DOCTOR d ON a.doctor = d.doctor_id 
JOIN SERVICE s ON a.service = s.service_id 
WHERE a.patient = 1
```

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
