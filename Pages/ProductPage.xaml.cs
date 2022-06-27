﻿using StroyMaterials.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StroyMaterials.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        Context context = new Context();
        public ProductPage()
        {
            InitializeComponent();
            lvProduct.ItemsSource = context.Product.ToList();
        }

        private void AddToDb_Click(object sender, MouseButtonEventArgs e)
        {
            AddEditProductPage toAdd = new AddEditProductPage();
            NavigationService.Navigate(toAdd);
        }
    }
}
