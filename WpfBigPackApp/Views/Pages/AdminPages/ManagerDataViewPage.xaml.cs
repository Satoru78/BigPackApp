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
using WpfBigPackApp.Model;
using WpfBigPackApp.Context;

namespace WpfBigPackApp.Views.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ManagerDataViewPage.xaml
    /// </summary>
    public partial class ManagerDataViewPage : Page
    {
        public Role Role { get; set; }
        public Manager Manager {get; set;}
        public ManagerDataViewPage(Manager manager)
        {
            InitializeComponent();
            Manager = manager;
            this.DataContext = this;
        }

        private void ManagerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerDataActionPage(new Manager()));
        }

        private void ManagerDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItemManager = ManagerData.SelectedItem as Manager;
                if (selectedItemManager != null)
                {
                    if (MessageBox.Show("Вы дествительно хотите удалить данные?", "Данные будут удалены навсегда!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        Data.bp.Manager.Remove(selectedItemManager);
                        Data.bp.SaveChanges();
                    }
                    MessageBox.Show("Данные успешно удалены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Page_Loaded(null, null);
                }
                else
                    throw new Exception("Пожалуйста, выберите объект из списка!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ManagerEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItemManager = ManagerData.SelectedItem as Manager;
            if (selectedItemManager != null)
                NavigationService.Navigate(new ManagerDataActionPage(selectedItemManager));
            else
                throw new Exception("Пожалуйста, выберите объект из списка!");
        }

        private void ManagerSearchtxb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var list = Data.bp.Manager.Where(item => item.FirstName.Contains(ManagerSearchtxb.Text) ||
            item.LastName.Contains(ManagerSearchtxb.Text) || item.Email.Contains(ManagerSearchtxb.Text)).ToList();

            if (list.Any())
            {
                ManagerData.Visibility = Visibility.Visible;
                NoManager.Visibility = Visibility.Collapsed;
                ManagerData.ItemsSource = list;
            }
            else
            {
                ManagerData.Visibility = Visibility.Collapsed;
                NoManager.Visibility = Visibility.Visible;
            }
        }

        private void ManagerDataBackBrtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ManagerData.ItemsSource = Data.bp.Manager.ToList();
        }
    }
}
