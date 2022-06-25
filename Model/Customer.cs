using StroyMaterials.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiidleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public Genders Gender { get; set; }
        public DateTime Birthday { get; set; } //дата рождения
        [EmailAddress]
        public string Email { get; set; }

        [NotMapped]
        public string FullName => $"{LastName} {FirstName} {MiidleName}"; //ФИО
        public PersonTypes PersonType { get; set; }
        public string? CompanyName { get; set; }
        public User User { get; set; }
    }
}
