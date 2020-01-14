using CalorieCalculator.API.Models;
using CalorieCalculator.API.Validators;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace CalorieCalculator.API
{
    public class Calc
    {
        public static string DISTANCE_FROM_IDEAL_WEIGHT { get; set; }
        public static string IDEAL_WEIGHT { get; set; }
        public static string CALORIES { get; set; }

        private static Patient _currentPatient { get; set; }
        
        public enum The_sex
        {
            Male = Gender.Male,
            Female = Gender.Female
        }

        public static void Calculate(string heightFeet, string heightInches, string weight, string age, The_sex sex)
        {
            //Clear old results
            ClearData();
             /* Validate User Input: */
             //Validate height (feet) is numeric value            

             var validatorResult = PhysicalDataValidator.ValidateHeightFeet(heightFeet);
            if(validatorResult.IsValid) validatorResult = PhysicalDataValidator.ValidatHeightInches(heightInches);
            if (validatorResult.IsValid) validatorResult = PhysicalDataValidator.ValidatHeightInches(weight);
            if (validatorResult.IsValid) validatorResult = PhysicalDataValidator.ValidatHeightInches(age);
            if (!validatorResult.IsValid) throw new Exception(validatorResult.ErrorMessage);

            #region Initialize Patient Data

            var physicalData = new PatientPhysicalData
            {
                Age = Convert.ToDouble(age),
                HeightFeet = Convert.ToDouble(heightFeet),
                HeightInches = Convert.ToDouble(heightInches),
                Weight = Convert.ToDouble(weight)
            };           

            _currentPatient = PatientFactory.Create((Gender)sex);
            _currentPatient.PhysicalData = physicalData;

            #endregion

            #region Calories Calculation
            /*End validation*/
            CALORIES = _currentPatient.Calories().ToString();
            IDEAL_WEIGHT = _currentPatient.IdealBodyWeight().ToString();
            #endregion Calories Calculation
            
            #region Calculate and display distance from ideal weight
            //Calculate and display distance from ideal weight            
            DISTANCE_FROM_IDEAL_WEIGHT = _currentPatient.DistanceFromIdealWeight().ToString();
            #endregion
        } 

        public static void Save(string patientSsnPart1,string patientSsnPart2, string patientSsnPart3, string patientFirstName,  
                                   string patientLastName,  string heightFeet, string heightInches, string weight, string age)
        {
            bool PatientPhysicalDataValidation = PhysicalDataValidator.Validate(heightFeet, heightInches, weight, age);
            bool PatientPersonalDataValidation = PersonalDataValidator.Validate(patientSsnPart1, patientSsnPart2, patientSsnPart3, patientFirstName, patientLastName);
                        
            if (PatientPersonalDataValidation == false || PatientPhysicalDataValidation == false)
            {
                throw new Exception("Invalid Output");
            }

            bool fileCreated = true;

            #region XML File Generation and Data Writing

            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(GetAssemblyDirectory() + @"\PatientsHistory.xml");
            }
            catch (FileNotFoundException ee)
            {
                //If file not found, set fileCreated to false and continue
                fileCreated = false;
            }
            if (!fileCreated)
            {
                document.LoadXml(
                "<PatientsHistory>" +
                "<patient ssn=\"" + patientSsnPart1 + "-" + patientSsnPart2 + "-" + patientSsnPart3+ "\"" + " firstName=\"" + patientFirstName + "\"" +
                " lastName=\"" + patientLastName + "\"" + ">" +
                "<measurement date=\"" + DateTime.Now + "\"" + ">" +
                "<height>" + ((Convert.ToInt32(heightFeet) * 12) + heightInches).ToString() + "</height>" +
                "<weight>" + weight + "</weight>" +
                "<age>" + age + "</age>" +
                "<dailyCaloriesRecommended>" +
               CALORIES+
                "</dailyCaloriesRecommended>" +
                "<idealBodyWeight>" +
               IDEAL_WEIGHT +
                "</idealBodyWeight>" +
                "<distanceFromIdealWeight>" +
                DISTANCE_FROM_IDEAL_WEIGHT +
                "</distanceFromIdealWeight>" +
                "</measurement>" +
                "</patient>" +
                "</PatientsHistory>");
            }
            else
            {
                //Search for existing node for this patient
                XmlNode patientNode = null;
                foreach (XmlNode node in document.FirstChild.ChildNodes)
                {
                    foreach (XmlAttribute attrib in node.Attributes)
                    {
                        //We will use SSN to uniquely identify patient
                        if ((attrib.Name == "ssn") & (attrib.Value == patientSsnPart1 + "-" + patientSsnPart2 + "-" + patientSsnPart3))
                        {
                            patientNode = node;
                        }
                    }
                }
                if (patientNode == null)
                {
                    //just clone any patient node and use it for the new patient node
                    XmlNode thisPatient =
                    document.DocumentElement.FirstChild.CloneNode(false);
                    thisPatient.Attributes["ssn"].Value = patientSsnPart1 + "-" + patientSsnPart2 + "-" + patientSsnPart3;
                    thisPatient.Attributes["firstName"].Value = patientFirstName;
                    thisPatient.Attributes["lastName"].Value = patientLastName;
                    XmlNode measurement = document.DocumentElement.FirstChild["measurement"].CloneNode(true);
                    measurement.Attributes["date"].Value = DateTime.Now.ToString();
                    measurement["height"].FirstChild.Value = ((Convert.ToInt32(heightFeet) * 12) + Convert.ToInt32(heightInches)).ToString();
                    measurement["weight"].FirstChild.Value = weight;
                    measurement["age"].FirstChild.Value = age;
                    measurement["dailyCaloriesRecommended"].FirstChild.Value = CALORIES;
                    measurement["idealBodyWeight"].FirstChild.Value = IDEAL_WEIGHT;
                    measurement["distanceFromIdealWeight"].FirstChild.Value = DISTANCE_FROM_IDEAL_WEIGHT;
                    thisPatient.AppendChild(measurement);
                    document.FirstChild.AppendChild(thisPatient);
                }
                else
                {
                    //If patient node found just clone any measurement
                    //and use it for the new measurement
                    XmlNode measurement = patientNode.FirstChild.CloneNode(true);
                    measurement.Attributes["date"].Value = DateTime.Now.ToString();
                    measurement["height"].FirstChild.Value = ((Convert.ToInt32(heightFeet) * 12) + Convert.ToInt32(heightInches)).ToString();
                    measurement["weight"].FirstChild.Value = weight;
                    measurement["age"].FirstChild.Value = age;
                    measurement["dailyCaloriesRecommended"].FirstChild.Value = CALORIES;
                    measurement["idealBodyWeight"].FirstChild.Value = IDEAL_WEIGHT;
                    measurement["distanceFromIdealWeight"].FirstChild.Value = DISTANCE_FROM_IDEAL_WEIGHT;
                    patientNode.AppendChild(measurement);
                }
            }
            //Finally, save the xml to file
            document.Save(GetAssemblyDirectory() +  @"\PatientsHistory.xml");
            #endregion XML File Generation and Data Writing
        }


        public static string GetAssemblyDirectory()
        {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
        }


        public static string GetHistory()
        {
            return File.ReadAllText(GetAssemblyDirectory() + @"\PatientsHistory.xml");
        }

        private static void ClearData()
        {
            DISTANCE_FROM_IDEAL_WEIGHT = "";
            IDEAL_WEIGHT = "";
            CALORIES = "";
            _currentPatient = null;
        }
    }
}

