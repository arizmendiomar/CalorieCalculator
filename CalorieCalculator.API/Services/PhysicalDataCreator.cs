using CalorieCalculator.API.Models;
using System;

namespace CalorieCalculator.API.Services
{
    public class PhysicalDataCreator
    {
        // This validations could be extracted to a validator class
        public static DataResult<PatientPhysicalData> Create(string heightFeet, string heightInches, string weight, string age, ErrorHandlingType errorHandlingType)
        {
            var physicalData = new PatientPhysicalData();
            var errorHandler = new ErrorHandler(errorHandlingType);
            var error = false;

            double result1;
            if (!double.TryParse(heightFeet, out result1))
            {
                errorHandler.Handle("Feet must be a numeric value.");
                error = true;
            }
            else
                physicalData.HeightFeet = result1;

            //Validate height (inches) is numeric value
            if (!double.TryParse(heightInches, out result1))
            {
                errorHandler.Handle("Feet must be a numeric value.");
                error = true;
            }
            else
                physicalData.HeightInches = result1;
            
            //Validate weight is numeric value
            if (!double.TryParse(weight, out result1))
            {
                errorHandler.Handle("Weight must be a numeric value.");
                error = true;
            }
            else
                physicalData.Weight = result1;

            //Validate age is numeric value
            if (!double.TryParse(age, out result1))
            {
                errorHandler.Handle("Age must be a numeric value.");
                error = true;
            }
            else
                physicalData.Age = result1;

            if (!(Convert.ToDouble(heightFeet) >= 5))
            {
                errorHandler.Handle("Height has to be equal to or greater than 5 feet!");
                error = true;
            }

            if (error)
                physicalData = null;

            return new DataResult<PatientPhysicalData>(physicalData, error);
        }
    }
}
