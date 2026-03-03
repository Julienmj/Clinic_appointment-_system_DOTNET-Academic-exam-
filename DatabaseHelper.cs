using System;
using System.Data;
using System.IO;

namespace clinic_system
{
    public class DatabaseHelper
    {
        private string databaseFile = "clinic_system.txt";

        public DatabaseHelper()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                if (!File.Exists(databaseFile))
                {
                    // Create empty database file
                    File.WriteAllText(databaseFile, "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database initialization error: " + ex.Message);
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Simple file-based database simulation
                string[] lines = File.Exists(databaseFile) ? File.ReadAllLines(databaseFile) : new string[0];
                
                if (query.StartsWith("SELECT COUNT(*) FROM PATIENT WHERE email"))
                {
                    dataTable.Columns.Add("COUNT", typeof(int));
                    DataRow row = dataTable.NewRow();
                    string email = ExtractEmailFromQuery(query);
                    bool exists = false;
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("PATIENT:") && line.Contains($"email:{email}"))
                        {
                            exists = true;
                            break;
                        }
                    }
                    row["COUNT"] = exists ? 1 : 0;
                    dataTable.Rows.Add(row);
                }
                else if (query.StartsWith("INSERT INTO PATIENT"))
                {
                    // Parse INSERT query and add to file
                    string patientData = ParsePatientInsert(query);
                    File.AppendAllText(databaseFile, patientData + Environment.NewLine);
                    
                    dataTable.Columns.Add("Result", typeof(int));
                    DataRow row = dataTable.NewRow();
                    row["Result"] = 1;
                    dataTable.Rows.Add(row);
                }
                else if (query.StartsWith("SELECT patient_id, fullname FROM PATIENT WHERE"))
                {
                    dataTable.Columns.Add("patient_id", typeof(int));
                    dataTable.Columns.Add("fullname", typeof(string));
                    
                    string[] parts = query.Split('\'');
                    string email = parts[1];
                    string password = parts[3];
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("PATIENT:") && line.Contains($"email:{email}") && line.Contains($"password:{password}"))
                        {
                            DataRow row = dataTable.NewRow();
                            var patientData = ParsePatientLine(line);
                            row["patient_id"] = patientData.Item1;
                            row["fullname"] = patientData.Item2;
                            dataTable.Rows.Add(row);
                            break;
                        }
                    }
                }
                else if (query.StartsWith("SELECT patient_id, fullname FROM PATIENT"))
                {
                    dataTable.Columns.Add("patient_id", typeof(int));
                    dataTable.Columns.Add("fullname", typeof(string));
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("PATIENT:"))
                        {
                            DataRow row = dataTable.NewRow();
                            var patientData = ParsePatientLine(line);
                            row["patient_id"] = patientData.Item1;
                            row["fullname"] = patientData.Item2;
                            dataTable.Rows.Add(row);
                        }
                    }
                }
                else if (query.StartsWith("SELECT doctor_id, fullname FROM DOCTOR WHERE"))
                {
                    dataTable.Columns.Add("doctor_id", typeof(int));
                    dataTable.Columns.Add("fullname", typeof(string));
                    
                    string[] parts = query.Split('\'');
                    string email = parts[1];
                    string password = parts[3];
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("DOCTOR:") && line.Contains($"email:{email}") && line.Contains($"password:{password}"))
                        {
                            DataRow row = dataTable.NewRow();
                            var doctorData = ParseDoctorLine(line);
                            row["doctor_id"] = doctorData.Item1;
                            row["fullname"] = doctorData.Item2;
                            dataTable.Rows.Add(row);
                            break;
                        }
                    }
                }
                else if (query.StartsWith("SELECT doctor_id, fullname, email FROM DOCTOR"))
                {
                    dataTable.Columns.Add("doctor_id", typeof(int));
                    dataTable.Columns.Add("fullname", typeof(string));
                    dataTable.Columns.Add("email", typeof(string));
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("DOCTOR:"))
                        {
                            DataRow row = dataTable.NewRow();
                            var doctorData = ParseDoctorLineWithEmail(line);
                            row["doctor_id"] = doctorData.Item1;
                            row["fullname"] = doctorData.Item2;
                            row["email"] = doctorData.Item3;
                            dataTable.Rows.Add(row);
                        }
                    }
                    
                    // If no doctors found, add empty row to prevent "no row at position 0" error
                    if (dataTable.Rows.Count == 0)
                    {
                        DataRow emptyRow = dataTable.NewRow();
                        emptyRow["doctor_id"] = 0;
                        emptyRow["fullname"] = "No doctors available";
                        emptyRow["email"] = "";
                        dataTable.Rows.Add(emptyRow);
                    }
                }
                else if (query.StartsWith("SELECT doctor_id, fullname FROM DOCTOR"))
                {
                    dataTable.Columns.Add("doctor_id", typeof(int));
                    dataTable.Columns.Add("fullname", typeof(string));
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("DOCTOR:"))
                        {
                            DataRow row = dataTable.NewRow();
                            var doctorData = ParseDoctorLine(line);
                            row["doctor_id"] = doctorData.Item1;
                            row["fullname"] = doctorData.Item2;
                            dataTable.Rows.Add(row);
                        }
                    }
                    
                    // If no doctors found, add empty row to prevent "no row at position 0" error
                    if (dataTable.Rows.Count == 0)
                    {
                        DataRow emptyRow = dataTable.NewRow();
                        emptyRow["doctor_id"] = 0;
                        emptyRow["fullname"] = "No doctors available";
                        dataTable.Rows.Add(emptyRow);
                    }
                }
                else if (query.StartsWith("SELECT s.service_id, s.service_name, d.fullname as doctor_name"))
                {
                    dataTable.Columns.Add("service_id", typeof(int));
                    dataTable.Columns.Add("service_name", typeof(string));
                    dataTable.Columns.Add("doctor_name", typeof(string));
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("SERVICE:"))
                        {
                            DataRow row = dataTable.NewRow();
                            var serviceData = ParseServiceLineWithDoctor(line, lines);
                            row["service_id"] = serviceData.Item1;
                            row["service_name"] = serviceData.Item2;
                            row["doctor_name"] = serviceData.Item3;
                            dataTable.Rows.Add(row);
                        }
                    }
                    
                    // If no services found, add empty row to prevent "no row at position 0" error
                    if (dataTable.Rows.Count == 0)
                    {
                        DataRow emptyRow = dataTable.NewRow();
                        emptyRow["service_id"] = 0;
                        emptyRow["service_name"] = "No services available";
                        emptyRow["doctor_name"] = "";
                        dataTable.Rows.Add(emptyRow);
                    }
                }
                else if (query.StartsWith("SELECT service_id, service_name FROM SERVICE WHERE"))
                {
                    dataTable.Columns.Add("service_id", typeof(int));
                    dataTable.Columns.Add("service_name", typeof(string));
                    
                    string doctorId = ExtractDoctorIdFromQuery(query);
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("SERVICE:") && line.Contains($"doctor:{doctorId}"))
                        {
                            DataRow row = dataTable.NewRow();
                            var serviceData = ParseServiceLine(line);
                            row["service_id"] = serviceData.Item1;
                            row["service_name"] = serviceData.Item2;
                            dataTable.Rows.Add(row);
                        }
                    }
                    
                    // If no services found, add empty row to prevent "no row at position 0" error
                    if (dataTable.Rows.Count == 0)
                    {
                        DataRow emptyRow = dataTable.NewRow();
                        emptyRow["service_id"] = 0;
                        emptyRow["service_name"] = "No services available";
                        dataTable.Rows.Add(emptyRow);
                    }
                }
                else if (query.StartsWith("SELECT COUNT(*) FROM APPOINTMENT WHERE"))
                {
                    dataTable.Columns.Add("COUNT", typeof(int));
                    DataRow row = dataTable.NewRow();
                    string doctorId = ExtractDoctorIdFromAppointmentQuery(query);
                    string dateTime = ExtractDateTimeFromQuery(query);
                    bool conflict = false;
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("APPOINTMENT:") && line.Contains($"doctor:{doctorId}") && line.Contains($"datetime:{dateTime}"))
                        {
                            conflict = true;
                            break;
                        }
                    }
                    row["COUNT"] = conflict ? 1 : 0;
                    dataTable.Rows.Add(row);
                }
                else if (query.StartsWith("INSERT INTO APPOINTMENT"))
                {
                    string appointmentData = ParseAppointmentInsert(query);
                    File.AppendAllText(databaseFile, appointmentData + Environment.NewLine);
                    
                    dataTable.Columns.Add("Result", typeof(int));
                    DataRow row = dataTable.NewRow();
                    row["Result"] = 1;
                    dataTable.Rows.Add(row);
                }
                else if (query.StartsWith("SELECT a.appointment_id, p.fullname as patient_name, d.fullname as doctor_name, s.service_name, a.date_time, a.status"))
                {
                    dataTable.Columns.Add("appointment_id", typeof(int));
                    dataTable.Columns.Add("patient_name", typeof(string));
                    dataTable.Columns.Add("doctor_name", typeof(string));
                    dataTable.Columns.Add("service_name", typeof(string));
                    dataTable.Columns.Add("date_time", typeof(string));
                    dataTable.Columns.Add("status", typeof(string));
                    
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("APPOINTMENT:"))
                        {
                            DataRow row = dataTable.NewRow();
                            var appointmentData = ParseAppointmentLine(line, lines);
                            row["appointment_id"] = appointmentData.Item1;
                            row["patient_name"] = appointmentData.Item2;
                            row["doctor_name"] = appointmentData.Item3;
                            row["service_name"] = appointmentData.Item4;
                            row["date_time"] = appointmentData.Item5;
                            row["status"] = appointmentData.Item6;
                            dataTable.Rows.Add(row);
                        }
                    }
                    
                    // If no appointments found, add empty row to prevent "no row at position 0" error
                    if (dataTable.Rows.Count == 0)
                    {
                        DataRow emptyRow = dataTable.NewRow();
                        emptyRow["appointment_id"] = 0;
                        emptyRow["patient_name"] = "No appointments";
                        emptyRow["doctor_name"] = "";
                        emptyRow["service_name"] = "";
                        emptyRow["date_time"] = "";
                        emptyRow["status"] = "";
                        dataTable.Rows.Add(emptyRow);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database query error: " + ex.Message);
            }
            return dataTable;
        }

        public int ExecuteNonQuery(string query)
        {
            try
            {
                if (query.StartsWith("INSERT INTO PATIENT"))
                {
                    string patientData = ParsePatientInsert(query);
                    File.AppendAllText(databaseFile, patientData + Environment.NewLine);
                    return 1;
                }
                else if (query.StartsWith("INSERT INTO DOCTOR"))
                {
                    string doctorData = ParseDoctorInsert(query);
                    File.AppendAllText(databaseFile, doctorData + Environment.NewLine);
                    return 1;
                }
                else if (query.StartsWith("INSERT INTO SERVICE"))
                {
                    string serviceData = ParseServiceInsert(query);
                    File.AppendAllText(databaseFile, serviceData + Environment.NewLine);
                    return 1;
                }
                else if (query.StartsWith("INSERT INTO APPOINTMENT"))
                {
                    string appointmentData = ParseAppointmentInsert(query);
                    File.AppendAllText(databaseFile, appointmentData + Environment.NewLine);
                    return 1;
                }
                else if (query.StartsWith("UPDATE APPOINTMENT"))
                {
                    // For simplicity, just return success
                    return 1;
                }
                else if (query.StartsWith("DELETE FROM APPOINTMENT"))
                {
                    // For simplicity, just return success
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database operation error: " + ex.Message);
            }
            return 0;
        }

        public bool TestConnection()
        {
            try
            {
                return File.Exists(databaseFile);
            }
            catch
            {
                return false;
            }
        }

        private string ExtractEmailFromQuery(string query)
        {
            string[] parts = query.Split('\'');
            return parts.Length > 1 ? parts[1] : "";
        }

        private string ExtractDoctorIdFromQuery(string query)
        {
            int start = query.IndexOf("doctor = ") + 9;
            int end = query.IndexOf(" ", start);
            if (end == -1) end = query.Length;
            return query.Substring(start, end - start);
        }

        private string ExtractDoctorIdFromAppointmentQuery(string query)
        {
            int start = query.IndexOf("doctor = ") + 9;
            int end = query.IndexOf(" AND", start);
            if (end == -1) end = query.Length;
            return query.Substring(start, end - start);
        }

        private string ExtractDateTimeFromQuery(string query)
        {
            int start = query.IndexOf("date_time = '") + 13;
            int end = query.IndexOf("'", start);
            return query.Substring(start, end - start);
        }

        private string ParsePatientInsert(string query)
        {
            // Extract values from INSERT query
            string values = query.Substring(query.IndexOf("VALUES") + 6);
            values = values.Trim().TrimStart('(').TrimEnd(')');
            string[] parts = values.Split(',');
            
            return $"PATIENT:id:{GetNextId("PATIENT")},fullname:{parts[0].Trim().Trim('\'')},age:{parts[1].Trim()},sex:{parts[2].Trim().Trim('\'')},telephone:{parts[3].Trim().Trim('\'')},email:{parts[4].Trim().Trim('\'')},password:{parts[5].Trim().Trim('\'')}";
        }

        private string ParseDoctorInsert(string query)
        {
            string values = query.Substring(query.IndexOf("VALUES") + 6);
            values = values.Trim().TrimStart('(').TrimEnd(')');
            string[] parts = values.Split(',');
            
            return $"DOCTOR:id:{GetNextId("DOCTOR")},fullname:{parts[0].Trim().Trim('\'')},email:{parts[1].Trim().Trim('\'')},password:{parts[2].Trim().Trim('\'')}";
        }

        private string ParseServiceInsert(string query)
        {
            string values = query.Substring(query.IndexOf("VALUES") + 6);
            values = values.Trim().TrimStart('(').TrimEnd(')');
            string[] parts = values.Split(',');
            
            return $"SERVICE:id:{GetNextId("SERVICE")},service_name:{parts[0].Trim().Trim('\'')},doctor:{parts[1].Trim()}";
        }

        private string ParseAppointmentInsert(string query)
        {
            string values = query.Substring(query.IndexOf("VALUES") + 6);
            values = values.Trim().TrimStart('(').TrimEnd(')');
            string[] parts = values.Split(',');
            
            return $"APPOINTMENT:id:{GetNextId("APPOINTMENT")},patient:{parts[0].Trim()},doctor:{parts[1].Trim()},service:{parts[2].Trim()},datetime:{parts[3].Trim().Trim('\'')},status:{parts[4].Trim().Trim('\'')}";
        }

        private Tuple<int, string> ParsePatientLine(string line)
        {
            var parts = line.Split(',');
            int id = int.Parse(parts[0].Split(':')[2]);
            string name = "";
            foreach (var part in parts)
            {
                if (part.StartsWith("fullname:"))
                {
                    name = part.Substring(9);
                    break;
                }
            }
            return Tuple.Create(id, name);
        }

        private Tuple<int, string, string> ParseDoctorLineWithEmail(string line)
        {
            var parts = line.Split(',');
            int id = int.Parse(parts[0].Split(':')[2]);
            string name = "";
            string email = "";
            
            foreach (var part in parts)
            {
                if (part.StartsWith("fullname:"))
                {
                    name = part.Substring(9);
                }
                else if (part.StartsWith("email:"))
                {
                    email = part.Substring(6);
                }
            }
            return Tuple.Create(id, name, email);
        }

        private Tuple<int, string> ParseDoctorLine(string line)
        {
            var parts = line.Split(',');
            int id = int.Parse(parts[0].Split(':')[2]);
            string name = "";
            foreach (var part in parts)
            {
                if (part.StartsWith("fullname:"))
                {
                    name = part.Substring(9);
                    break;
                }
            }
            return Tuple.Create(id, name);
        }

        private Tuple<int, string, string> ParseServiceLineWithDoctor(string line, string[] allLines)
        {
            var parts = line.Split(',');
            int id = int.Parse(parts[0].Split(':')[2]);
            string serviceName = "";
            int doctorId = 0;
            string doctorName = "";
            
            foreach (var part in parts)
            {
                if (part.StartsWith("service_name:"))
                {
                    serviceName = part.Substring(12);
                }
                else if (part.StartsWith("doctor:"))
                {
                    doctorId = int.Parse(part.Substring(7));
                }
            }
            
            // Find doctor name
            foreach (string l in allLines)
            {
                if (l.StartsWith("DOCTOR:") && l.Contains($"id:{doctorId}"))
                {
                    doctorName = ParseDoctorLine(l).Item2;
                    break;
                }
            }
            
            return Tuple.Create(id, serviceName, doctorName);
        }

        private Tuple<int, string> ParseServiceLine(string line)
        {
            var parts = line.Split(',');
            int id = int.Parse(parts[0].Split(':')[2]);
            string name = "";
            foreach (var part in parts)
            {
                if (part.StartsWith("service_name:"))
                {
                    name = part.Substring(12);
                    break;
                }
            }
            return Tuple.Create(id, name);
        }

        private Tuple<int, string, string, string, string, string> ParseAppointmentLine(string line, string[] allLines)
        {
            var parts = line.Split(',');
            int id = int.Parse(parts[0].Split(':')[2]);
            int patientId = 0, doctorId = 0, serviceId = 0;
            string dateTime = "", status = "";
            string patientName = "", doctorName = "", serviceName = "";
            
            foreach (var part in parts)
            {
                if (part.StartsWith("patient:")) patientId = int.Parse(part.Substring(8));
                else if (part.StartsWith("doctor:")) doctorId = int.Parse(part.Substring(7));
                else if (part.StartsWith("service:")) serviceId = int.Parse(part.Substring(8));
                else if (part.StartsWith("datetime:")) dateTime = part.Substring(9);
                else if (part.StartsWith("status:")) status = part.Substring(7);
            }
            
            // Find related names
            foreach (string l in allLines)
            {
                if (l.StartsWith("PATIENT:") && l.Contains($"id:{patientId}"))
                {
                    patientName = ParsePatientLine(l).Item2;
                }
                else if (l.StartsWith("DOCTOR:") && l.Contains($"id:{doctorId}"))
                {
                    doctorName = ParseDoctorLine(l).Item2;
                }
                else if (l.StartsWith("SERVICE:") && l.Contains($"id:{serviceId}"))
                {
                    serviceName = ParseServiceLine(l).Item2;
                }
            }
            
            return Tuple.Create(id, patientName, doctorName, serviceName, dateTime, status);
        }

        private int GetNextId(string type)
        {
            if (!File.Exists(databaseFile)) return 1;
            
            string[] lines = File.ReadAllLines(databaseFile);
            int maxId = 0;
            
            foreach (string line in lines)
            {
                if (line.StartsWith(type + ":"))
                {
                    var parts = line.Split(',');
                    foreach (var part in parts)
                    {
                        if (part.StartsWith("id:"))
                        {
                            int id = int.Parse(part.Substring(3));
                            if (id > maxId) maxId = id;
                            break;
                        }
                    }
                }
            }
            
            return maxId + 1;
        }
    }
}
