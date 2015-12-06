using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace PatientMonitor
{
    class Logout
    {
        public void logOut()
        {
            OleDbConnection dataConnection = new OleDbConnection();
            DataTable checkLastDate = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            string sql = "SELECT LAST(StaffID)FROM Registration;";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
            adapt.Fill(checkLastDate);
            int checkLast = int.Parse(checkLastDate.Rows[0][0].ToString());

            OleDbCommand command = new OleDbCommand();      
            command.CommandText = "Update Registration SET DeRegistered = @TimeStamp WHERE StaffID = " + checkLast + "";
            command.Parameters.Add("@Timestamp", OleDbType.Date).Value = DateTime.Now;

            command.Connection = dataConnection;
            command.Connection.Open();
            command.ExecuteNonQuery();

            Application.Current.Shutdown();
        }
    }
}
