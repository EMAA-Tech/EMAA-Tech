using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.OleDb;

namespace TestPatientMonitor
{
    [TestClass]
    public class TestAddPatient
    {
        [TestInitialize]
        public void setup()
        {
           
        }
        [TestMethod]
        public void bedIsFull()
        {
            int BedNo = 6;
            bool bedIsEmpty = false;
            OleDbConnection dataConnection = new OleDbConnection();
            DataTable AddPatientCheck = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\testDatabase.accdb");
            string sql = "select Name from Patient where BedNo  = '" + BedNo + "'";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
            adapt.Fill(AddPatientCheck);
            string checkIfBedEmpty = AddPatientCheck.Rows[0][0].ToString();

            if (checkIfBedEmpty == "0")
            {
                bedIsEmpty = true;
            }
            Assert.IsFalse(bedIsEmpty);
        }
        [TestMethod]
        public void bedIsEmpty()
        {
            int BedNo = 6;
            bool bedIsEmpty = false;
            OleDbConnection dataConnection = new OleDbConnection();
            DataTable AddPatientCheck = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\testDatabase.accdb");
            string sql = "select Name from Patient where BedNo  = '" + BedNo + "'";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
            adapt.Fill(AddPatientCheck);
            string checkIfBedEmpty = AddPatientCheck.Rows[0][0].ToString();

                if (checkIfBedEmpty == "0")
                {
                    bedIsEmpty = true;
                }
            Assert.IsTrue(bedIsEmpty);
        }
        [TestMethod]
        public void patientNameIsAdded()
        {
            int BedNo = 6;
            string Name = "Test";
            OleDbConnection dataConnection = new OleDbConnection();
            DataTable AddPatientCheck = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\testDatabase.accdb");

            OleDbCommand Add = new OleDbCommand();
            Add.CommandText = "Update Patient SET Name = '" + Name + "'where BedNo  = '" + BedNo + "'";

            Add.Connection = dataConnection;
            Add.Connection.Open();
            Add.ExecuteNonQuery();

            Add.Connection.Close();
            string sql2 = "select Name from Patient where BedNo  = '" + BedNo + "'";
            OleDbDataAdapter adapt2 = new OleDbDataAdapter(sql2, dataConnection);
            adapt2.Fill(AddPatientCheck);
            string PatientName = AddPatientCheck.Rows[0][0].ToString();

            Assert.AreEqual(Name, PatientName);
        }

        [TestMethod]
        public void patientIsDeleted()
        {
            int BedNo = 6;
            string PatientName1 = "0";
            OleDbConnection dataConnection = new OleDbConnection();

            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\testDatabase.accdb");
            {
                OleDbCommand Delete = new OleDbCommand();
                Delete.CommandText = "Update Patient SET Name = '0' WHERE BedNo = '" + BedNo + "'";
                Delete.Connection = dataConnection;
                Delete.Connection.Open();
                Delete.ExecuteNonQuery();

                Delete.Connection.Close();
            }
            string sql2 = "select Name from Patient where BedNo  = '" + BedNo + "'";
            OleDbDataAdapter adapt2 = new OleDbDataAdapter(sql2, dataConnection);
            DataTable AddPatientCheck = new DataTable();
            adapt2.Fill(AddPatientCheck);
            string PatientName2 = AddPatientCheck.Rows[0][0].ToString();

            Assert.AreEqual(PatientName1, PatientName2);
        }
    }
}
