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
<<<<<<< HEAD
using System.Data;
using System.Data.OleDb;
=======
>>>>>>> origin/master

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
<<<<<<< HEAD
            //Code for changing label color to display visual alarm

            this.pulseRate.Foreground = new SolidColorBrush(Colors.Red);
            this.breathingRate.Foreground = new SolidColorBrush(Colors.Red);
            this.systolic.Foreground = new SolidColorBrush(Colors.Red);
            this.diastolic.Foreground = new SolidColorBrush(Colors.Red);
            this.temperature.Foreground = new SolidColorBrush(Colors.Red);
=======
>>>>>>> origin/master
            mutable.Stop();
            mutable.Play();
        }

        public void soundNonMutableAlarm()
        {
            nonMutable.Stop();
            nonMutable.Play();
<<<<<<< HEAD
=======
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails monitoringAlarmDetails = new monitoringandalarmdetails();
            monitoringAlarmDetails.Show();
            MainWindowInterface mainWindowInterface = new MainWindowInterface();
            //this.Close();
>>>>>>> origin/master
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
            dataConnection.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\\My Documents\\My Desktop\\EMAA-Tech V1.2\\database\\database.accdb");

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

    



    }
}
