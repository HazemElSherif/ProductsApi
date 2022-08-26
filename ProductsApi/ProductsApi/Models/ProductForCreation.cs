using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class ProductForCreation
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public string ImgURL { get; set; }

        [Required]
        public int? CategoryID { get; set; }
    }

}
