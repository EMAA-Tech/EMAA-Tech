﻿using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Data;
using System.Data.OleDb;

namespace PatientMonitor
{
    class PatientMonitoringController
    {
        readonly BedsideMonitoringStation _mainWindow = null;
        readonly IPatientFactory _patientFactory = null;
        DispatcherTimer _tickTimer = new DispatcherTimer();
        PatientDataReader _dataReader;
        PatientData _patientData;

        PatientAlarmer _alarmer, _alarmer1, _alarmer2, _alarmer3, _alarmer4, _alarmer5, _alarmer6, _alarmer7;
        bool alarmActivated, alarmActivated1, alarmActivated2, alarmActivated3, alarmActivated4, alarmActivated5, alarmActivated6, alarmActivated7 = false;

        Label _pulseRate, _pulseRate1, _pulseRate2, _pulseRate3, _pulseRate4, _pulseRate5, _pulseRate6, _pulseRate7;
        Label _breathingRate, _breathingRate1, _breathingRate2, _breathingRate3, _breathingRate4, _breathingRate5, _breathingRate6, _breathingRate7;
        Label _systolicPressure, _systolicPressure1, _systolicPressure2, _systolicPressure3, _systolicPressure4, _systolicPressure5, _systolicPressure6, _systolicPressure7;
        Label _diastolicPressure, _diastolicPressure1, _diastolicPressure2, _diastolicPressure3, _diastolicPressure4, _diastolicPressure5, _diastolicPressure6, _diastolicPressure7;
        Label _temperature, _temperature1, _temperature2, _temperature3, _temperature4, _temperature5, _temperature6, _temperature7;

        public PatientMonitoringController(BedsideMonitoringStation window, IPatientFactory patientFactory)
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
        }

        public void RunMonitor()
        {
            setupComponents();
            newPatientSelected();
        }

