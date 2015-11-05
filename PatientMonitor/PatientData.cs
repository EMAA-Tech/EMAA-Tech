using System;

namespace PatientMonitor
{
    /// <summary>
    /// Interpret patient data
    /// </summary>
	public class PatientData: IPatientData
	{
		public float PulseRate{ get; private set; }
		public float BreathingRate{  get; private set; }
		public float SystolicBloodPressure{ get; private set;  }
		public float DiastolicBloodPressure{  get; private set;  }
		public float Temperature{  get; private set;  }

		/// <summary>
		/// Initializes a new instance of the <see cref="PMS.PatientData"/> class.
		/// </summary>
		/// <param name="patientData">Patient data.</param>
		public PatientData (string patientData)
		{
            SetPatientData(patientData);
		}

        /// <summary>
        /// Initializes a new blank instance of the <see cref="PMS.PatientData"/> class.
        /// </summary>
        public PatientData()
        {
        }
        
        /// <summary>
        /// Set up the patient data.
        /// </summary>
        public void SetPatientData(string patientData)
        {
            string[] dataItems = patientData.Split(',');
            PulseRate = float.Parse(dataItems[0]);
            BreathingRate = float.Parse(dataItems[1]);
            SystolicBloodPressure = float.Parse(dataItems[2]);
            DiastolicBloodPressure = float.Parse(dataItems[3]);
            Temperature = float.Parse(dataItems[4]);
        }
	}
}