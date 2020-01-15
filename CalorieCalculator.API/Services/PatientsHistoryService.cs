using CalorieCalculator.API.Models;
using CalorieCalculator.API.Models.Serializable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalorieCalculator.API.Services
{
    public class PatientsHistoryService
    {
        private const string PATIENT_HISTORY_FILE_NAME = @"\PatientsHistory.xml";

        public void Save(Patient patientData)
        {
            var patientsHistory = GetPatientsHistory();
            PatientsHistoryPatient patientHistory;

            if (patientsHistory == null)
            {
                patientsHistory = CreatePatiensHistory(patientData);
                patientHistory = patientsHistory.patient.First();
            }
            else
            {
                patientHistory = patientsHistory.patient.FirstOrDefault(patient => patient.ssn == patientData.PersonalData.SSN);

                if (patientHistory == null)
                {
                    patientHistory = CreatePatientHistory(patientData);
                    patientsHistory.patient.Add(patientHistory);
                }
                    
            }

            patientHistory.measurement.Add(CreatePatientMeasurement(patientData));

            UpdatePatientsHistory(patientsHistory);
        }

        private PatientsHistory CreatePatiensHistory(Patient patient)
        {
            return new PatientsHistory { 
                patient = new List<PatientsHistoryPatient>(){ CreatePatientHistory(patient) }
            };
        }

        private PatientsHistoryPatient CreatePatientHistory(Patient patient)
        {
            return new PatientsHistoryPatient
            { 
                firstName = patient.PersonalData.FirstName,
                lastName = patient.PersonalData.LastName,
                ssn = patient.PersonalData.SSN,
                measurement = new List<PatientsHistoryPatientMeasurement>()
            };
        }

        private PatientsHistoryPatientMeasurement CreatePatientMeasurement(Patient patient)
        {
            return new PatientsHistoryPatientMeasurement
            {
                age = patient.PhysicalData.Age,
                date = DateTime.Now.ToString(),
                height = patient.PhysicalData.Height,
                weight = patient.PhysicalData.Weight,
                dailyCaloriesRecommended = patient.HealthData.DailyCaloriesRecommended,
                distanceFromIdealWeight = patient.HealthData.DistanceFromIdealWeight,
                idealBodyWeight = patient.HealthData.IdealWeight
            };
        }
        
        private void UpdatePatientsHistory(PatientsHistory patientsHistory)
        {   
            HelperService.UpdateDataOnFile<PatientsHistory>(patientsHistory, PATIENT_HISTORY_FILE_NAME);
        }
        
        public PatientsHistory GetPatientsHistory()
        {
            return HelperService.GetDataFromFile<PatientsHistory>(PATIENT_HISTORY_FILE_NAME);            
        }

        public string GetHistoryContent()
        {
            return HelperService.GetFileContent(PATIENT_HISTORY_FILE_NAME);
        }
    }
}
