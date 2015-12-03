using System;
using System.Windows;
using System.Windows.Controls;
using System.Media;
using System.Data;
using System.Data.OleDb;


namespace PatientMonitor
{
    /// <summary>
    /// Interaction logic for monitoringandalarmdetails.xaml
    /// </summary>
    public partial class monitoringandalarmdetails :Window
    {
        readonly MainWindow _mainWindow = null;
        readonly IPatientFactory _patientFactory  = new PatientFactory();

        PatientAlarmer _alarmer;
        CheckBox AlarmMuter;

        SoundPlayer mutable = new SoundPlayer(PatientMonitor.Properties.Resources.Mutable);
        SoundPlayer nonMutable = new SoundPlayer(PatientMonitor.Properties.Resources.NonMutable);

        
        public monitoringandalarmdetails()
        {
           
            InitializeComponent();
            setupComponents();

            heartRateLower.AlarmValue = (int)DefaultSettings.LOWER_PULSE_RATE;
            breathingRateLower.AlarmValue = (int)DefaultSettings.LOWER_BREATHING_RATE;
            temperatureLower.AlarmValue = (int)DefaultSettings.LOWER_TEMPERATURE;
            systolicLower.AlarmValue = (int)DefaultSettings.LOWER_SYSTOLIC;
            diastolicLower.AlarmValue = (int)DefaultSettings.LOWER_DIASTOLIC;

            heartRateUpper.AlarmValue = (int)DefaultSettings.UPPER_PULSE_RATE;
            breathingRateUpper.AlarmValue = (int)DefaultSettings.UPPER_BREATHING_RATE;
            temperatureUpper.AlarmValue = (int)DefaultSettings.UPPER_TEMPERATURE;
            systolicUpper.AlarmValue = (int)DefaultSettings.UPPER_SYSTOLIC;
            diastolicUpper.AlarmValue = (int)DefaultSettings.UPPER_DIASTOLIC;

            heartRateLower.ValueChanged += new EventHandler(limitsChanged);
            breathingRateLower.ValueChanged += new EventHandler(limitsChanged);
            temperatureLower.ValueChanged += new EventHandler(limitsChanged);
            systolicLower.ValueChanged += new EventHandler(limitsChanged);
            diastolicLower.ValueChanged += new EventHandler(limitsChanged);

            heartRateUpper.ValueChanged += new EventHandler(limitsChanged);
            breathingRateUpper.ValueChanged += new EventHandler(limitsChanged);
            temperatureUpper.ValueChanged += new EventHandler(limitsChanged);
            systolicUpper.ValueChanged += new EventHandler(limitsChanged);
            diastolicUpper.ValueChanged += new EventHandler(limitsChanged);

        }

        void limitsChanged(object sender, EventArgs e)
        {
            monitoringandalarmdetails monitor = new monitoringandalarmdetails();
            
            if (_alarmer == null)
            {
                _alarmer = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            }
            _alarmer.PulseRateTester.LowerLimit = heartRateLower.AlarmValue;
            _alarmer.BreathingRateTester.LowerLimit = breathingRateLower.AlarmValue;
            _alarmer.TemperatureTester.LowerLimit = temperatureLower.AlarmValue;
            _alarmer.SystolicBpTester.LowerLimit = systolicLower.AlarmValue;
            _alarmer.DiastolicBpTester.LowerLimit = diastolicLower.AlarmValue;

            _alarmer.PulseRateTester.UpperLimit = heartRateUpper.AlarmValue;
            _alarmer.BreathingRateTester.UpperLimit = breathingRateUpper.AlarmValue;
            _alarmer.TemperatureTester.UpperLimit = temperatureUpper.AlarmValue;
            _alarmer.SystolicBpTester.UpperLimit = systolicUpper.AlarmValue;
            _alarmer.DiastolicBpTester.UpperLimit = diastolicUpper.AlarmValue;
            
        }

        void setupComponents()
        {
            this.patientSelector.SelectionChanged
                += new SelectionChangedEventHandler(newPatientSelected);

            if (_alarmer == null)
            {
                _alarmer = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            }
        }

        void newPatientSelected(object sender,SelectionChangedEventArgs e)
        {
            ComboBox patientSelector = (ComboBox)sender;   
            OleDbConnection dataConnection = new OleDbConnection();
            DataTable dt = new DataTable();
            dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
            string sql = "select * from Patient where BedNo =  '" + patientSelector.SelectedValue + "'";
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
            adapt.Fill(dt);
            nameTextBox.DataContext = dt;
            nHSNoTextBox.DataContext = dt;
            bedNoTextBox.DataContext = dt;
        }



        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you really want to log out?", "Log Out Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                OleDbConnection dataConnection = new OleDbConnection();
                DataTable checkLastDate = new DataTable();
                dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
                string sql = "SELECT LAST(StaffID)FROM Registration;";
                OleDbDataAdapter adapt2 = new OleDbDataAdapter(sql, dataConnection);
                adapt2.Fill(checkLastDate);
                int checkLast = int.Parse(checkLastDate.Rows[0][0].ToString());

                OleDbConnection deRegistartion = new OleDbConnection();
                deRegistartion.ConnectionString = deRegistartion.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");

                OleDbCommand command = new OleDbCommand();
                //command.CommandText = "INSERT INTO Alarm (StopTime) VALUES (@TimeStamp) WHERE NHSNo = " + NHSNo + "";           
                command.CommandText = "Update Registration SET DeRegistered = @TimeStamp WHERE StaffID = " + checkLast + "";
                command.Parameters.Add("@Timestamp", OleDbType.Date).Value = DateTime.Now;

                command.Connection = deRegistartion;
                command.Connection.Open();
                command.ExecuteNonQuery();

                Application.Current.Shutdown();
            }
        }

        private void btnSendEMAIL_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email sent!");
        }

        private void btnSendSMS_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SMS sent!");
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PatientMonitor.DatabaseDataSet databaseDataSet = ((PatientMonitor.DatabaseDataSet)(this.FindResource("databaseDataSet")));
            // Load data into the table Patient. You can modify this code as needed.
            PatientMonitor.DatabaseDataSetTableAdapters.PatientTableAdapter databaseDataSetPatientTableAdapter = new PatientMonitor.DatabaseDataSetTableAdapters.PatientTableAdapter();
            databaseDataSetPatientTableAdapter.Fill(databaseDataSet.Patient);
            System.Windows.Data.CollectionViewSource patientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("patientViewSource")));
            patientViewSource.View.MoveCurrentToFirst();
            // Load data into the table Registration. You can modify this code as needed.
            PatientMonitor.DatabaseDataSetTableAdapters.RegistrationTableAdapter databaseDataSetRegistrationTableAdapter = new PatientMonitor.DatabaseDataSetTableAdapters.RegistrationTableAdapter();
            databaseDataSetRegistrationTableAdapter.Fill(databaseDataSet.Registration);
            System.Windows.Data.CollectionViewSource registrationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("registrationViewSource")));
            registrationViewSource.View.MoveCurrentToFirst();
        }

    }
}
