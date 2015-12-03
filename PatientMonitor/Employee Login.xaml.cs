using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;

namespace PatientMonitor
{
    /// <summary>
    /// Interaction logic for Employee_login.xaml
    /// </summary>
    public partial class Employee_login : Window
    {
        public Employee_login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int staffID = Convert.ToInt32(txtID.Text);
                OleDbConnection dataConnection = new OleDbConnection();
                DataTable dt = new DataTable();
                dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
                string sql = "select StaffID from MedicalStaff where StaffID  = " + txtID.Text + "";
                OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
                adapt.Fill(dt);
                string Name = dt.Rows[0][0].ToString();

                //if (txtID.Text == Name && passwordBox.Password == "12345")
                if (txtID.Text == Name)
                {
                    dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
                    {
                        OleDbCommand Add = new OleDbCommand();
                        Add.CommandText = "INSERT INTO Registration (RegisteredOn, StaffID) VALUES (@Timestamp, @StaffID)";

                        Add.Parameters.Add("@Timestamp", OleDbType.Date).Value = DateTime.Now;
                        Add.Parameters.Add("@StaffID", OleDbType.Integer).Value = staffID;

                        Add.Connection = dataConnection;
                        Add.Connection.Open();
                        Add.ExecuteNonQuery();
                    }
                    monitoringandalarmdetails CentralStation = new monitoringandalarmdetails();
                    CentralStation.Show();
                    this.Close();
                }
                else
                {
                    txtID.Text = string.Empty;
                    passwordBox.Password = string.Empty;
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
