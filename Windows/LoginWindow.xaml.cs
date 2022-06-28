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
            if(CaptchaTBox.cText == MyCaptcha.CaptchaText && context.User.FirstOrDefault(x => x.Login == LoginTBox.cText && x.Password == passwordBx.PassBox.Password) != null)
            {
                var userRole = context.User.FirstOrDefault(x => x.Login == LoginTBox.cText && x.Password == passwordBx.PassBox.Password).Role;
                MainWindow mainWindow = new MainWindow(userRole);
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) => Keyboard.ClearFocus();
        
    }
}
