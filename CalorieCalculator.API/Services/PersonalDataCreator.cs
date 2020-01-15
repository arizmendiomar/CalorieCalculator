using CalorieCalculator.API.Models;

namespace CalorieCalculator.API.Services
{
    public class PersonalDataCreator
    {
        // This validations could be extracted to a validator class
        public static DataResult<PatientPersonalData> Create(string patientSsnPart1, string patientSsnPart2, string patientSsnPart3, string patientFirstName,
                                   string patientLastName, ErrorHandlingType errorHandlingType)
        {
            var personalData = new PatientPersonalData();
            var errorHandler = new ErrorHandler(errorHandlingType);
            var error = false;            

            if ((!int.TryParse(patientSsnPart1, out _)) |
                (!int.TryParse(patientSsnPart2, out _)) |
                (!int.TryParse(patientSsnPart3, out _)))
            {
                errorHandler.Handle("You must enter valid SSN.");
            }
            else
                personalData.SSN = patientSsnPart1 + "-" + patientSsnPart2 + "-" + patientSsnPart3;

            if (patientFirstName.Trim().Length < 1)
            {
                errorHandler.Handle("You must enter patient’s first name.");
            }
            else
                personalData.FirstName = patientFirstName;

            if (patientLastName.Trim().Length < 1)
            {
                errorHandler.Handle("You must enter patient’s last name.");
            }
            else
                personalData.LastName = patientLastName;

            if (error)
                personalData = null;

            return new DataResult<PatientPersonalData>(personalData, error);
        }
    }
}
