using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalculator.API.Models
{
    public class PatientPersonalData
    {
        public int PatientSsnPart1 { get; set; }
        public int PatientSsnPart2 { get; set; }
        public int PatientSsnPart3 { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
    }
}
