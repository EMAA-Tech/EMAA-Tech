using System;

using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitor;

namespace TestMethodPMS
{
	[TestClass]
    public class TestPatientAlarmer
	{
		PatientAlarmer pa;

		[TestInitialize]
		public void setup ()
		{
			pa = new PatientAlarmer ();
		}

		[TestMethod]
		public void NoEventsCalled ()
		{
			var patientData = new Mock<IPatientData> ();
			patientData.Setup (a => a.PulseRate).Returns (65f);
			patientData.Setup (b => b.BreathingRate).Returns (15f);
			patientData.Setup (c => c.SystolicBloodPressure).Returns (135f);
			patientData.Setup (d => d.DiastolicBloodPressure).Returns (85f);
			patientData.Setup (e => e.Temperature).Returns (37f);
			
			var pulseRateRateAlarmWasCalled = false;
			var breathingRateAlarmWasCalled = false;
			var systolicAlarmWasCalled = false;
			var diastolicRateAlarmWasCalled = false;
			var temperatureRateAlarmWasCalled = false;

			pa.PulseRateAlarm += (sender, e) => pulseRateRateAlarmWasCalled = true;
			pa.BreathingRateAlarm += (sender, e) => breathingRateAlarmWasCalled = true;
			pa.SystolicBloodPressureAlarm += (sender, e) => systolicAlarmWasCalled = true;
			pa.DiastolicBloodPressureAlarm += (sender, e) => diastolicRateAlarmWasCalled = true;
			pa.TemperatureAlarm += (sender, e) => temperatureRateAlarmWasCalled = true;
			pa.ReadingsTest (patientData.Object);
			Assert.IsFalse (pulseRateRateAlarmWasCalled);
			Assert.IsFalse (breathingRateAlarmWasCalled);
			Assert.IsFalse (systolicAlarmWasCalled);
			Assert.IsFalse (diastolicRateAlarmWasCalled);
			Assert.IsFalse (temperatureRateAlarmWasCalled);
		}

		[TestMethod]
		public void breathingRateEventWasCalled ()
		{
			var patientData = new Mock<IPatientData> ();
			patientData.Setup (a => a.PulseRate).Returns (65f);
			patientData.Setup (b => b.BreathingRate).Returns (8f);
			patientData.Setup (c => c.SystolicBloodPressure).Returns (135f);
			patientData.Setup (d => d.DiastolicBloodPressure).Returns (75f);
			patientData.Setup (e => e.Temperature).Returns (38f);
			var breathingRateAlarmWasCalled = false;
			pa.BreathingRateAlarm += (sender, e) => breathingRateAlarmWasCalled = true;
			pa.ReadingsTest (patientData.Object);
			Assert.IsTrue (breathingRateAlarmWasCalled);
		}

		[TestMethod]
		public void pulseRateRateEventWasCalled ()
		{
			var patientData = new Mock<IPatientData> ();
			patientData.Setup (a => a.PulseRate).Returns (55f);
			patientData.Setup (b => b.BreathingRate).Returns (15f);
			patientData.Setup (c => c.SystolicBloodPressure).Returns (135f);
			patientData.Setup (d => d.DiastolicBloodPressure).Returns (85f);
			patientData.Setup (e => e.Temperature).Returns (37f);
			var pulseRateRateAlarmWasCalled = false;
			pa.PulseRateAlarm += (sender, e) => pulseRateRateAlarmWasCalled = true;
			pa.ReadingsTest (patientData.Object);
			Assert.IsTrue (pulseRateRateAlarmWasCalled);
		}

		[TestMethod]
		public void SystolicBloodPressureAlarmEventWasCalled ()
		{
			var patientData = new Mock<IPatientData> ();
			patientData.Setup (a => a.PulseRate).Returns (65f);
			patientData.Setup (b => b.BreathingRate).Returns (15f);
			patientData.Setup (c => c.SystolicBloodPressure).Returns (100f);
			patientData.Setup (d => d.DiastolicBloodPressure).Returns (85f);
			patientData.Setup (e => e.Temperature).Returns (37f);
			var systolicAlarmWasCalled = false;
			pa.SystolicBloodPressureAlarm += (sender, e) => systolicAlarmWasCalled = true;
			pa.ReadingsTest (patientData.Object);
			Assert.IsTrue (systolicAlarmWasCalled);
		}

		[TestMethod]
		public void DiastolicBloodPressureEventWasCalled ()
		{
			var patientData = new Mock<IPatientData> ();
			patientData.Setup (a => a.PulseRate).Returns (65f);
			patientData.Setup (b => b.BreathingRate).Returns (15f);
			patientData.Setup (c => c.SystolicBloodPressure).Returns (135f);
			patientData.Setup (d => d.DiastolicBloodPressure).Returns (60f);
			patientData.Setup (e => e.Temperature).Returns (37f);
			var diastolicRateAlarmWasCalled = false;
			pa.DiastolicBloodPressureAlarm += (sender, e) => diastolicRateAlarmWasCalled = true;
			pa.ReadingsTest (patientData.Object);
			Assert.IsTrue (diastolicRateAlarmWasCalled);
		}

		[TestMethod]
		public void TemperatureEventWasCalled ()
		{
			var patientData = new Mock<IPatientData> ();
			patientData.Setup (a => a.PulseRate).Returns (65f);
			patientData.Setup (b => b.BreathingRate).Returns (15f);
			patientData.Setup (c => c.SystolicBloodPressure).Returns (135f);
			patientData.Setup (d => d.DiastolicBloodPressure).Returns (85f);
			patientData.Setup (e => e.Temperature).Returns (35f);
			var temperatureRateAlarmWasCalled = false;
			pa.TemperatureAlarm += (sender, e) => temperatureRateAlarmWasCalled = true;
			pa.ReadingsTest (patientData.Object);
			Assert.IsTrue (temperatureRateAlarmWasCalled);
		}
	}
}

