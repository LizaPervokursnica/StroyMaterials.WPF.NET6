using StroyMaterials.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string ProductArticle { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        
        //Единица измерения
        [Required]
        public MeasurementUnits MeasurementUnit { get; set; }

        [Required]
        public double Сost { get; set; } //стоимость 

        //Размер максимальной скидки
        public double? MaxDiscount { get; set; }

        //Производитель
        public Manufacturer Manufacturer { get; set; }
        public Guid? ManufacturerId { get; set; }

        //Поставщик
        public Provider Provider { get; set; }
        public Guid? ProviderId { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public Guid? ProductCategoryId { get; set; }

        public double CurrentDiscount { get; set; }

        //Кол-во на складе
        [Required]
        public int  AmountInStock { get; set; }

        public string? ProductDescription { get; set; }

        public byte[]? ProductImage { get; set; }

    }
}
