using CalorieCalculator.API.Models;

namespace CalorieCalculator.API
{
    public class PatientFactory
    {
        public static Patient Create(Gender gender)
        {
            switch (gender)
            { 
                case Gender.Female:
                    return new FemalePatient();
                default:
                    return new MalePatient();
            }
        }
    }
}
