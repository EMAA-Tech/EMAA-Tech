using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace PatientMonitor
{
    class Login
    {
        public void StaffLogin(string staffID)
        {
            Employee_login loginScreen = new Employee_login();
            try
            {
                OleDbConnection dataConnection = new OleDbConnection();
                DataTable dt = new DataTable();
                dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
                string sql = "select StaffID from MedicalStaff where StaffID  = " + staffID + "";
                OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
                adapt.Fill(dt);
                string Name = dt.Rows[0][0].ToString();

                //if (txtID.Text == Name && passwordBox.Password == "12345")
                if (staffID == Name)
                {
                        OleDbCommand Add = new OleDbCommand();
                        Add.CommandText = "INSERT INTO Registration (RegisteredOn, StaffID) VALUES (@Timestamp, @StaffID)";

                        Add.Parameters.Add("@Timestamp", OleDbType.Date).Value = DateTime.Now;
                        Add.Parameters.Add("@StaffID", OleDbType.Integer).Value = staffID;

                        Add.Connection = dataConnection;
                        Add.Connection.Open();
                        Add.ExecuteNonQuery();

                    CentralMonitoringStation CentralStation = new CentralMonitoringStation();
                    CentralStation.Show();
                }
                else
                {
                    staffID = string.Empty;
                    loginScreen.passwordBox.Password = string.Empty;
                    MessageBox.Show("Wrong StaffID/Password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Wrong StaffID/Password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
