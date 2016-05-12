using Antlr.Runtime.Misc;
using School.Models;
using System.Linq;
using System.Web.Mvc;

namespace School.ViewModels
{
    public class PersonViewModel
    {
        //[HiddenInput]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Position { get; set; }
    }
}