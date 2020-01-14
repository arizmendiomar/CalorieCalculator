using CalorieCalculator.API.Models;

namespace CalorieCalculator.API.Services
{
    public abstract class PatientCalorieCalculator
    {
        public PatientPhysicalData PhysicalData { get; set; }        
        public abstract double GetIdealBodyWeight();
        public abstract double GetBasalMetabolicRate();
        public double DistanceFromIdealWeight()
        { 
            return (this.PhysicalData.Weight -this.GetIdealBodyWeight());
        }

        public PatientCalorieCalculator(PatientPhysicalData physicalData)
        {
            PhysicalData = physicalData;
        }
    }
}
