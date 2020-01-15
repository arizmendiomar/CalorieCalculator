using CalorieCalculator.API.Models;

namespace CalorieCalculator.API.Services
{
    public class FemaleCalorieCalculator : PatientCalorieCalculator
    {
        public override double GetBasalMetabolicRate()
        {
            var calories = (655
                + (4.3 * base.PhysicalData.Weight)
                + (4.7 * base.PhysicalData.Height)
                - (4.7 *base.PhysicalData.Age));

            return calories;
        }

        public override double GetIdealBodyWeight()
        {
            var idealBodyWeight = ((45.5 +
                (2.3 * (((base.PhysicalData.HeightFeet - 5) * 12)
                + base.PhysicalData.HeightInches))) * 2.2046);

            return idealBodyWeight;
        }

        public FemaleCalorieCalculator(PatientPhysicalData physicalData) : base(physicalData)
        { }
    }
}
