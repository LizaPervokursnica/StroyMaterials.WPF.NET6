using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Пункт выдачи
    /// </summary>
    public class DeliveryPoint
    {
        [Key]
         public Guid Id { get; set; }

        public string PointName { get; set; }

        [Required]
        public string PointAdress { get; set; }
    }
}
