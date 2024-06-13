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
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        GymDBEntities GymDBEntities = new GymDBEntities();
        public WindowAdmin()
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataClients.SelectedItem != null)
            {
                Сlients selectedСlients = DataClients.SelectedItem as Сlients;

                if (selectedСlients != null)
                {
                    GymDBEntities.Сlients.Remove(selectedСlients);
                    GymDBEntities.SaveChanges();
                    App();
                }
            }
            else if (DataTrainers.SelectedItem != null)
            {
                Trainers selectedTrainers = DataTrainers.SelectedItem as Trainers;

                if (selectedTrainers != null)
                {
                    GymDBEntities.Trainers.Remove(selectedTrainers);
                    GymDBEntities.SaveChanges();
                    App();
                }
            }
            else if (DataSimulators.SelectedItem != null)
            {
                Simulators selectedSimulators = DataSimulators.SelectedItem as Simulators;

                if (selectedSimulators != null)
                {
                    GymDBEntities.Simulators.Remove(selectedSimulators);
                    GymDBEntities.SaveChanges();
                    App();
                }
            }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            WindowAddClients windowAddClients = new WindowAddClients();
            windowAddClients.Show();
        }

        private void AddTreiners_Click(object sender, RoutedEventArgs e)
        {
            WindowAddTrainers windowAddTrainers = new WindowAddTrainers();
            windowAddTrainers.Show();
        }

        private void AddSimulator_Click(object sender, RoutedEventArgs e)
        {
            WindowAddSimulator windowAddSimulator = new WindowAddSimulator();
            windowAddSimulator.Show();
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

        private void AddWorkout_Click(object sender, RoutedEventArgs e)
        {
            WindowAddWork windowAddWork = new WindowAddWork();
            windowAddWork.Show();
        }
    }
}



