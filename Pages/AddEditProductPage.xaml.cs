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
using System.Windows.Input;
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
        Roles role_ = Roles.Guest;

        List<string> measurementUnits = new()
        {
            "Штука",
            "Грамм",
            "Килограмм",
            "Литр"
        };

        public AddEditProductPage(Roles role)
        {
            InitializeComponent();
            role_ = role;
            cbMeasurementUnit.ItemsSource = measurementUnits;
            cbMaker.ItemsSource = context.Manufacturer.ToList();
            cbProvider.ItemsSource = context.Provider.ToList();
            cbCategory.ItemsSource = context.ProductCategory.ToList();
        }


        private void ConvertImage()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapImage)ProductImage.Source));
                encoder.Save(stream);
                _imageBytes = stream.ToArray();
            }
        }

        public AddEditProductPage(Roles role, Product product, string buttonTitle)
        {
            InitializeComponent();
            role_ = role;
            cbMeasurementUnit.ItemsSource = measurementUnits;
            cbMaker.ItemsSource = context.Manufacturer.ToList();
            cbProvider.ItemsSource = context.Provider.ToList();
            cbCategory.ItemsSource = context.ProductCategory.ToList();

            BitmapImage bitmapImg;
            if (product.ProductImage != null)
            {
                using (var ms = new MemoryStream(product.ProductImage))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    bitmapImg = image;
                }
                ProductImage.Source = bitmapImg;
            }

            thisProductId = product.Id;
            tbStockAmount.cText = product.AmountInStock.ToString();
            tbCurrentDiscount.cText = product.CurrentDiscount.ToString();
            tbMaxDiscount.cText = product.MaxDiscount.ToString();
            tbProductCost.cText = product.Сost.ToString();
            cbMeasurementUnit.SelectedIndex = 0;
            tbProductName.cText = product.ProductName;
            tbProductArticle.cText = product.ProductArticle;
            tbProductDescription.Text = product.ProductDescription;
            cbProvider.SelectedValue = product.ProviderId;
            cbMaker.SelectedValue = product.ManufacturerId;
            cbCategory.SelectedValue = product.ProductCategoryId;
            AddBtn.Content = buttonTitle;
        }

        private void OpenDialog()
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
            };

            if (dialog.ShowDialog() != true) { return; }
            var path = dialog.FileName;
            ProductImage.Source = new BitmapImage(new Uri(path));
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenDialog();
            ConvertImage();
        }

        public MeasurementUnits SelectedMeasurement()
        {
            return cbMeasurementUnit.SelectedValue switch
            {
                "Грамм" => Enums.MeasurementUnits.gram,
                "Штука" => Enums.MeasurementUnits.piece,
                "Килограмм" => Enums.MeasurementUnits.kg,
                "Литр" => Enums.MeasurementUnits.liter,
            };
        }

        private void AddOrEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if(AddBtn.Content.ToString() == "Добавить")
            {
                if (ProductImage != null) ConvertImage();
                var stock = int.TryParse(tbStockAmount.cText, out int stockAmount);
                var cDiscount = double.TryParse(tbCurrentDiscount.cText, out double currentDiscount);
                var mDiscount = double.TryParse(tbMaxDiscount.cText, out double maxDiscount);
                var cost = double.TryParse(tbProductCost.cText, out double productCost);
                var measurementUnit = SelectedMeasurement();

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
                    MessageBox.Show("Запись успешно добавлена в таблицу.", "Запись добавлена", MessageBoxButton.OK);
                    NavigateProductPage();
                }
                else MessageBox.Show("Убедитесь, что верно заполнили данные.");
            }
            else if(AddBtn.Content.ToString() == "Сохранить")
            {
                if(ProductImage != null) ConvertImage();
                var stock = int.TryParse(tbStockAmount.cText, out int stockAmount);
                var cDiscount = double.TryParse(tbCurrentDiscount.cText, out double currentDiscount);
                var mDiscount = double.TryParse(tbMaxDiscount.cText, out double maxDiscount);
                var cost = double.TryParse(tbProductCost.cText, out double productCost);
                var measurementUnit = SelectedMeasurement();
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
                    MessageBox.Show("Запись успешно сохранена в таблице.", "Успешно", MessageBoxButton.OK);
                    NavigateProductPage();
                }
                else MessageBox.Show("Убедитесь, что верно заполнили данные.");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) => NavigateProductPage();
        private void NavigateProductPage()
        {
            ProductPage productPage = new ProductPage(role_);
            NavigationService.Navigate(productPage);
        }
        private void ClearWindowFocus(object sender, MouseButtonEventArgs e) => Keyboard.ClearFocus();

        private void ClearPhotoButtonClick(object sender, RoutedEventArgs e)
        {
            ProductImage.Source = null;
        }

        private void AddPhotoButtonClick(object sender, RoutedEventArgs e)
        {
            ProductImage.Source = null;
            OpenDialog();
        }
    }
}
