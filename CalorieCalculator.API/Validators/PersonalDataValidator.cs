using System;

namespace CalorieCalculator.API.Validators
{
    public class PersonalDataValidator
    {
        public static bool Validate(string patientSsnPart1, string patientSsnPart2, string patientSsnPart3, string patientFirstName,
                                   string patientLastName)
        {
            bool PatientPersonalDataValidation = true;

            var validatorResult = ValidateSSN(patientSsnPart1, patientSsnPart2, patientSsnPart3);
            if (!validatorResult.IsValid)
            {
                Console.WriteLine(validatorResult.ErrorMessage);
                PatientPersonalDataValidation = false;
            }
            validatorResult = ValidateFirstName(patientFirstName);
            if (!validatorResult.IsValid)
            {
                Console.WriteLine(validatorResult.ErrorMessage);
                PatientPersonalDataValidation = false;
            }
            validatorResult = ValidateLastName(patientLastName);
            if (!validatorResult.IsValid)
            {
                Console.WriteLine(validatorResult.ErrorMessage);
                PatientPersonalDataValidation = false;
            }

            return PatientPersonalDataValidation;
        }

        static ValidatorResult ValidateSSN(string ssnPart1, string ssnPart2, string ssnPart3)
        {
            if ((!int.TryParse(ssnPart1, out _)) ||
               (!int.TryParse(ssnPart2, out _)) ||
               (!int.TryParse(ssnPart3, out _)))
            {
                return new ValidatorResult("You must enter valid SSN.");
            }

            return new ValidatorResult();
        }

        static ValidatorResult ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {               
                return new ValidatorResult("You must enter patient’s first name.");
            }

            return new ValidatorResult();
        }
   
        static ValidatorResult ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return new ValidatorResult("You must enter patient’s last name.");
            }

            return new ValidatorResult();
        }
    }
}
