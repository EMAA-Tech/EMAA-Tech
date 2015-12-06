using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace PatientMonitor
{
    class DeletePatient
    {
        public void deletePatient(string BedNo, DataGrid patientDataGrid)
        {
            OleDbConnection dataConnection = new OleDbConnection();

            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            {

                OleDbCommand Delete = new OleDbCommand();
                Delete.CommandText = "Update Patient SET Name = '0', NHSNo = '0' WHERE BedNo = '" + BedNo + "'";
                Delete.Connection = dataConnection;
                Delete.Connection.Open();
                Delete.ExecuteNonQuery();


                DataTable dt = new DataTable();
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Patient order by BedNo asc", dataConnection);
                adapt.Fill(dt);
                patientDataGrid.DataContext = dt;

                Delete.Connection.Close();
            }
            MessageBox.Show("Patient deleted!", "Patient deleted", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
