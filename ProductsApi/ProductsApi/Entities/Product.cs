using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Entities
{
    public class Product
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string ImgURL { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
