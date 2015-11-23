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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.Data;
using System.Data.OleDb;

namespace PatientMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer mutable = new SoundPlayer(PatientMonitor.Properties.Resources.Mutable);
        SoundPlayer nonMutable = new SoundPlayer(PatientMonitor.Properties.Resources.NonMutable);

        public MainWindow()
        {
            InitializeComponent();
            PatientFactory factory = new PatientFactory();
            PatientMonitoringController controller = new PatientMonitoringController(this, factory);
            controller.RunMonitor();
        }

        public void soundMutableAlarm()
        {
            //Code for changing label color to display visual alarm

            this.pulseRate.Foreground = new SolidColorBrush(Colors.Red);
            this.breathingRate.Foreground = new SolidColorBrush(Colors.Red);
            this.systolic.Foreground = new SolidColorBrush(Colors.Red);
            this.diastolic.Foreground = new SolidColorBrush(Colors.Red);
            this.temperature.Foreground = new SolidColorBrush(Colors.Red);
            mutable.Stop();
            mutable.Play();
        }

        public void soundNonMutableAlarm()
        {
            nonMutable.Stop();
            nonMutable.Play();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OleDbConnection dataConnection = new OleDbConnection();
            DataTable dt = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Patient order by BedNo asc", dataConnection);
            adapt.Fill(dt);
            patientDataGrid.DataContext = dt;

            PatientMonitor.DatabaseDataSet databaseDataSet = ((PatientMonitor.DatabaseDataSet)(this.FindResource("databaseDataSet")));
            // Load data into the table Patient. You can modify this code as needed.
            PatientMonitor.DatabaseDataSetTableAdapters.PatientTableAdapter databaseDataSetPatientTableAdapter = new PatientMonitor.DatabaseDataSetTableAdapters.PatientTableAdapter();
            databaseDataSetPatientTableAdapter.Fill(databaseDataSet.Patient);
            System.Windows.Data.CollectionViewSource patientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("patientViewSource")));
            patientViewSource.View.MoveCurrentToFirst();
        }

        private void buttonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection dataConnection2 = new OleDbConnection();
            DataTable AddCustomerCheck = new DataTable();
            dataConnection2.ConnectionString = dataConnection2.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            string sql1 = "select Name from Patient where BedNo  = '" + txtBed.Text + "'";
            OleDbDataAdapter adapt2 = new OleDbDataAdapter(sql1, dataConnection2);
            adapt2.Fill(AddCustomerCheck);
            nameTextBox2.DataContext = AddCustomerCheck;

            {
               
                //Add.CommandText = "INSERT INTO Patient(NHSNo, Name, BedNo) VALUES (" + txtNHS.Text + ", '" + txtName.Text + "' ,'" + txtBed.Text + "')";
                if (nameTextBox2.Text == "0")
                {
                    OleDbConnection dataConnection = new OleDbConnection();
                    OleDbCommand Add = new OleDbCommand();
                    dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
                    Add.CommandText = "Update Patient SET Name = '" + txtName.Text + "', NHSNo = " + txtNHS.Text + " WHERE BedNo = '" + txtBed.Text + "'";

                    Add.Connection = dataConnection;

                    Add.Connection.Open();

                    Add.ExecuteNonQuery();

                    DataTable dt = new DataTable();

                    OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Patient order by BedNo asc", dataConnection);
                    adapt.Fill(dt);
                    patientDataGrid.DataContext = dt;

                    Add.Connection.Close();
                }
                else
                {
                    MessageBox.Show("This bed is still in use!");
                }
            }
        }

        private void buttonUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection dataConnection = new OleDbConnection();
            DataTable dt = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Patient", dataConnection);
            adapt.Fill(dt);
            patientDataGrid.DataContext = dt;
        }

        private void buttonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection dataConnection = new OleDbConnection();

            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            {

                OleDbCommand Delete = new OleDbCommand();
                //Delete.CommandText = "DELETE NHSNo, Name FROM Patient WHERE Name = '" + txtName.Text + "'";
                Delete.CommandText = "Update Patient SET Name = '0', NHSNo = '0' WHERE BedNo = '" + txtBed.Text +"'";
                Delete.Connection = dataConnection;
                Delete.Connection.Open();
                Delete.ExecuteNonQuery();


                DataTable dt = new DataTable();
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Patient order by BedNo asc", dataConnection);
                adapt.Fill(dt);
                patientDataGrid.DataContext = dt;

                Delete.Connection.Close();
            }
        }
    }
}
