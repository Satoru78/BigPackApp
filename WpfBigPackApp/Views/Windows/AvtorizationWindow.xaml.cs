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
using WpfBigPackApp.Context;
using WpfBigPackApp.Views.Windows;

namespace WpfBigPackApp
{
    /// <summary>
    /// Логика взаимодействия для AvtorizationWindow.xaml
    /// </summary>
    public partial class AvtorizationWindow : Window
    {
        public AvtorizationWindow()
        {
            InitializeComponent();
        }

        private void psbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txbPassword.Text = psbPassword.Password;
        }

        private void SeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(VisPassword.Visibility == Visibility.Collapsed)
            {
                HidePassword.Visibility = Visibility.Collapsed;
                VisPassword.Visibility = Visibility.Visible;
            }
            else
            {
                HidePassword.Visibility = Visibility.Visible;
                VisPassword.Visibility = Visibility.Collapsed;
            }
        }

        private void HideBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HidePassword.Visibility == Visibility.Collapsed)
            {
                HidePassword.Visibility = Visibility.Visible;
                VisPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                HidePassword.Visibility = Visibility.Collapsed;
                VisPassword.Visibility = Visibility.Visible;
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbPassword.Text == "" && txbLogin.Text == "")
                {
                    throw new Exception("Заполните все поля");
                }
                else
                {
                    // Запрос на авторизацию
                    var currentUser = Data.bp.User.FirstOrDefault(item => item.Username == txbLogin.Text && item.Password == psbPassword.Password || txbPassword.Text == item.Password);
                    if (currentUser != null)
                    {
                        switch (currentUser.IDRole)
                        {
                            case "a":
                                AdminWindow adminWindow = new AdminWindow();
                                adminWindow.ShowDialog();
                                break;

                            case "m":
                                ManagerWindow managerWindow = new ManagerWindow();
                                managerWindow.ShowDialog();
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("Пользователь не найден");
                    }
                }

            }
            catch
            {

            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
