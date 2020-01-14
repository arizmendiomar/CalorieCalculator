using System;

namespace CalorieCalculator.API.Validators
{
    public class PhysicalDataValidator
    {
        public static bool Validate(string heightFeet, string heightInches, string weight, string age)
        {
            var PatientPhysicalDataValidation = true;
            
            var validatorResult = ValidateHeightFeet(heightFeet);
            if (!validatorResult.IsValid)
            {
                Console.WriteLine(validatorResult.ErrorMessage);
                PatientPhysicalDataValidation = false;
            }

            //Validate height (inches) is numeric value
            validatorResult = ValidatHeightInches(heightInches);
            if (!validatorResult.IsValid)
            {
                Console.WriteLine(validatorResult.ErrorMessage);
                PatientPhysicalDataValidation = false;
            }
            //Validate weight is numeric value
            validatorResult = ValidateWeight(weight);
            if (!validatorResult.IsValid)
            {
                Console.WriteLine(validatorResult.ErrorMessage);
                PatientPhysicalDataValidation = false;
            }
            //Validate age is numeric value
            validatorResult = ValidateAge(age);
            if (!validatorResult.IsValid)
            {
                Console.WriteLine(validatorResult.ErrorMessage);
                PatientPhysicalDataValidation = false;
            }

            return PatientPhysicalDataValidation;
        }

        public static DataValidatorResult<double> ValidateHeightFeet(string heightFeet)
        {
            if (!double.TryParse(heightFeet, out var numHeightFeet))
            {
                return new DataValidatorResult<double>(numHeightFeet, "Feet must be a numeric value.");
            }

            if (numHeightFeet < 5)
            {
                return new DataValidatorResult<double>(numHeightFeet, "Height has to be equal to or greater than 5 feet!");
            }
            
            return new DataValidatorResult<double>(0);
        }

        public static DataValidatorResult<double> ValidatHeightInches(string heightInches)
        {
            if (!double.TryParse(heightInches, out var numHeightInches))
            {
                return new DataValidatorResult<double>(numHeightInches, "Feet must be a numeric value.");
            }

            return new DataValidatorResult<double>(0);
        }

        public static DataValidatorResult<double> ValidateWeight(string weight)
        {
            if (!double.TryParse(weight, out var numWeight))
            {
                return new DataValidatorResult<double>(numWeight, "Feet must be a numeric value.");
            }

            return new DataValidatorResult<double>(0);
        }

        public static DataValidatorResult<double> ValidateAge(string age)
        {
            if (!double.TryParse(age, out var numAge))
            {
                return new DataValidatorResult<double>(numAge, "Feet must be a numeric value.");
            }

            return new DataValidatorResult<double>(0);
        }
    }
}
