using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientMonitor
{
    interface IPatientFactory
    {
        Object CreateandReturnObj(PatientClassesEnumeration objectToGet);
    }
}
