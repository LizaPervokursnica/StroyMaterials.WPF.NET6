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
using StroyMaterials.DataAccess;

namespace StroyMaterials.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static Window window;
        Context context = new Context();
        private int badCaptcha = 0;
        public LoginWindow()
        {
            InitializeComponent();
            window = this;
            UpdateCaptcha();
            Update.UpdateTables();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validCaptcha = CaptchaTBox.cText == MyCaptcha.CaptchaText;
            var findUser = context.User.FirstOrDefault(x => x.Login == LoginTBox.cText && x.Password == passwordBx.PassBox.Password);
            if (!validCaptcha) MessageBox.Show("Проверка не пройдена.\nПовторите попытку.", "Капча введена неверно", MessageBoxButton.OK, MessageBoxImage.Question);
            if (validCaptcha && findUser != null)
            {
                var userRole = findUser.Role;
                MainWindow mainWindow = new MainWindow(userRole);
                mainWindow.Show();
                Hide();
            }
            else if(validCaptcha && findUser == null) MessageBox.Show("Пользователь не найден в базе, повторите попытку.", "Пользователь не найден", MessageBoxButton.OK, MessageBoxImage.Error);

            badCaptcha++;
            if(badCaptcha >= 3)
            {
                UpdateCaptcha();
                badCaptcha = 0;
            }
        }

        private void UpdateCaptchaBtn_Click(object sender, RoutedEventArgs e) => UpdateCaptcha();

        private void UpdateCaptcha() =>
            MyCaptcha.CreateCaptcha(Captcha.LetterOption.Alphanumeric, 5);

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) => Keyboard.ClearFocus();
    }
}
