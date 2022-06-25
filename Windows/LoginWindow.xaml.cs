using EasyCaptcha.Wpf;
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
using System.Windows.Shapes;
using StroyMaterials.Methods;

namespace StroyMaterials.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private int badCaptcha = 0;
        public LoginWindow()
        {
            InitializeComponent();
            UpdateCaptcha();
            Update.UpdateTables();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CaptchaTBox.cText == MyCaptcha.CaptchaText)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            badCaptcha++;
            if(badCaptcha > 3)
            {
                UpdateCaptcha();
                badCaptcha = 0;
            }
        }

        private void UpdateCaptchaBtn_Click(object sender, RoutedEventArgs e) => UpdateCaptcha();

        private void UpdateCaptcha() =>
            MyCaptcha.CreateCaptcha(Captcha.LetterOption.Alphanumeric, 5);

    }
}
