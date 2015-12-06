using System;
using System.Windows;

namespace PatientMonitor
{
    /// Interpret patient data
	public class PatientData: IPatientData
	{
		public float PulseRate{ get; private set; }
		public float BreathingRate{  get; private set; }
		public float SystolicBloodPressure{ get; private set;  }
		public float DiastolicBloodPressure{  get; private set;  }
		public float Temperature{  get; private set;  }

		/// Initializes a new instance of the <see cref="PMS.PatientData"/> class.
		/// <param name="patientData">Patient data.</param>
		public PatientData (string patientData)
		{
            SetPatientData(patientData);
		}
        /// Initializes a new blank instance of the <see cref="PMS.PatientData"/> class.
        public PatientData()
        {
        }
        
        /// Set up the patient data.
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