using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.ViewModels
{
    public class ParentalSpecialtiesViewModel
    {
        public ParentalSpecialtiesViewModel()
        {
        }

        public IEnumerable<ContentLearningProcessModes.ScheduleYearViewModel> ScheduleYear { get; set; }

        public IEnumerable<SpecialtiesViewModel> Specialties { get; set; }
    }
}