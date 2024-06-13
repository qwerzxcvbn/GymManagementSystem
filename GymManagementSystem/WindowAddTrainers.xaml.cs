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
    /// Логика взаимодействия для WindowAddTrainers.xaml
    /// </summary>
    public partial class WindowAddTrainers : Window
    {
        GymDBEntities GymDBEntities = new GymDBEntities();
        public WindowAddTrainers()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Trainers trainers = new Trainers
            {
                fio = fio.Text,
                specialization = specialization.Text,
                raspisaniye = raspisaniye.Text
            };

            GymDBEntities.Trainers.Add(trainers);
            GymDBEntities.SaveChanges();
            Close();
        }
    }
}
