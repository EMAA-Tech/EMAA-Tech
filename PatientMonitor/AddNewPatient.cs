using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace PatientMonitor
{
    class AddNewPatient
    {
        public void addPatient(string BedNo, string Name, string NHSNo,DataGrid patientDataGrid)
        {
            MainWindowInterface centralStation = new MainWindowInterface();

            OleDbConnection dataConnection = new OleDbConnection();
            DataTable AddPatientCheck = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            string sql = "select Name from Patient where BedNo  = '" + BedNo + "'";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
            adapt.Fill(AddPatientCheck);
            string checkIfBedEmpty = AddPatientCheck.Rows[0][0].ToString();

            {
                if (checkIfBedEmpty == "0")
                {
                    OleDbCommand Add = new OleDbCommand();
                    Add.CommandText = "Update Patient SET Name = '" + Name + "', NHSNo = " + NHSNo + " WHERE BedNo = '" + BedNo + "'";

                    Add.Connection = dataConnection;

                    Add.Connection.Open();

                    Add.ExecuteNonQuery();

                    DataTable dt = new DataTable();

                    OleDbDataAdapter adapt2 = new OleDbDataAdapter("select * from Patient order by BedNo asc", dataConnection);
                    adapt2.Fill(dt);
                    patientDataGrid.DataContext = dt;

                    Add.Connection.Close();
                    MessageBox.Show("Patient added to bed No " + BedNo, "Patient added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("This bed is still in use!", "Patient can't be added", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
