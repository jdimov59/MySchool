using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.ViewModels
{
    public class HoursViewModel
    {
        public HoursViewModel()
        {
        }

        public IEnumerable<ContentLearningProcessModes.ScheduleYearViewModel> ScheduleYear { get; set; }

        public IEnumerable<HoursTableViewModel> HoursTable { get; set; }
    }
}