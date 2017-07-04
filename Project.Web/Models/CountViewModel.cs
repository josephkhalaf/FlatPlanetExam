using System.ComponentModel.DataAnnotations;

namespace Project.Web.Models
{
    public class CountViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Count Number")]
        public int CountNumber { get; set; }
    }
}