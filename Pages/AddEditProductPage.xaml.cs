using Microsoft.Win32;
using StroyMaterials.DataAccess;
using StroyMaterials.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace StroyMaterials.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        Context context = new Context();
        private byte[] _imageBytes = null;

        public AddEditProductPage()
        {
            InitializeComponent();
            List<string> measurementUnits = new()
            {
                "Штука", "Грамм", "Килограмм", "Литр"
            };
            cbMeasurementUnit.ItemsSource = measurementUnits;

            cbMaker.ItemsSource = context.Manufacturer.ToList();
            cbProvider.ItemsSource = context.Provider.ToList();
            cbCategory.ItemsSource = context.ProductCategory.ToList();

        }

        public AddEditProductPage(double cost, double maxDiscount)
        {
            InitializeComponent();

        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            var stock = int.TryParse(tbStockAmount.cText, out int stockAmount);
            var cDiscount = int.TryParse(tbCurrentDiscount.cText, out int currentDiscount);
            var mDiscount = int.TryParse(tbMaxDiscount.cText, out int maxDiscount);
            var cost = double.TryParse(tbProductCost.cText, out double productCost);
            var measurementUnit = cbMeasurementUnit.SelectedValue switch
            { 
                "Грамм" => Enums.MeasurementUnits.gram,
                "Штука" => Enums.MeasurementUnits.piece,
                "Килограмм" => Enums.MeasurementUnits.kg,
                "Литр" => Enums.MeasurementUnits.liter,
            };

            if (stock && cDiscount && mDiscount && cost)
            {
                context.Product.Add(new Product()
                {
                    Id = Guid.NewGuid(),
                    AmountInStock = stockAmount,
                    CurrentDiscount = currentDiscount,
                    MaxDiscount = maxDiscount,
                    Сost = productCost,
                    ProductName = tbProductName.cText,
                    ProductArticle = tbProductArticle.cText,
                    ProductDescription = tbProductDescription.cText,
                    ProviderId = Guid.Parse(cbProvider.SelectedValue.ToString()),
                    ManufacturerId = Guid.Parse(cbMaker.SelectedValue.ToString()),
                    ProductCategoryId = Guid.Parse(cbCategory.SelectedValue.ToString()),
                    ProductImage = _imageBytes,
                    MeasurementUnit = measurementUnit
                });
                context.SaveChanges();
                ProductPage productPage = new ProductPage();
                NavigationService.Navigate(productPage);
            }
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) { return; }

            var imagePath = dialog.FileName;
            ProductImage.Source = new BitmapImage(new Uri(imagePath));

            using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                _imageBytes = new byte[fs.Length];
            }
        }
    }
}
