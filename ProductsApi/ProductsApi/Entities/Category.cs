using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Entities
{
    public class Category
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
