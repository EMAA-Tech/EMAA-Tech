using System;
using System.Data;
using System.Data.OleDb;

namespace PatientMonitor
{
    class AddStartOfAlarm
    {
        public void addStartOfAlarm(int mute)
        {
            OleDbConnection dataConnection = new OleDbConnection();
            {
                DataTable checkLastDate = new DataTable();
                dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
                string sql = "SELECT LAST(StaffID)FROM Registration;";
                OleDbDataAdapter adapt2 = new OleDbDataAdapter(sql, dataConnection);
                adapt2.Fill(checkLastDate);
                int checkLast = int.Parse(checkLastDate.Rows[0][0].ToString());

                DataTable dt = new DataTable();
                OleDbDataAdapter adapt = new OleDbDataAdapter("select NHSNo from Patient where BedNo = '" + mute + "'", dataConnection);
                adapt.Fill(dt);
                int NHSNo = int.Parse(dt.Rows[0][0].ToString());

                OleDbCommand command = new OleDbCommand();
                command.CommandText = "INSERT INTO Alarm (StartTime, NHSNo, StaffID) VALUES (@TimeStamp, @NHSNo, @StaffID)";


                command.Parameters.Add("@Timestamp", OleDbType.Date).Value = DateTime.Now;
                command.Parameters.Add("@NHSNo", OleDbType.Integer).Value = NHSNo;
                command.Parameters.Add("@StaffID", OleDbType.Integer).Value = checkLast;

                command.Connection = dataConnection;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
