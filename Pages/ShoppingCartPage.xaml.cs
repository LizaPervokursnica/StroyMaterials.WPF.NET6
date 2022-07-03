using StroyMaterials.DataAccess;
using StroyMaterials.Enums;
using StroyMaterials.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StroyMaterials.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCartPage.xaml
    /// </summary>
    public partial class ShoppingCartPage : Page
    {
        List<Product> products_ = new List<Product>();
        Roles role_ = Roles.Guest;
        public ShoppingCartPage()
        {
            InitializeComponent();
        }

        public ShoppingCartPage(List<Product> products, Roles role)
        {
            InitializeComponent();
            role_ = role;
            if (products != null)
            {
                emptyLabel.Visibility = System.Windows.Visibility.Hidden;
                products_ = products;
            }

            lvProduct.ItemsSource = products;
            using (Context context = new Context())
            {
                cbPoints.ItemsSource = context.DeliveryPoint.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var orderId = Guid.NewGuid();
            try
            {
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

                foreach (var product_ in products_)
                {
                    using (Context context = new Context())
                    {
                        context.ProductAmount.Add(new ProductAmount() { Id = Guid.NewGuid(), OrderId = orderId, Amount = 1, ProductId = product_.Id });
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Заказ успешно сформирован. С вами свяжется опреатор.", "Успешно!", MessageBoxButton.OK, MessageBoxImage.None);
                ProductPage productPage = new ProductPage(role_);
                NavigationService.Navigate(productPage);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
