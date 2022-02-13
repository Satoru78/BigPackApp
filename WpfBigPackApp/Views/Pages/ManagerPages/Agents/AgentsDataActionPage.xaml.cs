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
using Microsoft.Win32;
using System.IO;

namespace WpfBigPackApp.Views.Pages.ManagerPages.Agents
{
    /// <summary>
    /// Логика взаимодействия для AgentsDataActionPage.xaml
    /// </summary>
    public partial class AgentsDataActionPage : Page
    {
        public List<AgentType> AgentTypes { get; set; }
        public List<DirectorName> DirectorNames { get; set; }
        public List<Priority> Priorities { get; set; }
        public List<PointsOfSales> PointsOfSales { get; set; }
        public List<Role> Roles { get; set; }
        public Agent Agent { get; set; }
        public AgentsDataActionPage(Agent agent)
        {
            InitializeComponent();
            Roles = Data.bp.Role.ToList();
            Priorities = Data.bp.Priority.ToList();
            PointsOfSales = Data.bp.PointsOfSales.ToList();
            DirectorNames = Data.bp.DirectorName.ToList();
            AgentTypes = Data.bp.AgentType.ToList();
            Agent = agent;
            this.DataContext = this;
        }

        private void SelectLogotype_Click(object sender, RoutedEventArgs e)
        {
            file.Filter = "Image (*.jpg;*.jpeg;*.png;) |  *.jpg; *.jpeg; *.png";
            if (file.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(file.FileName));
                Log.Source = image;
            }
        }
        OpenFileDialog file = new OpenFileDialog();
        private void AgentDataSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Agent.ID == 0)
                {
                    Agent.GetLogotype = "\\agents\\" + System.IO.Path.GetFileName(file.FileName);
                    Data.bp.Agent.Add(Agent);
                }
                File.Copy(file.FileName, $"agents\\{System.IO.Path.GetFileName(file.FileName).Trim()}", true);
                Agent.GetLogotype = "\\agents\\" + System.IO.Path.GetFileName(file.FileName);
                Data.bp.SaveChanges();
                MessageBox.Show("Данные сохранены", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
