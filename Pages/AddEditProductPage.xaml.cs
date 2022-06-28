using Microsoft.Win32;
using StroyMaterials.DataAccess;
using StroyMaterials.Enums;
using StroyMaterials.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
        public Guid thisProductId;
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

        public AddEditProductPage(Guid id, int stockAmount, double currentDiscount, double? maxDiscount, double cost, string productName, 
            string productArticle, string productDescription, Guid? providerId, Guid? manufacturerId, 
            Guid? productCategoryId, byte[] productImage, MeasurementUnits measurementUnit, string buttonText)
        {
            InitializeComponent();
            List<string> measurementUnits = new()
            {
                "Штука", "Грамм", "Килограмм", "Литр"
            };
            cbMeasurementUnit.ItemsSource = measurementUnits;

            BitmapImage bitmapImg;

                using (var ms = new System.IO.MemoryStream(productImage))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad; // here
                    image.StreamSource = ms;
                    image.EndInit();
                bitmapImg = image;
                }

            cbMaker.ItemsSource = context.Manufacturer.ToList();
            cbProvider.ItemsSource = context.Provider.ToList();
            cbCategory.ItemsSource = context.ProductCategory.ToList();

            thisProductId = id;
            tbStockAmount.cText = stockAmount.ToString();
            tbCurrentDiscount.cText = currentDiscount.ToString();
            tbMaxDiscount.cText = maxDiscount.ToString();
            tbProductCost.cText = cost.ToString();
            cbMeasurementUnit.SelectedIndex = 0;
            tbProductName.cText = productName;
            tbProductArticle.cText = productArticle;
            tbProductDescription.Text = productDescription;
            cbProvider.SelectedValue = providerId;
            cbMaker.SelectedValue = manufacturerId;
            cbCategory.SelectedValue = productCategoryId;
            ProductImage.Source = bitmapImg;
            AddBtn.Content = buttonText;
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

        private void AddOrEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if(AddBtn.Content == "Добавить")
            {
                var stock = int.TryParse(tbStockAmount.cText, out int stockAmount);
                var cDiscount = double.TryParse(tbCurrentDiscount.cText, out double currentDiscount);
                var mDiscount = double.TryParse(tbMaxDiscount.cText, out double maxDiscount);
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
                        ProductDescription = tbProductDescription.Text,
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
            else if(AddBtn.Content == "Сохранить")
            {
                var stock = int.TryParse(tbStockAmount.cText, out int stockAmount);
                var cDiscount = double.TryParse(tbCurrentDiscount.cText, out double currentDiscount);
                var mDiscount = double.TryParse(tbMaxDiscount.cText, out double maxDiscount);
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
                    var currentProductItem = context.Product.Where(x => x.Id == thisProductId).FirstOrDefault();
                    currentProductItem.AmountInStock = stockAmount;
                    currentProductItem.CurrentDiscount = currentDiscount;
                    currentProductItem.MaxDiscount = maxDiscount;
                    currentProductItem.Сost = productCost;
                    currentProductItem.ProductName = tbProductName.cText;
                    currentProductItem.ProductArticle = tbProductArticle.cText;
                    currentProductItem.ProductDescription = tbProductDescription.Text;
                    currentProductItem.ProviderId = Guid.Parse(cbProvider.SelectedValue.ToString());
                    currentProductItem.ManufacturerId = Guid.Parse(cbMaker.SelectedValue.ToString());
                    currentProductItem.ProductCategoryId = Guid.Parse(cbCategory.SelectedValue.ToString());
                    currentProductItem.ProductImage = _imageBytes;
                    currentProductItem.MeasurementUnit = measurementUnit;
                    context.SaveChanges();
                    ProductPage productPage = new ProductPage();
                    NavigationService.Navigate(productPage);
                }

            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductPage productPage = new ProductPage();
            NavigationService.Navigate(productPage);
        }
    }
}