        void setupComponents()
        {
            _patientData = (PatientData)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientData);
            _dataReader = (PatientDataReader)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientDataReader);
            _alarmer = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer1 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer2 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer3 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer4 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer5 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer6 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);
            _alarmer7 = (PatientAlarmer)_patientFactory.CreateandReturnObj(PatientClassesEnumeration.PatientAlarmer);

            _alarmer.BreathingRateAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.DiastolicBloodPressureAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.PulseRateAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.SystolicBloodPressureAlarm += new EventHandler(soundMutableAlarm);
            _alarmer.TemperatureAlarm += new EventHandler(soundMutableAlarm);

            _alarmer1.BreathingRateAlarm += new EventHandler(soundMutableAlarm1);
            _alarmer1.DiastolicBloodPressureAlarm += new EventHandler(soundMutableAlarm1);
            _alarmer1.PulseRateAlarm += new EventHandler(soundMutableAlarm1);
            _alarmer1.SystolicBloodPressureAlarm += new EventHandler(soundMutableAlarm1);
            _alarmer1.TemperatureAlarm += new EventHandler(soundMutableAlarm1);

            _alarmer2.BreathingRateAlarm2 += new EventHandler(soundMutableAlarm2);
            _alarmer2.DiastolicBloodPressureAlarm2 += new EventHandler(soundMutableAlarm2);
            _alarmer2.PulseRateAlarm2 += new EventHandler(soundMutableAlarm2);
            _alarmer2.SystolicBloodPressureAlarm2 += new EventHandler(soundMutableAlarm2);
            _alarmer2.TemperatureAlarm2 += new EventHandler(soundMutableAlarm2);

            _alarmer3.BreathingRateAlarm3 += new EventHandler(soundMutableAlarm3);
            _alarmer3.DiastolicBloodPressureAlarm3 += new EventHandler(soundMutableAlarm3);
            _alarmer3.PulseRateAlarm3 += new EventHandler(soundMutableAlarm3);
            _alarmer3.SystolicBloodPressureAlarm3 += new EventHandler(soundMutableAlarm3);
            _alarmer3.TemperatureAlarm3 += new EventHandler(soundMutableAlarm3);

            _alarmer4.BreathingRateAlarm4 += new EventHandler(soundMutableAlarm4);
            _alarmer4.DiastolicBloodPressureAlarm4 += new EventHandler(soundMutableAlarm4);
            _alarmer4.PulseRateAlarm4 += new EventHandler(soundMutableAlarm4);
            _alarmer4.SystolicBloodPressureAlarm4 += new EventHandler(soundMutableAlarm4);
            _alarmer4.TemperatureAlarm4 += new EventHandler(soundMutableAlarm4);

            _alarmer5.BreathingRateAlarm5 += new EventHandler(soundMutableAlarm5);
            _alarmer5.DiastolicBloodPressureAlarm5 += new EventHandler(soundMutableAlarm5);
            _alarmer5.PulseRateAlarm5 += new EventHandler(soundMutableAlarm5);
            _alarmer5.SystolicBloodPressureAlarm5 += new EventHandler(soundMutableAlarm5);
            _alarmer5.TemperatureAlarm5 += new EventHandler(soundMutableAlarm5);

            _alarmer6.BreathingRateAlarm6 += new EventHandler(soundMutableAlarm6);
            _alarmer6.DiastolicBloodPressureAlarm6 += new EventHandler(soundMutableAlarm6);
            _alarmer6.PulseRateAlarm6 += new EventHandler(soundMutableAlarm6);
            _alarmer6.SystolicBloodPressureAlarm6 += new EventHandler(soundMutableAlarm6);
            _alarmer6.TemperatureAlarm6 += new EventHandler(soundMutableAlarm6);

            _alarmer7.BreathingRateAlarm7 += new EventHandler(soundMutableAlarm7);
            _alarmer7.DiastolicBloodPressureAlarm7 += new EventHandler(soundMutableAlarm7);
            _alarmer7.PulseRateAlarm7 += new EventHandler(soundMutableAlarm7);
            _alarmer7.SystolicBloodPressureAlarm7 += new EventHandler(soundMutableAlarm7);
            _alarmer7.TemperatureAlarm7 += new EventHandler(soundMutableAlarm7);

            _tickTimer.Stop();
            _tickTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _tickTimer.Tick += new EventHandler(updateReadings);
        }
       
        void updateReadings(object sender, EventArgs e)
        {
                OleDbConnection dataConnection = new OleDbConnection();
                DataTable dt = new DataTable();
                dataConnection.ConnectionString = dataConnection.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\database\\database.accdb");
                string sql = "select Name from Patient where BedNo  = '1'";
                OleDbDataAdapter adapt = new OleDbDataAdapter(sql, dataConnection);
                adapt.Fill(dt);
                string Name = dt.Rows[0][0].ToString();

            if (Name != "0")
            {
                _patientData.SetPatientData(_dataReader.getData());
                _pulseRate.Content = _patientData.PulseRate;
                _breathingRate.Content = _patientData.BreathingRate;
                _systolicPressure.Content = _patientData.SystolicBloodPressure;
                _diastolicPressure.Content = _patientData.DiastolicBloodPressure;
                _temperature.Content = _patientData.Temperature;
                _alarmer.ReadingsTest(_patientData);
            }
            DataTable dt2 = new DataTable();
            string sql2 = "select Name from Patient where BedNo  = '2'";
            OleDbDataAdapter adapt2 = new OleDbDataAdapter(sql2, dataConnection);
            adapt2.Fill(dt2);
            string Name1 = dt2.Rows[0][0].ToString();

            if (Name1 != "0")
            {
                _patientData.SetPatientData(_dataReader.getData1());
                _pulseRate1.Content = _patientData.PulseRate;
                _breathingRate1.Content = _patientData.BreathingRate;
                _systolicPressure1.Content = _patientData.SystolicBloodPressure;
                _diastolicPressure1.Content = _patientData.DiastolicBloodPressure;
                _temperature1.Content = _patientData.Temperature;
                _alarmer1.ReadingsTest(_patientData);
            }

            DataTable dt3 = new DataTable();
            string sql3 = "select Name from Patient where BedNo  = '3'";
            OleDbDataAdapter adapt3 = new OleDbDataAdapter(sql3, dataConnection);
            adapt3.Fill(dt3);
            string Name2 = dt3.Rows[0][0].ToString();

            if (Name2 != "0")
            {
                _patientData.SetPatientData(_dataReader.getData2());
                _pulseRate2.Content = _patientData.PulseRate;
                _breathingRate2.Content = _patientData.BreathingRate;
                _systolicPressure2.Content = _patientData.SystolicBloodPressure;
                _diastolicPressure2.Content = _patientData.DiastolicBloodPressure;
                _temperature2.Content = _patientData.Temperature;
                _alarmer2.ReadingsTest(_patientData);
            }
            DataTable dt4 = new DataTable();
            string sql4 = "select Name from Patient where BedNo  = '4'";
            OleDbDataAdapter adapt4 = new OleDbDataAdapter(sql4, dataConnection);
            adapt4.Fill(dt4);
            string Name3 = dt4.Rows[0][0].ToString();

            if (Name3 != "0")
            {
                _patientData.SetPatientData(_dataReader.getData3());
                _pulseRate3.Content = _patientData.PulseRate;
                _breathingRate3.Content = _patientData.BreathingRate;
                _systolicPressure3.Content = _patientData.SystolicBloodPressure;
                _diastolicPressure3.Content = _patientData.DiastolicBloodPressure;
                _temperature3.Content = _patientData.Temperature;
                _alarmer3.ReadingsTest(_patientData);
            }

            DataTable dt5 = new DataTable();
            string sql5 = "select Name from Patient where BedNo  = '5'";
            OleDbDataAdapter adapt5 = new OleDbDataAdapter(sql5, dataConnection);
            adapt5.Fill(dt5);
            string Name4 = dt5.Rows[0][0].ToString();

            if (Name4 != "0")
            {
                _patientData.SetPatientData(_dataReader.getData4());
                _pulseRate4.Content = _patientData.PulseRate;
                _breathingRate4.Content = _patientData.BreathingRate;
                _systolicPressure4.Content = _patientData.SystolicBloodPressure;
                _diastolicPressure4.Content = _patientData.DiastolicBloodPressure;
                _temperature4.Content = _patientData.Temperature;
                _alarmer4.ReadingsTest(_patientData);
            }

            DataTable dt6 = new DataTable();
            string sql6 = "select Name from Patient where BedNo  = '6'";
            OleDbDataAdapter adapt6 = new OleDbDataAdapter(sql6, dataConnection);
            adapt6.Fill(dt6);
            string Name5 = dt6.Rows[0][0].ToString();

            if (Name5 != "0")
            {
                _patientData.SetPatientData(_dataReader.getData5());
                _pulseRate5.Content = _patientData.PulseRate;
                _breathingRate5.Content = _patientData.BreathingRate;
                _systolicPressure5.Content = _patientData.SystolicBloodPressure;
                _diastolicPressure5.Content = _patientData.DiastolicBloodPressure;
                _temperature5.Content = _patientData.Temperature;
                _alarmer5.ReadingsTest(_patientData);
            }

            DataTable dt7 = new DataTable();
            string sql7 = "select Name from Patient where BedNo  = '7'";
            OleDbDataAdapter adapt7 = new OleDbDataAdapter(sql7, dataConnection);
            adapt7.Fill(dt7);
            string Name6 = dt7.Rows[0][0].ToString();

            if (Name6 != "0")
            {
                _patientData.SetPatientData(_dataReader.getData6());
                _pulseRate6.Content = _patientData.PulseRate;
                _breathingRate6.Content = _patientData.BreathingRate;
                _systolicPressure6.Content = _patientData.SystolicBloodPressure;
                _diastolicPressure6.Content = _patientData.DiastolicBloodPressure;
                _temperature6.Content = _patientData.Temperature;
                _alarmer6.ReadingsTest(_patientData);
            }

            DataTable dt8 = new DataTable();
            string sql8 = "select Name from Patient where BedNo  = '8'";
            OleDbDataAdapter adapt8 = new OleDbDataAdapter(sql8, dataConnection);
            adapt8.Fill(dt8);
            string Name7 = dt8.Rows[0][0].ToString();

            if (Name7 != "0")
            {
                _patientData.SetPatientData(_dataReader.getData7());
                _pulseRate7.Content = _patientData.PulseRate;
                _breathingRate7.Content = _patientData.BreathingRate;
                _systolicPressure7.Content = _patientData.SystolicBloodPressure;
                _diastolicPressure7.Content = _patientData.DiastolicBloodPressure;
                _temperature7.Content = _patientData.Temperature;
                _alarmer7.ReadingsTest(_patientData);
            }
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
            _dataReader.Connect(fileName, fileName1, fileName2, fileName3, fileName4, fileName5, fileName6, fileName7);
            _tickTimer.Start();
        }
        void addStartOfAlarm(int mute)
        {           
            AddStartOfAlarm addStartofAlarm = new AddStartOfAlarm();
            addStartofAlarm.addStartOfAlarm(mute);
        }
        void soundMutableAlarm(object sender, EventArgs e)
        {
            var changeColor = new SolidColorBrush(Colors.Red);
            if (alarmActivated == false)
            {
                int mute = 1;
                addStartOfAlarm(mute);
                alarmActivated = true;

                _mainWindow.pulseRate.Foreground = changeColor;
                _mainWindow.breathingRate.Foreground = changeColor;
                _mainWindow.systolic.Foreground = changeColor;
                _mainWindow.diastolic.Foreground = changeColor;
                _mainWindow.temperature.Foreground = changeColor;
            }
            _mainWindow.soundMutableAlarm();
        }

        void soundMutableAlarm1(object sender, EventArgs e)
        {
            var changeColor = new SolidColorBrush(Colors.Red);
            if (alarmActivated1 == false)
            {
                int mute = 2;
                addStartOfAlarm(mute);
                alarmActivated1 = true;

                _mainWindow.pulseRate1.Foreground = changeColor;
                _mainWindow.breathingRate1.Foreground = changeColor;
                _mainWindow.systolic1.Foreground = changeColor;
                _mainWindow.diastolic1.Foreground = changeColor;
                _mainWindow.temperature1.Foreground = changeColor;
            }
            _mainWindow.soundMutableAlarm1();
        }
        void soundMutableAlarm2(object sender, EventArgs e)
        {
            var changeColor = new SolidColorBrush(Colors.Red);
            if (alarmActivated2 == false)
            {
                int mute = 3;
                addStartOfAlarm(mute);
                alarmActivated2 = true;

                _mainWindow.pulseRate2.Foreground = changeColor;
                _mainWindow.breathingRate2.Foreground = changeColor;
                _mainWindow.systolic2.Foreground = changeColor;
                _mainWindow.diastolic2.Foreground = changeColor;
                _mainWindow.temperature2.Foreground = changeColor;
            }
            _mainWindow.soundMutableAlarm2();
        }
        void soundMutableAlarm3(object sender, EventArgs e)
        {
            var changeColor = new SolidColorBrush(Colors.Red);
            if (alarmActivated3 == false)
            {
                int mute = 4;
                addStartOfAlarm(mute);
                alarmActivated3 = true;

                _mainWindow.pulseRate3.Foreground = changeColor;
                _mainWindow.breathingRate3.Foreground = changeColor;
                _mainWindow.systolic3.Foreground = changeColor;
                _mainWindow.diastolic3.Foreground = changeColor;
                _mainWindow.temperature3.Foreground = changeColor;
            }
            _mainWindow.soundMutableAlarm3();
        }
        void soundMutableAlarm4(object sender, EventArgs e)
        {
            var changeColor = new SolidColorBrush(Colors.Red);
            if (alarmActivated4 == false)
            {
                int mute = 5;
                addStartOfAlarm(mute);
                alarmActivated4 = true;

                _mainWindow.pulseRate4.Foreground = changeColor;
                _mainWindow.breathingRate4.Foreground = changeColor;
                _mainWindow.systolic4.Foreground = changeColor;
                _mainWindow.diastolic4.Foreground = changeColor;
                _mainWindow.temperature4.Foreground = changeColor;
            }
            _mainWindow.soundMutableAlarm4();
        }
        void soundMutableAlarm5(object sender, EventArgs e)
        {
            var changeColor = new SolidColorBrush(Colors.Red);
            if (alarmActivated5 == false)
            {
                int mute = 6;
                addStartOfAlarm(mute);
                alarmActivated5 = true;

                _mainWindow.pulseRate5.Foreground = changeColor;
                _mainWindow.breathingRate5.Foreground = changeColor;
                _mainWindow.systolic5.Foreground = changeColor;
                _mainWindow.diastolic5.Foreground = changeColor;
                _mainWindow.temperature5.Foreground = changeColor;
            }
            _mainWindow.soundMutableAlarm5();

        }
        void soundMutableAlarm6(object sender, EventArgs e)
        {
            var changeColor = new SolidColorBrush(Colors.Red);
            if (alarmActivated6 == false)
            {
                int mute = 7;
                addStartOfAlarm(mute);
                alarmActivated6 = true;

                _mainWindow.pulseRate6.Foreground = changeColor;
                _mainWindow.breathingRate6.Foreground = changeColor;
                _mainWindow.systolic6.Foreground = changeColor;
                _mainWindow.diastolic6.Foreground = changeColor;
                _mainWindow.temperature6.Foreground = changeColor;
            }
            _mainWindow.soundMutableAlarm6();
        }
        void soundMutableAlarm7(object sender, EventArgs e)
        {
            var changeColor = new SolidColorBrush(Colors.Red);
            if (alarmActivated7 == false)
            {
                int mute = 8;
                addStartOfAlarm(mute);
                alarmActivated7 = true;

                _mainWindow.pulseRate7.Foreground = changeColor;
                _mainWindow.breathingRate7.Foreground = changeColor;
                _mainWindow.systolic7.Foreground = changeColor;
                _mainWindow.diastolic7.Foreground = changeColor;
                _mainWindow.temperature7.Foreground = changeColor;
            }
            _mainWindow.soundMutableAlarm7();
        }
    }
}
