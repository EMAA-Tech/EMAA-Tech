using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PatientMonitor
{
    class PatientMonitoringController
    {
        readonly MainWindow _mainWindow = null;
        readonly IPatientFactory _patientFactory = null;
        DispatcherTimer _tickTimer = new DispatcherTimer();
        PatientDataReader _dataReader;
        PatientData _patientData;
        PatientAlarmer _alarmer;
        PatientAlarmer _alarmer1;
        PatientAlarmer _alarmer2;
        PatientAlarmer _alarmer3;

        CheckBox _alarmMuter;
        CheckBox _alarmMuter1;
        CheckBox _alarmMuter2;
        CheckBox _alarmMuter3;


        Label _pulseRate, _pulseRate1, _pulseRate2, _pulseRate3, _pulseRate4, _pulseRate5, _pulseRate6, _pulseRate7, _pulseRate8, _pulseRate9;
        Label _breathingRate, _breathingRate1, _breathingRate2, _breathingRate3, _breathingRate4, _breathingRate5, _breathingRate6, _breathingRate7, _breathingRate8, _breathingRate9;
        Label _systolicPressure, _systolicPressure1, _systolicPressure2, _systolicPressure3, _systolicPressure4, _systolicPressure5, _systolicPressure6, _systolicPressure7, _systolicPressure8, _systolicPressure9 ;
        Label _diastolicPressure, _diastolicPressure1, _diastolicPressure2, _diastolicPressure3, _diastolicPressure4, _diastolicPressure5, _diastolicPressure6, _diastolicPressure7, _diastolicPressure8, _diastolicPressure9;
        Label _temperature, _temperature1, _temperature2, _temperature3, _temperature4, _temperature5, _temperature6, _temperature7, _temperature8, _temperature9;


        public PatientMonitoringController(MainWindow window, IPatientFactory patientFactory)
        {
            _patientFactory = patientFactory;
            _mainWindow = window;


            _pulseRate = _mainWindow.pulseRate;
            _breathingRate = _mainWindow.breathingRate;
            _systolicPressure = _mainWindow.systolic;
            _diastolicPressure = _mainWindow.diastolic;
            _temperature = _mainWindow.temperature;

            _pulseRate1 = _mainWindow.pulseRate1;
            _breathingRate1 = _mainWindow.breathingRate1;
            _systolicPressure1 = _mainWindow.systolic1;
            _diastolicPressure1 = _mainWindow.diastolic1;
            _temperature1 = _mainWindow.temperature1;

            _pulseRate2 = _mainWindow.pulseRate2;
            _breathingRate2 = _mainWindow.breathingRate2;
            _systolicPressure2 = _mainWindow.systolic2;
            _diastolicPressure2 = _mainWindow.diastolic2;
            _temperature2 = _mainWindow.temperature2;

            _pulseRate3 = _mainWindow.pulseRate3;
            _breathingRate3 = _mainWindow.breathingRate3;
            _systolicPressure3 = _mainWindow.systolic3;
            _diastolicPressure3 = _mainWindow.diastolic3;
            _temperature3 = _mainWindow.temperature3;

            _pulseRate4 = _mainWindow.pulseRate4;
            _breathingRate4 = _mainWindow.breathingRate4;
            _systolicPressure4 = _mainWindow.systolic4;
            _diastolicPressure4 = _mainWindow.diastolic4;
            _temperature4 = _mainWindow.temperature4;

            _pulseRate5 = _mainWindow.pulseRate5;
            _breathingRate5 = _mainWindow.breathingRate5;
            _systolicPressure5 = _mainWindow.systolic5;
            _diastolicPressure5 = _mainWindow.diastolic5;
            _temperature5 = _mainWindow.temperature5;

            _pulseRate6 = _mainWindow.pulseRate6;
            _breathingRate6 = _mainWindow.breathingRate6;
            _systolicPressure6 = _mainWindow.systolic6;
            _diastolicPressure6 = _mainWindow.diastolic6;
            _temperature6 = _mainWindow.temperature6;

            _pulseRate7 = _mainWindow.pulseRate7;
            _breathingRate7 = _mainWindow.breathingRate7;
            _systolicPressure7 = _mainWindow.systolic7;
            _diastolicPressure7 = _mainWindow.diastolic7;
            _temperature7 = _mainWindow.temperature7;

            _pulseRate8 = _mainWindow.pulseRate8;
            _breathingRate8 = _mainWindow.breathingRate8;
            _systolicPressure8 = _mainWindow.systolic8;
            _diastolicPressure8 = _mainWindow.diastolic8;
            _temperature8 = _mainWindow.temperature8;

            _pulseRate9 = _mainWindow.pulseRate9;
            _breathingRate9 = _mainWindow.breathingRate9;
            _systolicPressure9 = _mainWindow.systolic9;
            _diastolicPressure9 = _mainWindow.diastolic9;
            _temperature9 = _mainWindow.temperature9;

            //_alarmMuter = _mainWindow.AlarmMute;
            //_alarmMuter1 = _mainWindow.AlarmMute1;
            //_alarmMuter2 = _mainWindow.AlarmMute2;
            //_alarmMuter3 = _mainWindow.AlarmMute3;
        }

        public void RunMonitor()
        {
            setupComponents();
            newPatientSelected();

            setupUI();

        }

        void setupUI()
        {
            //_mainWindow.patientSelector.SelectionChanged
            //    += new System.Windows.Controls.SelectionChangedEventHandler(newPatientSelected);

            //sets the uper and lower alarm levels (displays deafults and saves them when changed)
            /// Patient1
            //_mainWindow.heartRateLower.AlarmValue = (int)DefaultSettings.LOWER_PULSE_RATE;
            //_mainWindow.breathingRateLower.AlarmValue = (int)DefaultSettings.LOWER_BREATHING_RATE;
            //_mainWindow.temperatureLower.AlarmValue = (int)DefaultSettings.LOWER_TEMPERATURE;
            //_mainWindow.systolicLower.AlarmValue = (int)DefaultSettings.LOWER_SYSTOLIC;
            //_mainWindow.diastolicLower.AlarmValue = (int)DefaultSettings.LOWER_DIASTOLIC;

            //_mainWindow.heartRateUpper.AlarmValue = (int)DefaultSettings.UPPER_PULSE_RATE;
            //_mainWindow.breathingRateUpper.AlarmValue = (int)DefaultSettings.UPPER_BREATHING_RATE;
            //_mainWindow.temperatureUpper.AlarmValue = (int)DefaultSettings.UPPER_TEMPERATURE;
            //_mainWindow.systolicUpper.AlarmValue = (int)DefaultSettings.UPPER_SYSTOLIC;
            //_mainWindow.diastolicUpper.AlarmValue = (int)DefaultSettings.UPPER_DIASTOLIC;

            //_mainWindow.heartRateLower.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.breathingRateLower.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.temperatureLower.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.systolicLower.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.diastolicLower.ValueChanged += new EventHandler(limitsChanged);

            //_mainWindow.heartRateUpper.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.breathingRateUpper.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.temperatureUpper.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.systolicUpper.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.diastolicUpper.ValueChanged += new EventHandler(limitsChanged);

            ///// Patient2
            //_mainWindow.heartRateLower1.AlarmValue = (int)DefaultSettings.LOWER_PULSE_RATE;
            //_mainWindow.breathingRateLower1.AlarmValue = (int)DefaultSettings.LOWER_BREATHING_RATE;
            //_mainWindow.temperatureLower1.AlarmValue = (int)DefaultSettings.LOWER_TEMPERATURE;
            //_mainWindow.systolicLower1.AlarmValue = (int)DefaultSettings.LOWER_SYSTOLIC;
            //_mainWindow.diastolicLower1.AlarmValue = (int)DefaultSettings.LOWER_DIASTOLIC;

            //_mainWindow.heartRateUpper1.AlarmValue = (int)DefaultSettings.UPPER_PULSE_RATE;
            //_mainWindow.breathingRateUpper1.AlarmValue = (int)DefaultSettings.UPPER_BREATHING_RATE;
            //_mainWindow.temperatureUpper1.AlarmValue = (int)DefaultSettings.UPPER_TEMPERATURE;
            //_mainWindow.systolicUpper1.AlarmValue = (int)DefaultSettings.UPPER_SYSTOLIC;
            //_mainWindow.diastolicUpper1.AlarmValue = (int)DefaultSettings.UPPER_DIASTOLIC;

            //_mainWindow.heartRateLower1.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.breathingRateLower1.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.temperatureLower1.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.systolicLower1.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.diastolicLower1.ValueChanged += new EventHandler(limitsChanged);

            //_mainWindow.heartRateUpper1.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.breathingRateUpper1.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.temperatureUpper1.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.systolicUpper1.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.diastolicUpper1.ValueChanged += new EventHandler(limitsChanged);

            ///// Patient3
            //_mainWindow.heartRateLower2.AlarmValue = (int)DefaultSettings.LOWER_PULSE_RATE;
            //_mainWindow.breathingRateLower2.AlarmValue = (int)DefaultSettings.LOWER_BREATHING_RATE;
            //_mainWindow.temperatureLower2.AlarmValue = (int)DefaultSettings.LOWER_TEMPERATURE;
            //_mainWindow.systolicLower2.AlarmValue = (int)DefaultSettings.LOWER_SYSTOLIC;
            //_mainWindow.diastolicLower2.AlarmValue = (int)DefaultSettings.LOWER_DIASTOLIC;

            //_mainWindow.heartRateUpper2.AlarmValue = (int)DefaultSettings.UPPER_PULSE_RATE;
            //_mainWindow.breathingRateUpper2.AlarmValue = (int)DefaultSettings.UPPER_BREATHING_RATE;
            //_mainWindow.temperatureUpper2.AlarmValue = (int)DefaultSettings.UPPER_TEMPERATURE;
            //_mainWindow.systolicUpper2.AlarmValue = (int)DefaultSettings.UPPER_SYSTOLIC;
            //_mainWindow.diastolicUpper2.AlarmValue = (int)DefaultSettings.UPPER_DIASTOLIC;

            //_mainWindow.heartRateLower2.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.breathingRateLower2.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.temperatureLower2.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.systolicLower2.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.diastolicLower2.ValueChanged += new EventHandler(limitsChanged);

            //_mainWindow.heartRateUpper2.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.breathingRateUpper2.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.temperatureUpper2.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.systolicUpper2.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.diastolicUpper2.ValueChanged += new EventHandler(limitsChanged);

            ///// Patient4
            //_mainWindow.heartRateLower3.AlarmValue = (int)DefaultSettings.LOWER_PULSE_RATE;
            //_mainWindow.breathingRateLower3.AlarmValue = (int)DefaultSettings.LOWER_BREATHING_RATE;
            //_mainWindow.temperatureLower3.AlarmValue = (int)DefaultSettings.LOWER_TEMPERATURE;
            //_mainWindow.systolicLower3.AlarmValue = (int)DefaultSettings.LOWER_SYSTOLIC;
            //_mainWindow.diastolicLower3.AlarmValue = (int)DefaultSettings.LOWER_DIASTOLIC;

            //_mainWindow.heartRateUpper3.AlarmValue = (int)DefaultSettings.UPPER_PULSE_RATE;
            //_mainWindow.breathingRateUpper3.AlarmValue = (int)DefaultSettings.UPPER_BREATHING_RATE;
            //_mainWindow.temperatureUpper3.AlarmValue = (int)DefaultSettings.UPPER_TEMPERATURE;
            //_mainWindow.systolicUpper3.AlarmValue = (int)DefaultSettings.UPPER_SYSTOLIC;
            //_mainWindow.diastolicUpper3.AlarmValue = (int)DefaultSettings.UPPER_DIASTOLIC;

            //_mainWindow.heartRateLower3.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.breathingRateLower3.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.temperatureLower3.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.systolicLower3.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.diastolicLower3.ValueChanged += new EventHandler(limitsChanged);

            //_mainWindow.heartRateUpper3.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.breathingRateUpper3.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.temperatureUpper3.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.systolicUpper3.ValueChanged += new EventHandler(limitsChanged);
            //_mainWindow.diastolicUpper3.ValueChanged += new EventHandler(limitsChanged);

        }

        void limitsChanged(object sender, EventArgs e)
        {
            //Patient 1 alarm changed
            //_alarmer.PulseRateTester.LowerLimit = _mainWindow.heartRateLower.AlarmValue;
            //_alarmer.BreathingRateTester.LowerLimit = _mainWindow.breathingRateLower.AlarmValue;
            //_alarmer.TemperatureTester.LowerLimit = _mainWindow.temperatureLower.AlarmValue;
            //_alarmer.SystolicBpTester.LowerLimit = _mainWindow.systolicLower.AlarmValue;
            //_alarmer.DiastolicBpTester.LowerLimit = _mainWindow.diastolicLower.AlarmValue;

            //_alarmer.PulseRateTester.UpperLimit = _mainWindow.heartRateUpper.AlarmValue;
            //_alarmer.BreathingRateTester.UpperLimit = _mainWindow.breathingRateUpper.AlarmValue;
            //_alarmer.TemperatureTester.UpperLimit = _mainWindow.temperatureUpper.AlarmValue;
            //_alarmer.SystolicBpTester.UpperLimit = _mainWindow.systolicUpper.AlarmValue;
            //_alarmer.DiastolicBpTester.UpperLimit = _mainWindow.diastolicUpper.AlarmValue;

            //Patient 2 alarm changed
            //_alarmer1.PulseRateTester.LowerLimit = _mainWindow.heartRateLower1.AlarmValue;
            //_alarmer1.BreathingRateTester.LowerLimit = _mainWindow.breathingRateLower1.AlarmValue;
            //_alarmer1.TemperatureTester.LowerLimit = _mainWindow.temperatureLower1.AlarmValue;
            //_alarmer1.SystolicBpTester.LowerLimit = _mainWindow.systolicLower1.AlarmValue;
            //_alarmer1.DiastolicBpTester.LowerLimit = _mainWindow.diastolicLower1.AlarmValue;

            //_alarmer1.PulseRateTester.UpperLimit = _mainWindow.heartRateUpper1.AlarmValue;
            //_alarmer1.BreathingRateTester.UpperLimit = _mainWindow.breathingRateUpper1.AlarmValue;
            //_alarmer1.TemperatureTester.UpperLimit = _mainWindow.temperatureUpper1.AlarmValue;
            //_alarmer1.SystolicBpTester.UpperLimit = _mainWindow.systolicUpper1.AlarmValue;
            //_alarmer1.DiastolicBpTester.UpperLimit = _mainWindow.diastolicUpper1.AlarmValue;

            ////Patient 3 alarm changed
            //_alarmer2.PulseRateTester.LowerLimit = _mainWindow.heartRateLower2.AlarmValue;
            //_alarmer2.BreathingRateTester.LowerLimit = _mainWindow.breathingRateLower2.AlarmValue;
            //_alarmer2.TemperatureTester.LowerLimit = _mainWindow.temperatureLower2.AlarmValue;
            //_alarmer2.SystolicBpTester.LowerLimit = _mainWindow.systolicLower2.AlarmValue;
            //_alarmer2.DiastolicBpTester.LowerLimit = _mainWindow.diastolicLower2.AlarmValue;

            //_alarmer2.PulseRateTester.UpperLimit = _mainWindow.heartRateUpper2.AlarmValue;
            //_alarmer2.BreathingRateTester.UpperLimit = _mainWindow.breathingRateUpper2.AlarmValue;
            //_alarmer2.TemperatureTester.UpperLimit = _mainWindow.temperatureUpper2.AlarmValue;
            //_alarmer2.SystolicBpTester.UpperLimit = _mainWindow.systolicUpper2.AlarmValue;
            //_alarmer2.DiastolicBpTester.UpperLimit = _mainWindow.diastolicUpper2.AlarmValue;

            ////Patient 4 alarm changed
            //_alarmer3.PulseRateTester.LowerLimit = _mainWindow.heartRateLower3.AlarmValue;
            //_alarmer3.BreathingRateTester.LowerLimit = _mainWindow.breathingRateLower3.AlarmValue;
            //_alarmer3.TemperatureTester.LowerLimit = _mainWindow.temperatureLower3.AlarmValue;
            //_alarmer3.SystolicBpTester.LowerLimit = _mainWindow.systolicLower3.AlarmValue;
            //_alarmer3.DiastolicBpTester.LowerLimit = _mainWindow.diastolicLower3.AlarmValue;

            //_alarmer3.PulseRateTester.UpperLimit = _mainWindow.heartRateUpper3.AlarmValue;
            //_alarmer3.BreathingRateTester.UpperLimit = _mainWindow.breathingRateUpper3.AlarmValue;
            //_alarmer3.TemperatureTester.UpperLimit = _mainWindow.temperatureUpper3.AlarmValue;
            //_alarmer3.SystolicBpTester.UpperLimit = _mainWindow.systolicUpper3.AlarmValue;
            //_alarmer3.DiastolicBpTester.UpperLimit = _mainWindow.diastolicUpper3.AlarmValue;
        }

        void setupComponents()
        {
            _patientData = (PatientData)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientData);
            _dataReader = (PatientDataReader)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientDataReader);
            _alarmer = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer1 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer2 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer3 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);

            //Patient 1
            _alarmer.BreathingRateAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.DiastolicBloodPressureAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.PulseRateAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.SystolicBloodPressureAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.TemperatureAlarm += new EventHandler(soundMutableAlarm);

            //Patient 2
            _alarmer1.BreathingRateAlarm += new EventHandler(soundMutableAlarm);
            _alarmer1.DiastolicBloodPressureAlarm += new EventHandler(soundMutableAlarm1);
            _alarmer1.PulseRateAlarm += new EventHandler(soundMutableAlarm1);
            _alarmer1.SystolicBloodPressureAlarm += new EventHandler(soundMutableAlarm1);
            _alarmer1.TemperatureAlarm += new EventHandler(soundMutableAlarm1);

            //Patient 3
            _alarmer2.BreathingRateAlarm += new EventHandler(soundMutableAlarm2);
            _alarmer2.DiastolicBloodPressureAlarm += new EventHandler(soundMutableAlarm2);
            _alarmer2.PulseRateAlarm += new EventHandler(soundMutableAlarm2);
            _alarmer2.SystolicBloodPressureAlarm += new EventHandler(soundMutableAlarm2);
            _alarmer2.TemperatureAlarm += new EventHandler(soundMutableAlarm2);

            //Patient 4
            _alarmer3.BreathingRateAlarm += new EventHandler(soundMutableAlarm3);
            _alarmer3.DiastolicBloodPressureAlarm += new EventHandler(soundMutableAlarm3);
            _alarmer3.PulseRateAlarm += new EventHandler(soundMutableAlarm3);
            _alarmer3.SystolicBloodPressureAlarm += new EventHandler(soundMutableAlarm3);
            _alarmer3.TemperatureAlarm += new EventHandler(soundMutableAlarm3);


            _tickTimer.Stop();
            _tickTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _tickTimer.Tick += new EventHandler(updateReadings);
        }

        void updateReadings(object sender, EventArgs e)
        {
            _patientData.SetPatientData(_dataReader.getData());
            _pulseRate.Content = _patientData.PulseRate;
            _breathingRate.Content = _patientData.BreathingRate;
            _systolicPressure.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure.Content = _patientData.DiastolicBloodPressure;
            _temperature.Content = _patientData.Temperature;
            /*_alarmer.ReadingsTest(_patientData);*/ //  sound alarm


            _patientData.SetPatientData(_dataReader.getData1());
            _pulseRate1.Content = _patientData.PulseRate;
            _breathingRate1.Content = _patientData.BreathingRate;
            _systolicPressure1.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure1.Content = _patientData.DiastolicBloodPressure;
            _temperature1.Content = _patientData.Temperature;
            //_alarmer1.ReadingsTest(_patientData);

            _patientData.SetPatientData(_dataReader.getData2());
            _pulseRate2.Content = _patientData.PulseRate;
            _breathingRate2.Content = _patientData.BreathingRate;
            _systolicPressure2.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure2.Content = _patientData.DiastolicBloodPressure;
            _temperature2.Content = _patientData.Temperature;
            //_alarmer2.ReadingsTest(_patientData);

            _patientData.SetPatientData(_dataReader.getData3());
            _pulseRate3.Content = _patientData.PulseRate;
            _breathingRate3.Content = _patientData.BreathingRate;
            _systolicPressure3.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure3.Content = _patientData.DiastolicBloodPressure;
            _temperature3.Content = _patientData.Temperature;
            //_alarmer3.ReadingsTest(_patientData);

            _patientData.SetPatientData(_dataReader.getData4());
            _pulseRate4.Content = _patientData.PulseRate;
            _breathingRate4.Content = _patientData.BreathingRate;
            _systolicPressure4.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure4.Content = _patientData.DiastolicBloodPressure;
            _temperature4.Content = _patientData.Temperature;

            _patientData.SetPatientData(_dataReader.getData5());
            _pulseRate5.Content = _patientData.PulseRate;
            _breathingRate5.Content = _patientData.BreathingRate;
            _systolicPressure5.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure5.Content = _patientData.DiastolicBloodPressure;
            _temperature5.Content = _patientData.Temperature;

            _patientData.SetPatientData(_dataReader.getData6());
            _pulseRate6.Content = _patientData.PulseRate;
            _breathingRate6.Content = _patientData.BreathingRate;
            _systolicPressure6.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure6.Content = _patientData.DiastolicBloodPressure;
            _temperature6.Content = _patientData.Temperature;

            _patientData.SetPatientData(_dataReader.getData7());
            _pulseRate7.Content = _patientData.PulseRate;
            _breathingRate7.Content = _patientData.BreathingRate;
            _systolicPressure7.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure7.Content = _patientData.DiastolicBloodPressure;
            _temperature7.Content = _patientData.Temperature;

            _patientData.SetPatientData(_dataReader.getData8());
            _pulseRate8.Content = _patientData.PulseRate;
            _breathingRate8.Content = _patientData.BreathingRate;
            _systolicPressure8.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure8.Content = _patientData.DiastolicBloodPressure;
            _temperature8.Content = _patientData.Temperature;

            _patientData.SetPatientData(_dataReader.getData9());
            _pulseRate9.Content = _patientData.PulseRate;
            _breathingRate9.Content = _patientData.BreathingRate;
            _systolicPressure9.Content = _patientData.SystolicBloodPressure;
            _diastolicPressure9.Content = _patientData.DiastolicBloodPressure;
            _temperature9.Content = _patientData.Temperature;

        }

        void newPatientSelected()
        {
            _tickTimer.Stop();
            string fileName = @"..\..\..\" + "Bed 1.csv";
            string fileName1 = @"..\..\..\" + "Bed 2.csv";
            string fileName2 = @"..\..\..\" + "Bed 3.csv";
            string fileName3 = @"..\..\..\" + "Bed 4.csv";
            string fileName4 = @"..\..\..\" + "Bed 5.csv";
            string fileName5 = @"..\..\..\" + "Bed 6.csv";
            string fileName6 = @"..\..\..\" + "Bed 7.csv";
            string fileName7 = @"..\..\..\" + "Bed 8.csv";
            string fileName8 = @"..\..\..\" + "Bed 9.csv";
            string fileName9 = @"..\..\..\" + "Bed 10.csv";
            _dataReader.Connect(fileName, fileName1, fileName2, fileName3, fileName4, fileName5, fileName6, fileName7, fileName8, fileName9);
            _tickTimer.Start();
        }

        void soundMutableAlarm(object sender, EventArgs e)
        {
            if (_alarmMuter.IsChecked == false)
            {
                _mainWindow.soundMutableAlarm();
            }
        }
        void soundMutableAlarm1(object sender, EventArgs e)
        {
            if (_alarmMuter1.IsChecked == false)
            {
                _mainWindow.soundMutableAlarm();
            }
        }
        void soundMutableAlarm2(object sender, EventArgs e)
        {
            if (_alarmMuter2.IsChecked == false)
            {
                _mainWindow.soundMutableAlarm();
            }
        }
        void soundMutableAlarm3(object sender, EventArgs e)
        {
            if (_alarmMuter3.IsChecked == false)
            {
                _mainWindow.soundMutableAlarm();
            }
        }

    }
}
