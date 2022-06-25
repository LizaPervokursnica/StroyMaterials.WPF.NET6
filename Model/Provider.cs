using StroyMaterials.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Поставщик товаров
    /// </summary>
    public class Provider
    {
        [Key]
         public Guid Id { get; set; }
        public PersonTypes PersonType { get; set; }
        public string? CompanyName { get; set; }
        public User User { get; set; }
    }
}
