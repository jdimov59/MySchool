

namespace School.ViewModels
{
    public class ContentLearningProcessModes
    {
        public class ScheduleYearViewModel
        {
            public int Id { get; set; }

            public string Year { get; set; }
        }

        public class VacationsViewModel
        {
            public int Id { get; set; }

            public string Text { get; set; }

            public string Date { get; set; }
        }

        public class OffDaysViewModel
        {
            public int Id { get; set; }

            public string Text { get; set; }

            public string Date { get; set; }
        }

        public class LentTermStartViewModel
        {
            public int Id { get; set; }

            public string Text { get; set; }

            public string Date { get; set; }
        }

        public class LentTermEndViewModel
        {
            public int Id { get; set; }

            public string Text { get; set; }

            public string Date { get; set; }
        }
    }
}