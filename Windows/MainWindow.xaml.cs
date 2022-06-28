using StroyMaterials.Enums;
using StroyMaterials.Methods;
using StroyMaterials.Pages;
using System;
using System.Windows;
using System.Windows.Input;

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
            RoleNamelbl.Content = role.ToString();
            GoToProduct();
        }

        private void GoToProduct()
        {
            ProductPage productPage = new ProductPage(role);
            PagesNavigation.Navigate(productPage);
        }

        private void rdProduct_Click(object sender, RoutedEventArgs e) => GoToProduct();

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => Keyboard.ClearFocus();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => Application.Current.Shutdown();
        
    }
}
