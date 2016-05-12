using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.ViewModels
{
    public class PlanReceptionViewModel
    {
        public PlanReceptionViewModel()
        {
        }

        public IEnumerable<School.ViewModels.YearPlanReceptionModel> YearPlan { get; set; }

        public IEnumerable<School.ViewModels.ReceptionViewModel> Reception { get; set; }
    }
}