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
using System.Windows.Threading;
using System.Media;

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
            if (_alarmer == null)
            {
                _alarmer = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            }
            _alarmer = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer.BreathingRateAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.DiastolicBloodPressureAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.PulseRateAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.SystolicBloodPressureAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.TemperatureAlarm += new EventHandler(soundMutableAlarm);
        }


        void soundMutableAlarm(object sender, EventArgs e)
        {
            monitoringandalarmdetails monitor = new monitoringandalarmdetails();
            if (AlarmMuter.IsChecked == false)
            {
                //monitor.soundMutableAlarm();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
             Application.Current.Shutdown();
        }

        private void btnSendEMAIL_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email sent!");
        }

        private void btnSendSMS_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SMS sent!");
        }
    }
}
