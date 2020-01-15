using System.Collections.Generic;

namespace CalorieCalculator.API.Models.Serializable
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class PatientsHistory
    {

        private List<PatientsHistoryPatient> patientField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("patient")]
        public List<PatientsHistoryPatient> patient
        {
            get
            {
                return this.patientField;
            }
            set
            {
                this.patientField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PatientsHistoryPatient
    {

        private List<PatientsHistoryPatientMeasurement> measurementField;

        private string ssnField;

        private string firstNameField;

        private string lastNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("measurement")]
        public List<PatientsHistoryPatientMeasurement> measurement
        {
            get
            {
                return this.measurementField;
            }
            set
            {
                this.measurementField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ssn
        {
            get
            {
                return this.ssnField;
            }
            set
            {
                this.ssnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string lastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PatientsHistoryPatientMeasurement
    {

        private double heightField;

        private double weightField;

        private double ageField;

        private string dailyCaloriesRecommendedField;

        private string idealBodyWeightField;

        private string distanceFromIdealWeightField;

        private string dateField;

        /// <remarks/>
        public double height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public double weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public double age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        public string dailyCaloriesRecommended
        {
            get
            {
                return this.dailyCaloriesRecommendedField;
            }
            set
            {
                this.dailyCaloriesRecommendedField = value;
            }
        }

        /// <remarks/>
        public string idealBodyWeight
        {
            get
            {
                return this.idealBodyWeightField;
            }
            set
            {
                this.idealBodyWeightField = value;
            }
        }

        /// <remarks/>
        public string distanceFromIdealWeight
        {
            get
            {
                return this.distanceFromIdealWeightField;
            }
            set
            {
                this.distanceFromIdealWeightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
    }


}
