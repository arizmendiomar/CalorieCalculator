using CalorieCalculator.API.Models;
using CalorieCalculator.API.Services;
using System;
using System.IO;
using System.Reflection;

namespace CalorieCalculator.API
{
    public class Calc
    {
        public static string DISTANCE_FROM_IDEAL_WEIGHT 
        {
            get => _patientHealthData.DistanceFromIdealWeight;
            set => _patientHealthData.DistanceFromIdealWeight = value; 
        }
        public static string IDEAL_WEIGHT 
        {
            get => _patientHealthData.IdealWeight;
            set => _patientHealthData.IdealWeight = value; 
        }
        public static string CALORIES
        {
            get => _patientHealthData.DailyCaloriesRecommended;
            set => _patientHealthData.DailyCaloriesRecommended = value;
        }
        public enum The_sex
        {
            Male = Gender.Male,
            Female = Gender.Female
        }

        private static PatientHealthData _patientHealthData = new PatientHealthData();

        private static PatientsHistoryService patientsHistoryService = new PatientsHistoryService();

        public static void Calculate(string heightFeet, string heightInches, string weight, string age, The_sex sex)
        {            
            ClearData();

            #region Initialize Patient Data

            var physicalData = PhysicalDataCreator.Create(heightFeet, heightInches, weight, age, ErrorHandlingType.ThrowException);
            var patientCalorieCalculator = PatientCalorieCalculatorFactory.Create(physicalData.Data);            

            #endregion

            #region Calories Calculation
            
            _patientHealthData.DailyCaloriesRecommended = patientCalorieCalculator.GetBasalMetabolicRate().ToString();            
            _patientHealthData.IdealWeight = patientCalorieCalculator.GetIdealBodyWeight().ToString();

            #endregion Calories Calculation

            #region Calculate and display distance from ideal weight
            
            _patientHealthData.DistanceFromIdealWeight = patientCalorieCalculator.DistanceFromIdealWeight().ToString();

            #endregion
        } 

        public static void Save(string patientSsnPart1,string patientSsnPart2, string patientSsnPart3, string patientFirstName,  
                                   string patientLastName,  string heightFeet, string heightInches, string weight, string age)
        {
            var physicalData = 
                PhysicalDataCreator.Create(heightFeet, heightInches, weight, age, ErrorHandlingType.ConsoleLog);            
            var personalData = 
                PersonalDataCreator.Create(patientSsnPart1, patientSsnPart2, patientSsnPart3, patientFirstName, patientLastName, ErrorHandlingType.ConsoleLog);

            if (personalData.Invalid || physicalData.Invalid)
            {
                throw new Exception("Invalid Output");
            }

            var patient = new Patient { 
                PersonalData = personalData.Data,
                PhysicalData = physicalData.Data,
                HealthData = _patientHealthData
            };

            #region XML File Generation and Data Writing
                        
            patientsHistoryService.Save(patient);

            #endregion XML File Generation and Data Writing
        }

        public static string GetHistory()
        {            
            return patientsHistoryService.GetHistoryContent();
        }

        private static void ClearData()
        {
            _patientHealthData.DailyCaloriesRecommended = string.Empty;
            _patientHealthData.IdealWeight = string.Empty;
            _patientHealthData.DistanceFromIdealWeight = string.Empty;
        }       
    }
}

