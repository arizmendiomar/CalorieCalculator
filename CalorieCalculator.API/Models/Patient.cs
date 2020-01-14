using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API.Models
{
    public abstract class Patient
    {
        public PatientPhysicalData PhysicalData { get; set; }
        public PatientPersonalData PersonalData { get; set; }
        public abstract double IdealBodyWeight();
        public abstract double Calories();
        public double DistanceFromIdealWeight()
        { 
            return (this.PhysicalData.Weight -this.IdealBodyWeight());
        }
        public Patient()
        { }
    }
}
