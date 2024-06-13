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
    /// Логика взаимодействия для WindowAddSimulator.xaml
    /// </summary>
    public partial class WindowAddSimulator : Window
    {
        GymDBEntities GymDBEntities = new GymDBEntities();
        public WindowAddSimulator()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Simulators simulators = new Simulators
            {
                nameSimulator = nameSimul.Text,
                description = description.Text,
                availability = availability.Text
            };

            GymDBEntities.Simulators.Add(simulators);
            GymDBEntities.SaveChanges();
            Close();

        }
    }
}
