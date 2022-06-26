using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    public class ProductCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
