using System;

namespace PatientMonitor
{
	public class AlarmTester
	{
		/// Gets or sets the lower limit.
		/// <value>The lower limit.</value>
		public float LowerLimit {
			get;
			set;
		}
		/// Gets or sets the upper limit.
		/// <value>The upper limit.</value>
		public float UpperLimit {
			get;
			set;
		}
		/// Gets the name of the alarm.
		/// <value>The name of the alarm.</value>
		public string AlarmName {
			get;
			private set;
		}
		/// Initializes a new instance of the <see cref="PMS.AlarmTester"/> class.
		/// <param name="itemName">Item name.</param>
		/// <param name="initialLowerLimit">Initial lower limit.</param>
		/// <param name="initialUpperLimit">Initial upper limit.</param>
		public AlarmTester (string itemName, float initialLowerLimit, float initialUpperLimit)
		{
			AlarmName = itemName;
			LowerLimit = initialLowerLimit;
			UpperLimit = initialUpperLimit;
		}

		/// Tests if the value passed is outside the limits.
		/// <returns><c>true</c>, if the value is outside the limits to be tested, <c>false</c> otherwise.</returns>
		/// <param name="value">Value.</param>
		public bool ValueOutsideLimits (float value)
		{
			// return true if value outside limits;
			return (false || value > UpperLimit || value < LowerLimit);
		}
	}
}

