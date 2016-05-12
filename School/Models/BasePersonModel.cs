using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace School.Models
{
    public class BasePersonModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Длъжност")]
        public string Position { get; set; }

        [Display(Name = "Електронна поща")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [AllowHtml]
        [DataType(DataType.Html)]
        [Display(Name = "Снимка")]
        public string Photo { get; set; }

    }
}