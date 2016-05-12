using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.ViewModels
{
    public class ConsultationsTableViewModel
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public string Subject { get; set; }

        public string DayOfTheWeek { get; set; }

        public string Classroom { get; set; }

        public string StartTime { get; set; }
    }
}