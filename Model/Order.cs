using StroyMaterials.DataAccess;
using StroyMaterials.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StroyMaterials.Model
{
    /// <summary>
    /// Информация о заказе
    /// </summary>
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public User? User { get; set; }
        public Guid? UserId { get; set; }
        
        public Statuses Statuse { get; set; }

        //Код получения
        [Required]
        public int GetCode { get; set; }

        //Дата оформления
        public DateTime RegistrationDate { get; set; }

        //Дата доставки
        public DateTime DeliveryDate { get; set; }

        public DeliveryPoint? DeliveryPoint { get; set; }
        public Guid? DeliveryPointId { get; set; }

        //Состав заказа
        [NotMapped]
        public string OrderComposition
        {
            get
            {
                string result = string.Empty;
                Context context = new Context();
                context.ProductAmount.ToList().Where(x => x.OrderId == this.Id).ToList().ForEach(x => result += $"{x.Product.ProductName}, {x.Amount}");
                return result;
            }
        }

    }
}
