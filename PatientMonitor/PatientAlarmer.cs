using System;

namespace PatientMonitor
{
	public class PatientAlarmer
	{
        public event EventHandler BreathingRateAlarm, BreathingRateAlarm1, BreathingRateAlarm2, BreathingRateAlarm3, BreathingRateAlarm4, BreathingRateAlarm5, BreathingRateAlarm6, BreathingRateAlarm7;
        public event EventHandler PulseRateAlarm, PulseRateAlarm1, PulseRateAlarm2, PulseRateAlarm3, PulseRateAlarm4, PulseRateAlarm5, PulseRateAlarm6, PulseRateAlarm7;
        public event EventHandler SystolicBloodPressureAlarm, SystolicBloodPressureAlarm1, SystolicBloodPressureAlarm2, SystolicBloodPressureAlarm3, SystolicBloodPressureAlarm4, SystolicBloodPressureAlarm5, SystolicBloodPressureAlarm6, SystolicBloodPressureAlarm7;
        public event EventHandler DiastolicBloodPressureAlarm, DiastolicBloodPressureAlarm1, DiastolicBloodPressureAlarm2, DiastolicBloodPressureAlarm3, DiastolicBloodPressureAlarm4, DiastolicBloodPressureAlarm5, DiastolicBloodPressureAlarm6, DiastolicBloodPressureAlarm7;
        public event EventHandler TemperatureAlarm, TemperatureAlarm1, TemperatureAlarm2, TemperatureAlarm3, TemperatureAlarm4, TemperatureAlarm5, TemperatureAlarm6, TemperatureAlarm7;

