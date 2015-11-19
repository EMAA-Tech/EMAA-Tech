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

            PatientMonitor.DatabaseDataSet databaseDataSet = ((PatientMonitor.DatabaseDataSet)(this.FindResource("databaseDataSet")));
            // Load data into the table Patient. You can modify this code as needed.
            PatientMonitor.DatabaseDataSetTableAdapters.PatientTableAdapter databaseDataSetPatientTableAdapter = new PatientMonitor.DatabaseDataSetTableAdapters.PatientTableAdapter();
            databaseDataSetPatientTableAdapter.Fill(databaseDataSet.Patient);
            System.Windows.Data.CollectionViewSource patientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("patientViewSource")));
            patientViewSource.View.MoveCurrentToFirst();
        }

        private void buttonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection dataConnection = new OleDbConnection();
            dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source..\..\..\database\Database.accdb");

            {

                OleDbCommand Add = new OleDbCommand();
                Add.CommandText = "INSERT INTO Patient(NHSNo,Name, BedNo,) VALUES (" + txtNHS.Text + ", '" + txtName.Text + "' ,'" + txtBed.Text + " ', " + "')";

                Add.Connection = dataConnection;
                Add.Connection.Open();
                Add.ExecuteNonQuery();
                DataTable dt = new DataTable();

                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Patient", dataConnection);
                adapt.Fill(dt);
                patientDataGrid.DataContext = dt;

                Add.Connection.Close();


            }



        }

        private void buttonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {


            OleDbConnection dataConnection = new OleDbConnection();

            dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source..\..\..\database\Database.accdb");
            {

                OleDbCommand Delete = new OleDbCommand();
                Delete.CommandText = "DELETE FROM Patient WHERE Name = '" + txtName.Text + "'";
                Delete.Connection = dataConnection;
                Delete.Connection.Open();
                Delete.ExecuteNonQuery();


                DataTable dt = new DataTable();
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Patient", dataConnection);
                adapt.Fill(dt);
                patientDataGrid.DataContext = dt;

                Delete.Connection.Close();



            }



        }

        private void buttonUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {



            OleDbConnection dataConnection = new OleDbConnection();

            dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source..\..\..\database\Database.accdb");
            {
                OleDbCommand Update = new OleDbCommand();
                Update.CommandText = "UPDATE Patient SET Name = '" + txtName.Text + "', NHSNO = '" + txtNHS.Text + "' WHERE BedNo = " + txtBed.Text;

                Update.Connection = dataConnection;

                Update.Connection.Open();

                Update.ExecuteNonQuery();


                DataTable dt = new DataTable();
                OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Patient", dataConnection);
                adapt.Fill(dt);
                patientDataGrid.DataContext = dt;

                Update.Connection.Close();

            }



        }
    }
}
