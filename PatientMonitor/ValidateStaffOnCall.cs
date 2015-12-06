using System.Windows;
using System.Data;
using System.Data.OleDb;

namespace PatientMonitor
{
    class ValidateStaffOnCall
    {
        public void validateStaff()
        {
            OleDbConnection dataConnection = new OleDbConnection();
            DataTable dt = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            string sql = "SELECT LAST(StaffID)FROM Registration";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
            adapt.Fill(dt);
            string StaffID = dt.Rows[0][0].ToString();

            if (StaffID == "")
            {
                MessageBoxResult linkoLogIn = MessageBox.Show("No staff on call. Please log in to proceed!", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                if (linkoLogIn == MessageBoxResult.OK)
                {
                    Employee_login loginScreen = new Employee_login();
                    loginScreen.Show();
                }
            }
            else
            {
                BedsideMonitoringStation mainInterface = new BedsideMonitoringStation();
                mainInterface.Show();
            }
        }
    }
}
