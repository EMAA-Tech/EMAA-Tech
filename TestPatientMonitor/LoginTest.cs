using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.OleDb;


namespace TestPatientMonitor
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void testIfStaffIDisAdded()
        {
            string staffID = "570";
            OleDbConnection dataConnection = new OleDbConnection();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\testDatabase.accdb");
            OleDbCommand Add = new OleDbCommand();
            Add.CommandText = "INSERT INTO Registration (StaffID) VALUES (@StaffID)";

            Add.Parameters.Add("@Timestamp", OleDbType.Date).Value = DateTime.Now;
            Add.Parameters.Add("@StaffID", OleDbType.Integer).Value = staffID;

            Add.Connection = dataConnection;
            Add.Connection.Open();
            Add.ExecuteNonQuery();

            DataTable dt = new DataTable();
            string sql = "select StaffID from MedicalStaff where StaffID  = " + staffID + "";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
            adapt.Fill(dt);
            string staffID2 = dt.Rows[0][0].ToString();

            Assert.AreEqual(staffID, staffID2);
        }

        [TestMethod]
        public void testIfLoginTimeIsAdded()
        {
            DateTime date = DateTime.Now;
            string date1 = date.ToShortDateString() + " 00:00:00";

            OleDbConnection dataConnection = new OleDbConnection();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\testDatabase.accdb");
            OleDbCommand Add = new OleDbCommand();
            Add.CommandText = "INSERT INTO Registration (RegisteredOn) VALUES (date1)";

            Add.Parameters.Add("@Timestamp", OleDbType.Date).Value = date1;

            Add.Connection = dataConnection;
            Add.Connection.Open();
            Add.ExecuteNonQuery();

            DataTable dt = new DataTable();
            string sql2 = "select LAST(RegisteredOn) from Registration";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql2, dataConnection);
            adapt.Fill(dt);
            string date2 = dt.Rows[0][0].ToString();
            
            Assert.AreEqual(date1, date2);
        }

        [TestMethod]
        public void testIfLogoutTimeIsAdded()
        {
            DateTime date = DateTime.Now;
            string date1 = date.ToShortDateString() + " 00:00:00";

            OleDbConnection dataConnection = new OleDbConnection();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\testDatabase.accdb");

            OleDbCommand command = new OleDbCommand();
            command.CommandText = "INSERT INTO Registration (DeRegistered) VALUES (@Timestamp)";

            command.Parameters.Add("@Timestamp", OleDbType.Date).Value = date1;

            command.Connection = dataConnection;
            command.Connection.Open();
            command.ExecuteNonQuery();

            DataTable dt = new DataTable();
            string sql2 = "select LAST(DeRegistered) from Registration";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql2, dataConnection);
            adapt.Fill(dt);
            string date2 = dt.Rows[0][0].ToString();

            Assert.AreEqual(date1, date2);
        }
    }
}
