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
        [Required]
        public DateTime StartWorkTime {get; set; } //начало рабочего дня
        [Required]
        public DateTime EndWorkTime { get; set; } //конец рабочего дня
        [Phone]
        public string PointPhoneNumber { get; set; } //номер для свзяи с пунктом выдачи
    }
}
