
namespace PatientMonitor
{
    /// <summary>
    /// Interface definition for patient data
    /// </summary>
    public interface IPatientData
    {
        float PulseRate { get; }
        float BreathingRate { get; }
        float SystolicBloodPressure { get; }
        float DiastolicBloodPressure { get; }
        float Temperature { get; }
    }
}
