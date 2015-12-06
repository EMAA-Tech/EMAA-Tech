
namespace PatientMonitor
{
    /// Interface definition for patient data
    public interface IPatientData
    {
        float PulseRate { get; }
        float BreathingRate { get; }
        float SystolicBloodPressure { get; }
        float DiastolicBloodPressure { get; }
        float Temperature { get; }
    }
}
