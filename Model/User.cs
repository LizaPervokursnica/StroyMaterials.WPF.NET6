using StroyMaterials.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Данные акканута
    /// </summary>
    public class User
    {
        [Key]
         public Guid Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Roles Role { get; set; }
    }
}
