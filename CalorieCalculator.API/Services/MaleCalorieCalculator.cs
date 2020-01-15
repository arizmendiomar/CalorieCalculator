using CalorieCalculator.API.Models;

namespace CalorieCalculator.API.Services
{
    public class MaleCalorieCalculator : PatientCalorieCalculator
    {
        public override double GetBasalMetabolicRate()
        {
            var calories = (66
                + (6.3 * base.PhysicalData.Weight)
                + (12.9 * base.PhysicalData.Height)
                - (6.8 *base.PhysicalData.Age));

            return calories;
        }

        public override double GetIdealBodyWeight()
        {
            var idealBodyWeight = ((50 +
                (2.3 * (((base.PhysicalData.HeightFeet - 5) * 12)
                + base.PhysicalData.HeightInches))) * 2.2046);

            return idealBodyWeight;
        }

        public MaleCalorieCalculator(PatientPhysicalData physicalData) : base(physicalData)
        { }
    }
}
