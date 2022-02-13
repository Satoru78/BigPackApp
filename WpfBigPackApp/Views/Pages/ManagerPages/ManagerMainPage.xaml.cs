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
using WpfBigPackApp.Views.Pages.ManagerPages.Agents;
using WpfBigPackApp.Views.Pages.ManagerPages.Material;
using WpfBigPackApp.Views.Pages.ManagerPages.Supplier;

namespace WpfBigPackApp.Views.Pages.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для ManagerMainPage.xaml
    /// </summary>
    public partial class ManagerMainPage : Page
    {
        public ManagerMainPage()
        {
            InitializeComponent();
        }

        private void AgentDataBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AgentsDataViewPage(new Model.Agent()));
;        }

        private void MaterialsDataBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaterialsDataViewPage());
        }

        private void SuppliersDataBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplierDataViewPage());
        }

        private void ApplicationDataBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
