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

namespace WpfBigPackApp.Views.Pages.ManagerPages.Agents
{
    /// <summary>
    /// Логика взаимодействия для AgentsDataViewPage.xaml
    /// </summary>
    public partial class AgentsDataViewPage : Page
    {
        public DirectorName DirectorName { get; set; }
        public AgentType AgentType { get; set; }
        public Priority Priority { get; set; }
        public PointsOfSales PointsOfSales { get; set; }
        public Role Role { get; set; }
        public Agent Agent { get; set; }
        public AgentsDataViewPage(Agent agent)
        {
            InitializeComponent();
            Agent = agent;
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AgentData.ItemsSource = Data.bp.Agent.ToList();
        }

        private void AgentsDataBackBrtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AgentSearchtxb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var list = Data.bp.Agent.Where(item => item.CompanyName.Contains(AgentSearchtxb.Text) ||
           item.Adress.Contains(AgentSearchtxb.Text) || item.INN.ToString().Contains(AgentSearchtxb.Text)).ToList();

            if (list.Any())
            {
                AgentData.Visibility = Visibility.Visible;
                NoAgents.Visibility = Visibility.Collapsed;
                AgentData.ItemsSource = list;
            }
            else
            {
                AgentData.Visibility = Visibility.Collapsed;
                NoAgents.Visibility = Visibility.Visible;
            }
        }

        private void AgentTypecmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchAgentType((AgentTypecmb.SelectedItem as ComboBoxItem).Content.ToString(), AgentSearchtxb.Text);
        }

        private void AgentAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AgentsDataActionPage(new Agent()));
        }

        private void AgentEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItemAgent = AgentData.SelectedItem as Agent;
            if (selectedItemAgent != null)
                NavigationService.Navigate(new AgentsDataActionPage(selectedItemAgent));
            else
                throw new Exception("Пожалуйста, выберите объект из списка!");
        }
        private void SearchAgentType( string type = "", string search = "" )
        {
            var agents = Data.bp.Agent.ToList();
            if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(type))
            {
                if (type == "ОАО")
                {
                    agents = agents.Where(item => item.AgentType.Title == "ОАО").ToList();
                }
                if (type == "Самозанятый")
                {
                    agents = agents.Where(item => item.AgentType.Title == "Самозанятый").ToList();
                }
                if (type == "ОО")
                {
                    agents = agents.Where(item => item.AgentType.Title == "ОО").ToList();
                }
                if (type == "Все")
                {
                    agents = agents.ToList();
                }
            }
            AgentData.ItemsSource = agents;
        }

        private void AgentDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItemAgent = AgentData.SelectedItem as Agent;
                if (selectedItemAgent != null)
                {
                    if (MessageBox.Show("Вы дествительно хотите удалить данные?", "Данные будут удалены навсегда!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        Data.bp.Agent.Remove(selectedItemAgent);
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
    }
}
