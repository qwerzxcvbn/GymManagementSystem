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

namespace GymManagementSystem
{
    /// <summary>
    /// Логика взаимодействия для WindowManager.xaml
    /// </summary>
    public partial class WindowManager : Window
    {
        GymDBEntities GymDBEntities = new GymDBEntities();
        public WindowManager()
        {
            InitializeComponent();
            App();
        }
        private void App()
        {
            DataClients.ItemsSource = GymDBEntities.Сlients.ToList();
            DataTrainers.ItemsSource = GymDBEntities.Trainers.ToList();
            DataSimulators.ItemsSource = GymDBEntities.Simulators.ToList();
        }
        private void poisk_Click(object sender, RoutedEventArgs e)
        {
            string searchText = poisk.Text;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                Сlients foundСlients = GymDBEntities.Сlients.FirstOrDefault(c => c.fio.ToString() == searchText);
                if (foundСlients != null)
                {
                    DataClients.SelectedItem = foundСlients;
                    DataClients.ScrollIntoView(foundСlients);
                }
                Trainers foundTrainers = GymDBEntities.Trainers.FirstOrDefault(c => c.fio.ToString() == searchText);
                if (foundTrainers != null)
                {
                    DataClients.SelectedItem = foundTrainers;
                    DataClients.ScrollIntoView(foundTrainers);
                }
                Simulators foundSimulators = GymDBEntities.Simulators.FirstOrDefault(c => c.nameSimulator.ToString() == searchText);
                if (foundSimulators != null)
                {
                    DataClients.SelectedItem = foundSimulators;
                    DataClients.ScrollIntoView(foundSimulators);
                }
                else
                {
                    MessageBox.Show("Не найден.");
                }
            }
            App();


        }
    }
}
