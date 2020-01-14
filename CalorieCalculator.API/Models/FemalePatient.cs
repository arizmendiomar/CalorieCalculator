namespace CalorieCalculator.API.Models
{
    public class FemalePatient : Patient
    {
        public override double Calories()
        {
            var calories = (655
                + (4.3 * base.PhysicalData.Weight)
                + (4.7 * ((base.PhysicalData.HeightFeet * 12)
                + base.PhysicalData.HeightInches))
                - (4.7 *base.PhysicalData.Age));

            return calories;
        }

        public override double IdealBodyWeight()
        {
            var idealBodyWeight = ((45.5 +
                (2.3 * (((base.PhysicalData.HeightFeet - 5) * 12)
                + base.PhysicalData.HeightInches))) * 2.2046);

            return idealBodyWeight;
        }        
    }
}
