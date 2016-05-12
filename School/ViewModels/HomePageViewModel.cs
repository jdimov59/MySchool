using System.Collections.Generic;

namespace School.Models
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
        }

        public IEnumerable<HistoryViewModel> History { get; set; }

        public IEnumerable<PatronViewModel> Patron { get; set; }

        public IEnumerable<MaterialBaseViewModel> MaterialBase { get; set; }
    }
}