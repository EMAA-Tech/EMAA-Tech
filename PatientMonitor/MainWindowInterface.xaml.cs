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
using PatientMonitor;




namespace PatientMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer mutable = new SoundPlayer(PatientMonitor.Properties.Resources.Mutable);
        SoundPlayer nonMutable = new SoundPlayer(PatientMonitor.Properties.Resources.NonMutable);
        bool alarmRectified = false;
        bool alarmRectified1 = false;
        bool alarmRectified2 = false;
        bool alarmRectified3 = false;
        bool alarmRectified4 = false;
        bool alarmRectified5 = false;
        bool alarmRectified6 = false;
        bool alarmRectified7 = false;

        public MainWindow()
        {
            InitializeComponent();
            PatientFactory factory = new PatientFactory();
            PatientMonitoringController controller = new PatientMonitoringController(this, factory);
            controller.RunMonitor();
        }

        public void soundMutableAlarm()
        {
            if(alarmRectified == false)
            {
                mutable.Stop();
                mutable.Play();
            }                    
        }
        public void soundMutableAlarm1()
        {
            if (alarmRectified1 == false)
            {
                mutable.Stop();
                mutable.Play();
            }

        }
        public void soundMutableAlarm2()
        {
            if (alarmRectified2 == false)
            {
                mutable.Stop();
                mutable.Play();
            }
        }
        public void soundMutableAlarm3()
        {
            if (alarmRectified3 == false)
            {
                mutable.Stop();
                mutable.Play();
            }
        }
        public void soundMutableAlarm4()
        {
            if (alarmRectified4 == false)
            {
                mutable.Stop();
                mutable.Play();
            }
        }
        public void soundMutableAlarm5()
        {
            if (alarmRectified5 == false)
            {
                mutable.Stop();
                mutable.Play();
            }
        }
        public void soundMutableAlarm6()
        {
            if (alarmRectified6 == false)
            {
                mutable.Stop();
                mutable.Play();
            }
        }
        public void soundMutableAlarm7()
        {
            if (alarmRectified7 == false)
            {
                mutable.Stop();
                mutable.Play();
            }
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

        private void buttonAddPatient_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection dataConnection2 = new OleDbConnection();
            DataTable AddPatientCheck = new DataTable();
            dataConnection2.ConnectionString = dataConnection2.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            string sql1 = "select Name from Patient where BedNo  = '" + txtBed.Text + "'";
            OleDbDataAdapter adapt2 = new OleDbDataAdapter(sql1, dataConnection2);
            adapt2.Fill(AddPatientCheck);
            string checkIfBedEmpty = AddPatientCheck.Rows[0][0].ToString();

            {
                if (checkIfBedEmpty == "0")
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
                    MessageBox.Show("Patient added to bed No " + txtBed.Text, "Patient added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("This bed is still in use!", "Patient can't be added", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonDeletePatient_Click(object sender, RoutedEventArgs e)
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
            MessageBox.Show("Patient deleted!", "Patient deleted", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MuteAlarmbutton_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection dataConnection = new OleDbConnection();
            OleDbConnection rectifyAlarmDateTime = new OleDbConnection();

            rectifyAlarmDateTime.ConnectionString = rectifyAlarmDateTime.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            {              
                DataTable dt = new DataTable();
                dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
                OleDbDataAdapter adapt = new OleDbDataAdapter("select NHSNo from Patient where BedNo = '" + mutePatientSelector.SelectedValue + "'", dataConnection);
                adapt.Fill(dt);
                int NHSNo = int.Parse(dt.Rows[0][0].ToString());

                OleDbCommand command = new OleDbCommand();
                //command.CommandText = "INSERT INTO Alarm (StopTime) VALUES (@TimeStamp) WHERE NHSNo = " + NHSNo + "";
                command.CommandText = "Update Alarm SET StopTime = @TimeStamp WHERE NHSNo = " + NHSNo + "";
                command.Parameters.Add("@Timestamp", OleDbType.Date).Value = DateTime.Now;

                command.Connection = rectifyAlarmDateTime;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            int patientSelected = Convert.ToInt32(mutePatientSelector.SelectedValue);

            if(patientSelected == 1)
            {
                alarmRectified = true;
                pulseRate.Foreground = new SolidColorBrush(Colors.Cyan);
                breathingRate.Foreground = new SolidColorBrush(Colors.Cyan);
                systolic.Foreground = new SolidColorBrush(Colors.Cyan);
                diastolic.Foreground = new SolidColorBrush(Colors.Cyan);
                temperature.Foreground = new SolidColorBrush(Colors.Cyan);
            }
            if (patientSelected == 2)
            {
                alarmRectified1 = true;
                pulseRate1.Foreground = new SolidColorBrush(Colors.Cyan);
                breathingRate1.Foreground = new SolidColorBrush(Colors.Cyan);
                systolic1.Foreground = new SolidColorBrush(Colors.Cyan);
                diastolic1.Foreground = new SolidColorBrush(Colors.Cyan);
                temperature1.Foreground = new SolidColorBrush(Colors.Cyan);
            }
            if (patientSelected == 3)
            {
                alarmRectified2 = true;
                pulseRate2.Foreground = new SolidColorBrush(Colors.Cyan);
                breathingRate2.Foreground = new SolidColorBrush(Colors.Cyan);
                systolic2.Foreground = new SolidColorBrush(Colors.Cyan);
                diastolic2.Foreground = new SolidColorBrush(Colors.Cyan);
                temperature2.Foreground = new SolidColorBrush(Colors.Cyan);
            }
            if (patientSelected == 4)
            {
                alarmRectified3 = true;
                pulseRate3.Foreground = new SolidColorBrush(Colors.Cyan);
                breathingRate3.Foreground = new SolidColorBrush(Colors.Cyan);
                systolic3.Foreground = new SolidColorBrush(Colors.Cyan);
                diastolic3.Foreground = new SolidColorBrush(Colors.Cyan);
                temperature3.Foreground = new SolidColorBrush(Colors.Cyan);
            }
            if (patientSelected == 5)
            {
                alarmRectified4 = true;
                pulseRate4.Foreground = new SolidColorBrush(Colors.Cyan);
                breathingRate4.Foreground = new SolidColorBrush(Colors.Cyan);
                systolic4.Foreground = new SolidColorBrush(Colors.Cyan);
                diastolic4.Foreground = new SolidColorBrush(Colors.Cyan);
                temperature4.Foreground = new SolidColorBrush(Colors.Cyan);
            }
            if (patientSelected == 6)
            {
                alarmRectified5 = true;
                pulseRate5.Foreground = new SolidColorBrush(Colors.Cyan);
                breathingRate5.Foreground = new SolidColorBrush(Colors.Cyan);
                systolic5.Foreground = new SolidColorBrush(Colors.Cyan);
                diastolic5.Foreground = new SolidColorBrush(Colors.Cyan);
                temperature5.Foreground = new SolidColorBrush(Colors.Cyan);
            }
            if (patientSelected == 7)
            {
                alarmRectified6 = true;
                pulseRate6.Foreground = new SolidColorBrush(Colors.Cyan);
                breathingRate6.Foreground = new SolidColorBrush(Colors.Cyan);
                systolic6.Foreground = new SolidColorBrush(Colors.Cyan);
                diastolic6.Foreground = new SolidColorBrush(Colors.Cyan);
                temperature6.Foreground = new SolidColorBrush(Colors.Cyan);
            }
            if (patientSelected == 8)
            {
                alarmRectified7 = true;
                pulseRate7.Foreground = new SolidColorBrush(Colors.Cyan);
                breathingRate7.Foreground = new SolidColorBrush(Colors.Cyan);
                systolic7.Foreground = new SolidColorBrush(Colors.Cyan);
                diastolic7.Foreground = new SolidColorBrush(Colors.Cyan);
                temperature7.Foreground = new SolidColorBrush(Colors.Cyan);
            }
            MessageBox.Show("Patient " + mutePatientSelector.SelectedValue + " muted!" , "Patient muted", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
