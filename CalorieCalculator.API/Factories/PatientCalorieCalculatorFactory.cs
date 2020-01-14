using CalorieCalculator.API.Models;
using CalorieCalculator.API.Services;

namespace CalorieCalculator.API
{
    public class PatientCalorieCalculatorFactory
    {
        public static PatientCalorieCalculator Create(PatientPhysicalData physicalData)
        {
            switch (physicalData.Gender)
            { 
                case Gender.Female:
                    return new FemaleCalorieCalculator(physicalData);
                default:
                    return new MaleCalorieCalculator(physicalData);
            }
        }
    }
}
