using StroyMaterials.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Информация о заказе
    /// </summary>
    public class Order
    {
        [Key]
         public Guid Id { get; set; }
        public string Description { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public Statuses Statuse { get; set; }
        public DateTime RegistrationDate { get; set; } //дата оформления
        public DeliveryPoint DeliveryPoint { get; set; } //пункт доставки
    }
}
