using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class CategoryViewModel
    {
        [DisplayName("ID")]
        public int CategoryId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Digite el nombre de la categoria")]
        public string CategoryName { get; set; } = null!;
    }
}
