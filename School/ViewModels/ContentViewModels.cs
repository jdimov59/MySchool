using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using School.Models;
using System.Collections.Generic;

namespace School.Models
{
    public class HistoryViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }

    public class PatronViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }

    public class MaterialBaseViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}