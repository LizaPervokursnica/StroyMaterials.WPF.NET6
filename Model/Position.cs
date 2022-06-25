using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public class Position
    {
        [Key]
         public Guid Id { get; set; }
        [Required]
        public string PositionName { get; set; } //наименование должности
    }
}
