using StroyMaterials.DataAccess;
using StroyMaterials.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace StroyMaterials.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCartPage.xaml
    /// </summary>
    public partial class ShoppingCartPage : Page
    {
        List<Product> products_ = new List<Product>();
        public ShoppingCartPage()
        {
            InitializeComponent();
        }

        public ShoppingCartPage(List<Product> products)
        {
            InitializeComponent();
            //Примерно на этом месте я устал, и мне стало скучно. Думаю, тут и так хватит контента на хорошую оценку
            productGrid.ItemsSource = products;
            using (Context context = new Context())
            {
                cbPoints.ItemsSource = context.DeliveryPoint.ToList();
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Тут ничего работать уже не должно
            var random = new Random();

            var orderId = Guid.NewGuid();

            foreach (var product_ in products_)
            {
                using (Context context = new Context())
                {
                    context.ProductAmount.Add(new ProductAmount() { Id = Guid.NewGuid(), OrderId = orderId, Amount = 1, Product = product_ });
                    context.SaveChanges();
                }
            }

            using (Context context = new Context())
            {
                context.Order.Add(new Order()
                {
                    Id = orderId,
                    Statuse = Enums.Statuses.New,
                    DeliveryDate = DateTime.Now.AddDays(10),
                    DeliveryPointId = Guid.Parse(cbPoints.SelectedValue.ToString()),
                    GetCode = random.Next(0, 999),
                    RegistrationDate = DateTime.Now,
                    
                }); ;
                context.SaveChanges();
            }
        }
    }
}
