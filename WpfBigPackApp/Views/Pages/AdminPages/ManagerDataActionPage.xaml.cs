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
using WpfBigPackApp.Model;

namespace WpfBigPackApp.Views.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ManagerDataActionPage.xaml
    /// </summary>
    public partial class ManagerDataActionPage : Page
    {
        public List<Role> Roles { get; set; }
        public Manager Manager { get; set; }
        public ManagerDataActionPage(Manager manager)
        {
            InitializeComponent();
            Roles = Data.bp.Role.ToList();
            Manager = manager;
            this.DataContext = this;
        }

        private void ManagerDataSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Manager.ID == 0)
                {
                    Data.bp.Manager.Add(Manager);
                }
                Data.bp.SaveChanges();
                MessageBox.Show("Данные успешно добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
