namespace CalorieCalculator.API.Models
{
    public class Patient
    {
        public PatientHealthData HealthData { get; set; }
        public PatientPhysicalData PhysicalData { get; set; }
        public PatientPersonalData PersonalData { get; set; }
    }
}
