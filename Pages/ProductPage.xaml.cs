using StroyMaterials.DataAccess;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using StroyMaterials.Model;
using System.Windows;
using System.Collections.Generic;
using StroyMaterials.Enums;

namespace StroyMaterials.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        Context context = new Context();
        List<Product> products = new();
        Roles role = Roles.Guest;
        public ProductPage()
        {
            InitializeComponent();
            lvProduct.ItemsSource = context.Product.ToList();
        }

        public ProductPage(Roles role)
        {
            InitializeComponent();
            this.role = role;
            lvProduct.ItemsSource = context.Product.ToList();
            if(role == Roles.Admin)
            {
                AddProduct.IsEnabled = true;
            }
        }

        private void AddToDb_Click(object sender, MouseButtonEventArgs e)
        {
            if (role == Roles.Admin)
            {
                AddEditProductPage toAdd = new AddEditProductPage();
                NavigationService.Navigate(toAdd);
            }
            else MessageBox.Show("Нет прав");
        }

        private void UpdateListViewBtn_Click(object sender, MouseButtonEventArgs e)
        {
            var sText = SBox.SearchItemTxt.Text.ToLower();
            lvProduct.ItemsSource = context.Product.Where(x => x.ProductArticle.ToLower().Contains(sText) || x.ProductName.ToLower().Contains(sText) || x.ProductDescription.ToLower().Contains(sText)).ToList();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.DataContext is Product product && role == Roles.Admin)
            {
                var move = MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Внимание!", MessageBoxButton.YesNo);
                if (move == MessageBoxResult.Yes)
                {
                    context.Product.Remove(context.Product.Find(product.Id));
                    context.SaveChanges();
                    lvProduct.ItemsSource = context.Product.ToArray();
                }
            }
            else MessageBox.Show("Не выбран элемент для удаления или нет прав", "Выберите элемент", MessageBoxButton.OK);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.DataContext is Product product && role == Roles.Admin)
            {
                AddEditProductPage toProduct = new AddEditProductPage(product.Id, product.AmountInStock, product.CurrentDiscount, 
                    product.MaxDiscount, product.Сost, product.ProductName, product.ProductArticle, product.ProductDescription, product.ProviderId,
                    product.ManufacturerId, product.ProductCategoryId, product.ProductImage, product.MeasurementUnit, "Сохранить");
                NavigationService.Navigate(toProduct);
            }
            else MessageBox.Show("Не выбран элемент для редактирования или нет прав", "Выберите элемент", MessageBoxButton.OK);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button.DataContext is Product product)
            {
                products.Add(product);
            }
        }

        private void cartShop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var shopCart = new ShoppingCartPage(products);
            NavigationService.Navigate(shopCart);
        }
    }
}
