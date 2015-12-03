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
            string fileName = @"..\..\..\" + "TestData.csv";
            string fileName1 = @"..\..\..\" + "TestData.csv";
            string fileName2 = @"..\..\..\" + "TestData.csv";
            string fileName3 = @"..\..\..\" + "TestData.csv";
            string fileName4 = @"..\..\..\" + "TestData.csv";
            string fileName5 = @"..\..\..\" + "TestData.csv";
            string fileName6 = @"..\..\..\" + "TestData.csv";
            string fileName7 = @"..\..\..\" + "TestData.csv";
            pdr.Connect(fileName,fileName1,fileName2, fileName3, fileName4, fileName5,fileName6, fileName7);
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
            string fileName = @"..\..\..\" + "NonExistant.csv";
            string fileName1 = @"..\..\..\" + "NonExistant.csv";
            string fileName2 = @"..\..\..\" + "NonExistant.csv";
            string fileName3 = @"..\..\..\" + "NonExistant.csv";
            string fileName4 = @"..\..\..\" + "NonExistant.csv";
            string fileName5 = @"..\..\..\" + "NonExistant.csv";
            string fileName6 = @"..\..\..\" + "NonExistant.csv";
            string fileName7 = @"..\..\..\" + "NonExistant.csv";
            pdr.Connect(fileName, fileName1, fileName2, fileName3, fileName4, fileName5, fileName6, fileName7);
        }
	}
}