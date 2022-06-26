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
        public string? ProviderName { get; set; }
        public string ProviderAdress { get; set; }
        
    }
}
