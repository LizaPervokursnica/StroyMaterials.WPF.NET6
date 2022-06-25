using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public double Сost { get; set; } //стоимость 
        public Provider Provider { get; set; }
    }
}
