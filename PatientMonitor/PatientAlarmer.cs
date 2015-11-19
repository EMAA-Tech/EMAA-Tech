using System;

namespace PatientMonitor
{
	public class PatientAlarmer
	{
		public event EventHandler BreathingRateAlarm;
		public event EventHandler PulseRateAlarm;
		public event EventHandler SystolicBloodPressureAlarm;
		public event EventHandler DiastolicBloodPressureAlarm;
		public event EventHandler TemperatureAlarm;

		readonly AlarmTester _pulseRateTester = new AlarmTester ("Pulse Rate", DefaultSettings.LOWER_PULSE_RATE, DefaultSettings.UPPER_PULSE_RATE);
		readonly AlarmTester _breathingRateTester = new AlarmTester ("Breathing Rate",DefaultSettings.LOWER_BREATHING_RATE,DefaultSettings.UPPER_BREATHING_RATE);
		readonly AlarmTester _systolicBpTester = new AlarmTester ("Systolic Blood Pressure",DefaultSettings.LOWER_SYSTOLIC,DefaultSettings.UPPER_SYSTOLIC);
		readonly AlarmTester _diastolicBpTester = new AlarmTester ("Diastolic Blood Pressure",DefaultSettings.LOWER_DIASTOLIC,DefaultSettings.UPPER_DIASTOLIC);
		readonly AlarmTester _temperatureTester = new AlarmTester ("Temperature",DefaultSettings.LOWER_TEMPERATURE,DefaultSettings.UPPER_TEMPERATURE);

        public AlarmTester PulseRateTester { get { return _pulseRateTester; } }
        public AlarmTester BreathingRateTester { get { return _breathingRateTester; } }
        public AlarmTester SystolicBpTester { get { return _systolicBpTester; } }
        public AlarmTester DiastolicBpTester { get { return _diastolicBpTester; } }
        public AlarmTester TemperatureTester { get { return _temperatureTester; } }

		/// <summary>
		/// Readings test.
		/// </summary>
		/// <param name="readings">Readings.</param>
		public void ReadingsTest(IPatientData readings){
            if (_breathingRateTester.ValueOutsideLimits (readings.BreathingRate)) {
				if (BreathingRateAlarm != null) BreathingRateAlarm (this, null);
			}
            if (_pulseRateTester.ValueOutsideLimits(readings.PulseRate))
            {
				if (PulseRateAlarm != null) PulseRateAlarm (this, null);
			}
			if (_systolicBpTester.ValueOutsideLimits (readings.SystolicBloodPressure)) {
				if (SystolicBloodPressureAlarm != null) SystolicBloodPressureAlarm (this, null);
			}
			if (_diastolicBpTester.ValueOutsideLimits (readings.DiastolicBloodPressure)) {
				if (DiastolicBloodPressureAlarm != null) DiastolicBloodPressureAlarm (this, null);
			}
			if (_temperatureTester.ValueOutsideLimits (readings.Temperature)) {
				if (TemperatureAlarm != null) TemperatureAlarm (this, null);
			}            
		}
	}
}

