using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.ViewModels
{
    public class ConsultationsViewModel
    {
        public ConsultationsViewModel()
        {
        }

        public IEnumerable<ContentLearningProcessModes.ScheduleYearViewModel> ScheduleYear { get; set; }

        public IEnumerable<ConsultationsTableViewModel> ConsultationTable { get; set; }
    }
}