using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PatientMonitor
{
    class PatientFactory:IPatientFactory
    {
        public Object CreateandReturnObj(PatientClassesEnumeration objectToGet)
        {
            object createdObject = null;
            switch (objectToGet)
            {
                case PatientClassesEnumeration.PatientAlarmer:
                    PatientAlarmer alarmer = new PatientAlarmer();
                    createdObject = alarmer;
                    break;
                case PatientClassesEnumeration.PatientDataReader:
                    PatientDataReader dataReader = new PatientDataReader();
                    createdObject = dataReader;
                    break;
                case PatientClassesEnumeration.PatientData:
                    PatientData patientData = new PatientData();
                    createdObject = patientData;
                    break;
                default:
                    throw new ArgumentException("Invalid parameter passed");
            }
            return createdObject;
        }
    }
}
