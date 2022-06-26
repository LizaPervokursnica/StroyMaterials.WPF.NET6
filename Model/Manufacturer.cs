using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    public class Manufacturer
    {
        [Key]
        public Guid Id { get; set; }
        public string? ManufacturerName { get; set; }
        public string ManufacturerAdress { get; set; }
    }
}
