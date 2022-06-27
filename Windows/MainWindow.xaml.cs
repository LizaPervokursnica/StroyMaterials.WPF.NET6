using StroyMaterials.Enums;
using StroyMaterials.Methods;
using System;
using System.Windows;

namespace StroyMaterials.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Roles role;
        public MainWindow()
        {
            InitializeComponent();
            role = Roles.Guest;
            GoToProduct();
            Update.UpdateTables();
        }

        public MainWindow(Roles role)
        {
            InitializeComponent();
            this.role = role;
            GoToProduct();
        }

        private void GoToProduct() => PagesNavigation.Navigate(new Uri("Pages/ProductPage.xaml", UriKind.RelativeOrAbsolute));

        private void rdProduct_Click(object sender, RoutedEventArgs e) => GoToProduct();

    }
}
