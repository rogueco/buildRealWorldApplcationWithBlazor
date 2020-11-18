using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace BlazingShop.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}