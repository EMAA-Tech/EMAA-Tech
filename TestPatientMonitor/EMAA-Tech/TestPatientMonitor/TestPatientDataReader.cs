using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitor;

namespace PatientMonitorTest
{
	[TestClass]
	public class TestPatientDataReader
	{
		const string dataLine1 = "60,20,100,70,37.7";
		const string dataLine2 = "62,21,102,72,38";
		
		[TestMethod]
		public void GoodCreation ()
		{
			var pdr = new PatientDataReader (@"..\..\..\TestData.csv");
			Assert.AreEqual (dataLine1, pdr.getData ());
			Assert.AreEqual (dataLine2, pdr.getData ());
		}

		[TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
		public void BadFileName ()
		{
            new PatientDataReader(@"..\..\..\NonExistant.csv");
		}

        /// <summary>
        /// Test unconnected creation then connecting
        /// </summary>
        [TestMethod]
        public void GoodUnconnectedCreation()
        {
            var pdr = new PatientDataReader();
            pdr.Connect(@"..\..\..\TestData.csv");
            Assert.AreEqual(dataLine1, pdr.getData());
            Assert.AreEqual(dataLine2, pdr.getData());
        }

        /// <summary>
        /// Test unconnected creation then connecting to nonexistant file
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void BadUnconnectedFileName()
        {
            var pdr = new PatientDataReader();
            pdr.Connect(@"..\..\..\NonExistant.csv");
        }
	}
}