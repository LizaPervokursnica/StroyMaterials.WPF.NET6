using StroyMaterials.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Сотрудник магазина
    /// </summary>
    public class Employee
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
        public Position Position { get; set; } //занимаемая должность
        public DateTime StartWork{ get; set; }
        public DateTime? EndWork{ get; set; }
        public User User { get; set; }
    }
}
