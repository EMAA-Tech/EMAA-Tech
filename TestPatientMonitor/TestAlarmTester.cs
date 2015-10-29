using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitor;

namespace PatientMonitorTest
{
	[TestClass]
	public class TestAlarmTester
	{
		AlarmTester createdAlarmTester;

        [TestInitialize]
		public void setup()
		{
			createdAlarmTester = new AlarmTester ("Test Name", 10f, 20f);
		}

		[TestMethod]
		public void alarmTesterGoodCreation()
		{			
			Assert.AreEqual ("Test Name", createdAlarmTester.AlarmName);
			Assert.AreEqual (10f, createdAlarmTester.LowerLimit);
			Assert.AreEqual (20f, createdAlarmTester.UpperLimit);
		}

		[TestMethod]
		public void alarmInLimits()
		{
			Assert.IsFalse (createdAlarmTester.ValueOutsideLimits(15f));
			Assert.IsFalse (createdAlarmTester.ValueOutsideLimits (11f));
			Assert.IsFalse (createdAlarmTester.ValueOutsideLimits (19f));
		}

		[TestMethod]
		public void OutsideLimits()
		{
			Assert.IsTrue (createdAlarmTester.ValueOutsideLimits (9f));
			Assert.IsTrue (createdAlarmTester.ValueOutsideLimits (21f));
		}
	}
}

