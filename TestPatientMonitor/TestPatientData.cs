using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitor;

namespace PatientMonitorTest
{
	[TestClass]
	public class TestPatientData
	{
		const string dataLine1 = "60,20,100,70,37.7";
		const string dataLine2 = "62,21,102,72,38";

		[TestMethod]
		public void patientDataCreatedCorrectly()
		{
			var pd = new PatientData (dataLine1);
            patientDataTestOK1(pd);
			var pd2 = new PatientData (dataLine2);
            patientDataTestOK2(pd2);
		}

        [TestMethod]
        public void patientDataSetCorrectly()
        {
            var pd = new PatientData();
            pd.SetPatientData(dataLine1);
            patientDataTestOK1(pd);

            var pd2 = new PatientData();
            pd2.SetPatientData(dataLine2);
            patientDataTestOK2(pd2);
        }

        void patientDataTestOK1(PatientData pd)
        {
            Assert.AreEqual(60.0f, pd.PulseRate);
            Assert.AreEqual(20.0f, pd.BreathingRate);
            Assert.AreEqual(100.0f, pd.SystolicBloodPressure);
            Assert.AreEqual(70.0f, pd.DiastolicBloodPressure);
            Assert.AreEqual(37.7f, pd.Temperature);
        }

        void patientDataTestOK2(PatientData pd)
        {
            Assert.AreEqual(62.0f, pd.PulseRate);
            Assert.AreEqual(21.0f, pd.BreathingRate);
            Assert.AreEqual(102.0f, pd.SystolicBloodPressure);
            Assert.AreEqual(72.0f, pd.DiastolicBloodPressure);
            Assert.AreEqual(38.0f, pd.Temperature);
        }
	}
}

