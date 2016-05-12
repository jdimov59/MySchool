using System.Collections.Generic;
using System.Linq;
using School.ViewModels;
using System.Collections;

namespace School.ViewModels
{
    public class LearningProcessViewModels
    {
        public LearningProcessViewModels()
        {
        }

        public IEnumerable<ContentLearningProcessModes.ScheduleYearViewModel> ScheduleYear { get; set; }

        public IEnumerable<ContentLearningProcessModes.VacationsViewModel> Vacations { get; set; }

        public IEnumerable<ContentLearningProcessModes.OffDaysViewModel> OffDays { get; set; }

        public IEnumerable<ContentLearningProcessModes.LentTermStartViewModel> LentTermStart { get; set; }

        public IEnumerable<ContentLearningProcessModes.LentTermEndViewModel> LentTermEnd { get; set; }
    }
}