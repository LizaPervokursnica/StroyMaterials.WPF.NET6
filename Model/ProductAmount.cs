using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Количество продукта
    /// </summary>
    public class ProductAmount
    {
        [Key]
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Guid? ProductId { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }  
        public Guid? OrderId { get; set; }  
    }
}
