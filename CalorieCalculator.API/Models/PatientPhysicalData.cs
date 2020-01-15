namespace CalorieCalculator.API.Models
{
    public class PatientPhysicalData
    {        
        public double Height 
        {
            get
            { 
                return ((HeightFeet * 12) + HeightInches);
            }
        }
        public double HeightFeet { get; set; }
        public double HeightInches { get; set; }
        public double Weight { get; set; }
        public double Age { get; set; }  
        public Gender Gender { get; set; }
    }
}
