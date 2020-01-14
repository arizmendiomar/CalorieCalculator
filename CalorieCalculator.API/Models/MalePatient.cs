namespace CalorieCalculator.API.Models
{
    public class MalePatient : Patient
    {
        public override double Calories()
        {
            var calories = (66
                + (6.3 * base.PhysicalData.Weight)
                + (12.9 * ((base.PhysicalData.HeightFeet * 12)
                + base.PhysicalData.HeightInches))
                - (6.8 *base.PhysicalData.Age));

            return calories;
        }

        public override double IdealBodyWeight()
        {
            var idealBodyWeight = ((50 +
                (2.3 * (((base.PhysicalData.HeightFeet - 5) * 12)
                + base.PhysicalData.HeightInches))) * 2.2046);

            return idealBodyWeight;
        }
    }
}
