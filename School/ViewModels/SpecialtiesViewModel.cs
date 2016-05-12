using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.ViewModels
{
    public class SpecialtiesViewModel
    {
        public int Id { get; set; }

        public string Profession { get; set; }

        public string CodeProfession { get; set; }

        public string Specialty { get; set; }

        public string CodeSpecialty { get; set; }

        public string AdmissionEducationalLevel { get; set; }

        public string FormOfEducation { get; set; }

        public string PeriodOfTraining { get; set; }

        public string EducationalDegree { get; set; }

        public string LevelOfQualification { get; set; }
    }
}