		readonly AlarmTester _pulseRateTester = new AlarmTester ("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
		readonly AlarmTester _breathingRateTester = new AlarmTester ("Breathing Rate",DefaultSettings.LOWER_BREATHING_RATE,DefaultSettings.UPPER_BREATHING_RATE);
		readonly AlarmTester _systolicBpTester = new AlarmTester ("Systolic Blood Pressure",DefaultSettings.LOWER_SYSTOLIC,DefaultSettings.UPPER_SYSTOLIC);
		readonly AlarmTester _diastolicBpTester = new AlarmTester ("Diastolic Blood Pressure",DefaultSettings.LOWER_DIASTOLIC,DefaultSettings.UPPER_DIASTOLIC);
		readonly AlarmTester _temperatureTester = new AlarmTester ("Temperature",DefaultSettings.LOWER_TEMPERATURE,DefaultSettings.UPPER_TEMPERATURE);

        readonly AlarmTester _pulseRateTester1 = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        readonly AlarmTester _breathingRateTester1 = new AlarmTester("Breathing Rate", DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE);
        readonly AlarmTester _systolicBpTester1 = new AlarmTester("Systolic Blood Pressure", DefaultSettings.LOWER_SYSTOLIC, DefaultSettings.UPPER_SYSTOLIC);
        readonly AlarmTester _diastolicBpTester1 = new AlarmTester("Diastolic Blood Pressure", DefaultSettings.LOWER_DIASTOLIC, DefaultSettings.UPPER_DIASTOLIC);
        readonly AlarmTester _temperatureTester1 = new AlarmTester("Temperature", DefaultSettings.LOWER_TEMPERATURE, DefaultSettings.UPPER_TEMPERATURE);

        readonly AlarmTester _pulseRateTester2 = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        readonly AlarmTester _breathingRateTester2 = new AlarmTester("Breathing Rate", DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE);
        readonly AlarmTester _systolicBpTester2 = new AlarmTester("Systolic Blood Pressure", DefaultSettings.LOWER_SYSTOLIC, DefaultSettings.UPPER_SYSTOLIC);
        readonly AlarmTester _diastolicBpTester2 = new AlarmTester("Diastolic Blood Pressure", DefaultSettings.LOWER_DIASTOLIC, DefaultSettings.UPPER_DIASTOLIC);
        readonly AlarmTester _temperatureTester2 = new AlarmTester("Temperature", DefaultSettings.LOWER_TEMPERATURE, DefaultSettings.UPPER_TEMPERATURE);

        readonly AlarmTester _pulseRateTester3 = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        readonly AlarmTester _breathingRateTester3 = new AlarmTester("Breathing Rate", DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE);
        readonly AlarmTester _systolicBpTester3 = new AlarmTester("Systolic Blood Pressure", DefaultSettings.LOWER_SYSTOLIC, DefaultSettings.UPPER_SYSTOLIC);
        readonly AlarmTester _diastolicBpTester3 = new AlarmTester("Diastolic Blood Pressure", DefaultSettings.LOWER_DIASTOLIC, DefaultSettings.UPPER_DIASTOLIC);
        readonly AlarmTester _temperatureTester3 = new AlarmTester("Temperature", DefaultSettings.LOWER_TEMPERATURE, DefaultSettings.UPPER_TEMPERATURE);

        readonly AlarmTester _pulseRateTester4 = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        readonly AlarmTester _breathingRateTester4 = new AlarmTester("Breathing Rate", DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE);
        readonly AlarmTester _systolicBpTester4 = new AlarmTester("Systolic Blood Pressure", DefaultSettings.LOWER_SYSTOLIC, DefaultSettings.UPPER_SYSTOLIC);
        readonly AlarmTester _diastolicBpTester4 = new AlarmTester("Diastolic Blood Pressure", DefaultSettings.LOWER_DIASTOLIC, DefaultSettings.UPPER_DIASTOLIC);
        readonly AlarmTester _temperatureTester4 = new AlarmTester("Temperature", DefaultSettings.LOWER_TEMPERATURE, DefaultSettings.UPPER_TEMPERATURE);

        readonly AlarmTester _pulseRateTester5 = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        readonly AlarmTester _breathingRateTester5 = new AlarmTester("Breathing Rate", DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE);
        readonly AlarmTester _systolicBpTester5 = new AlarmTester("Systolic Blood Pressure", DefaultSettings.LOWER_SYSTOLIC, DefaultSettings.UPPER_SYSTOLIC);
        readonly AlarmTester _diastolicBpTester5 = new AlarmTester("Diastolic Blood Pressure", DefaultSettings.LOWER_DIASTOLIC, DefaultSettings.UPPER_DIASTOLIC);
        readonly AlarmTester _temperatureTester5 = new AlarmTester("Temperature", DefaultSettings.LOWER_TEMPERATURE, DefaultSettings.UPPER_TEMPERATURE);

        readonly AlarmTester _pulseRateTester6 = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        readonly AlarmTester _breathingRateTester6 = new AlarmTester("Breathing Rate", DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE);
        readonly AlarmTester _systolicBpTester6 = new AlarmTester("Systolic Blood Pressure", DefaultSettings.LOWER_SYSTOLIC, DefaultSettings.UPPER_SYSTOLIC);
        readonly AlarmTester _diastolicBpTester6 = new AlarmTester("Diastolic Blood Pressure", DefaultSettings.LOWER_DIASTOLIC, DefaultSettings.UPPER_DIASTOLIC);
        readonly AlarmTester _temperatureTester6 = new AlarmTester("Temperature", DefaultSettings.LOWER_TEMPERATURE, DefaultSettings.UPPER_TEMPERATURE);

        readonly AlarmTester _pulseRateTester7 = new AlarmTester("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
        readonly AlarmTester _breathingRateTester7 = new AlarmTester("Breathing Rate", DefaultSettings.LOWER_BREATHING_RATE, DefaultSettings.UPPER_BREATHING_RATE);
        readonly AlarmTester _systolicBpTester7 = new AlarmTester("Systolic Blood Pressure", DefaultSettings.LOWER_SYSTOLIC, DefaultSettings.UPPER_SYSTOLIC);
        readonly AlarmTester _diastolicBpTester7 = new AlarmTester("Diastolic Blood Pressure", DefaultSettings.LOWER_DIASTOLIC, DefaultSettings.UPPER_DIASTOLIC);
        readonly AlarmTester _temperatureTester7 = new AlarmTester("Temperature", DefaultSettings.LOWER_TEMPERATURE, DefaultSettings.UPPER_TEMPERATURE);

        public AlarmTester PulseRateTester { get { return _pulseRateTester; } }
        public AlarmTester BreathingRateTester{ get { return _breathingRateTester; } }
        public AlarmTester SystolicBpTester { get { return _systolicBpTester; } }
        public AlarmTester DiastolicBpTester { get { return _diastolicBpTester; } }
        public AlarmTester TemperatureTester { get { return _temperatureTester; } }

        public AlarmTester PulseRateTester1 { get { return _pulseRateTester1; } }
        public AlarmTester BreathingRateTester1 { get { return _breathingRateTester1; } }
        public AlarmTester SystolicBpTester1 { get { return _systolicBpTester1; } }
        public AlarmTester DiastolicBpTester1 { get { return _diastolicBpTester1; } }
        public AlarmTester TemperatureTester1 { get { return _temperatureTester1; } }

        public AlarmTester PulseRateTester2 { get { return _pulseRateTester2; } }
        public AlarmTester BreathingRateTester2 { get { return _breathingRateTester2; } }
        public AlarmTester SystolicBpTester2 { get { return _systolicBpTester2; } }
        public AlarmTester DiastolicBpTester2 { get { return _diastolicBpTester2; } }
        public AlarmTester TemperatureTester2 { get { return _temperatureTester2; } }

        public AlarmTester PulseRateTester3 { get { return _pulseRateTester3; } }
        public AlarmTester BreathingRateTester3 { get { return _breathingRateTester3; } }
        public AlarmTester SystolicBpTester3 { get { return _systolicBpTester3; } }
        public AlarmTester DiastolicBpTester3 { get { return _diastolicBpTester3; } }
        public AlarmTester TemperatureTester3 { get { return _temperatureTester3; } }

        public AlarmTester PulseRateTester4 { get { return _pulseRateTester4; } }
        public AlarmTester BreathingRateTester4 { get { return _breathingRateTester4; } }
        public AlarmTester SystolicBpTester4 { get { return _systolicBpTester4; } }
        public AlarmTester DiastolicBpTester4 { get { return _diastolicBpTester4; } }
        public AlarmTester TemperatureTester4 { get { return _temperatureTester4; } }

        public AlarmTester PulseRateTester5 { get { return _pulseRateTester5; } }
        public AlarmTester BreathingRateTester5 { get { return _breathingRateTester5; } }
        public AlarmTester SystolicBpTester5 { get { return _systolicBpTester5; } }
        public AlarmTester DiastolicBpTester5 { get { return _diastolicBpTester5; } }
        public AlarmTester TemperatureTester5 { get { return _temperatureTester5; } }

        public AlarmTester PulseRateTester6 { get { return _pulseRateTester6; } }
        public AlarmTester BreathingRateTester6 { get { return _breathingRateTester6; } }
        public AlarmTester SystolicBpTester6 { get { return _systolicBpTester6; } }
        public AlarmTester DiastolicBpTester6 { get { return _diastolicBpTester6; } }
        public AlarmTester TemperatureTester6 { get { return _temperatureTester6; } }

        public AlarmTester PulseRateTester7 { get { return _pulseRateTester7; } }
        public AlarmTester BreathingRateTester7 { get { return _breathingRateTester7; } }
        public AlarmTester SystolicBpTester7 { get { return _systolicBpTester7; } }
        public AlarmTester DiastolicBpTester7 { get { return _diastolicBpTester7; } }
        public AlarmTester TemperatureTester7 { get { return _temperatureTester7; } }

        /// <summary>
        /// Readings test.
        /// </summary>
        /// <param name="readings">Readings.</param>
        public void ReadingsTest(IPatientData readings){

            if (_breathingRateTester.ValueOutsideLimits(readings.BreathingRate) || _breathingRateTester1.ValueOutsideLimits(readings.BreathingRate) || _breathingRateTester2.ValueOutsideLimits(readings.BreathingRate) || _breathingRateTester3.ValueOutsideLimits(readings.BreathingRate) || _breathingRateTester4.ValueOutsideLimits(readings.BreathingRate) || _breathingRateTester5.ValueOutsideLimits(readings.BreathingRate) || _breathingRateTester6.ValueOutsideLimits(readings.BreathingRate) || _breathingRateTester7.ValueOutsideLimits(readings.BreathingRate)) 
            {
				if (BreathingRateAlarm != null) BreathingRateAlarm (this, null);
                if (BreathingRateAlarm1 != null) BreathingRateAlarm1(this, null);
                if (BreathingRateAlarm2 != null) BreathingRateAlarm2(this, null);
                if (BreathingRateAlarm3 != null) BreathingRateAlarm3(this, null);
                if (BreathingRateAlarm4 != null) BreathingRateAlarm4(this, null);
                if (BreathingRateAlarm5 != null) BreathingRateAlarm5(this, null);
                if (BreathingRateAlarm6 != null) BreathingRateAlarm6(this, null);
                if (BreathingRateAlarm7 != null) BreathingRateAlarm7(this, null);
			}
            if (_pulseRateTester.ValueOutsideLimits(readings.PulseRate) || _pulseRateTester1.ValueOutsideLimits(readings.PulseRate) || _pulseRateTester2.ValueOutsideLimits(readings.PulseRate) || _pulseRateTester3.ValueOutsideLimits(readings.PulseRate) || _pulseRateTester4.ValueOutsideLimits(readings.PulseRate) || _pulseRateTester5.ValueOutsideLimits(readings.PulseRate) || _pulseRateTester6.ValueOutsideLimits(readings.PulseRate) || _pulseRateTester7.ValueOutsideLimits(readings.PulseRate))
            {
                if (PulseRateAlarm != null) PulseRateAlarm(this, null);
                if (PulseRateAlarm1 != null) PulseRateAlarm1(this, null);
                if (PulseRateAlarm2 != null) PulseRateAlarm2(this, null);
                if (PulseRateAlarm3 != null) PulseRateAlarm3(this, null);
                if (PulseRateAlarm4 != null) PulseRateAlarm4(this, null);
                if (PulseRateAlarm5 != null) PulseRateAlarm5(this, null);
                if (PulseRateAlarm6 != null) PulseRateAlarm6(this, null);
                if (PulseRateAlarm7 != null) PulseRateAlarm7(this, null);
			}
            if (_systolicBpTester.ValueOutsideLimits(readings.SystolicBloodPressure) || _systolicBpTester1.ValueOutsideLimits(readings.SystolicBloodPressure) || _systolicBpTester2.ValueOutsideLimits(readings.SystolicBloodPressure) || _systolicBpTester3.ValueOutsideLimits(readings.SystolicBloodPressure) || _systolicBpTester4.ValueOutsideLimits(readings.SystolicBloodPressure) || _systolicBpTester5.ValueOutsideLimits(readings.SystolicBloodPressure) || _systolicBpTester6.ValueOutsideLimits(readings.SystolicBloodPressure) || _systolicBpTester7.ValueOutsideLimits(readings.SystolicBloodPressure)) 
            {
				if (SystolicBloodPressureAlarm != null) SystolicBloodPressureAlarm (this, null);
                if (SystolicBloodPressureAlarm1 != null) SystolicBloodPressureAlarm1(this, null);
                if (SystolicBloodPressureAlarm2 != null) SystolicBloodPressureAlarm2(this, null);
                if (SystolicBloodPressureAlarm3 != null) SystolicBloodPressureAlarm3(this, null);
                if (SystolicBloodPressureAlarm4 != null) SystolicBloodPressureAlarm4(this, null);
                if (SystolicBloodPressureAlarm5 != null) SystolicBloodPressureAlarm5(this, null);
                if (SystolicBloodPressureAlarm6 != null) SystolicBloodPressureAlarm6(this, null);
                if (SystolicBloodPressureAlarm7 != null) SystolicBloodPressureAlarm7(this, null);
			}
            if (_diastolicBpTester.ValueOutsideLimits(readings.DiastolicBloodPressure) || _diastolicBpTester1.ValueOutsideLimits(readings.DiastolicBloodPressure) || _diastolicBpTester2.ValueOutsideLimits(readings.DiastolicBloodPressure) || _diastolicBpTester3.ValueOutsideLimits(readings.DiastolicBloodPressure) || _diastolicBpTester4.ValueOutsideLimits(readings.DiastolicBloodPressure) || _diastolicBpTester5.ValueOutsideLimits(readings.DiastolicBloodPressure) || _diastolicBpTester6.ValueOutsideLimits(readings.DiastolicBloodPressure) || _diastolicBpTester7.ValueOutsideLimits(readings.DiastolicBloodPressure)) 
            {
				if (DiastolicBloodPressureAlarm != null) DiastolicBloodPressureAlarm (this, null);
                if (DiastolicBloodPressureAlarm1 != null) DiastolicBloodPressureAlarm1(this, null);
                if (DiastolicBloodPressureAlarm2 != null) DiastolicBloodPressureAlarm2(this, null);
                if (DiastolicBloodPressureAlarm3 != null) DiastolicBloodPressureAlarm3(this, null);
                if (DiastolicBloodPressureAlarm4 != null) DiastolicBloodPressureAlarm4(this, null);
                if (DiastolicBloodPressureAlarm5 != null) DiastolicBloodPressureAlarm5(this, null);
                if (DiastolicBloodPressureAlarm6 != null) DiastolicBloodPressureAlarm6(this, null);
                if (DiastolicBloodPressureAlarm7 != null) DiastolicBloodPressureAlarm7(this, null);
			}
            if (_temperatureTester.ValueOutsideLimits(readings.Temperature) || _temperatureTester1.ValueOutsideLimits(readings.Temperature) || _temperatureTester2.ValueOutsideLimits(readings.Temperature) || _temperatureTester3.ValueOutsideLimits(readings.Temperature) || _temperatureTester4.ValueOutsideLimits(readings.Temperature) || _temperatureTester5.ValueOutsideLimits(readings.Temperature) || _temperatureTester6.ValueOutsideLimits(readings.Temperature) || _temperatureTester7.ValueOutsideLimits(readings.Temperature))
            {
                if (TemperatureAlarm != null) TemperatureAlarm(this, null);
                if (TemperatureAlarm1 != null) TemperatureAlarm1(this, null);
                if (TemperatureAlarm2 != null) TemperatureAlarm2(this, null);
                if (TemperatureAlarm3 != null) TemperatureAlarm3(this, null);
                if (TemperatureAlarm4 != null) TemperatureAlarm4(this, null);
                if (TemperatureAlarm5 != null) TemperatureAlarm5(this, null);
                if (TemperatureAlarm6 != null) TemperatureAlarm6(this, null);
                if (TemperatureAlarm7 != null) TemperatureAlarm7(this, null);               
			}

        }
	}
}

