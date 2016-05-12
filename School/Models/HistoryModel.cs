using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace School.Models
{
    public class HistoryModel
    {
        public int Id { get; set; }

        [AllowHtml]
        [DataType(DataType.Html)]
        [Display(Name = "Content")]
        [UIHint("tinymce_full")]
        public string Content { get; set; }
    }
}