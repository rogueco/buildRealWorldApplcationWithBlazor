using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingShop.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Range(0, 500)] public double Prrice { get; set; }

        public byte[] Image { get; set; }

        public string ShadeColour { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")] public virtual Category Category { get; set; }
    }
}