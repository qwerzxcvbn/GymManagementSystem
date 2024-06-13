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
    /// Логика взаимодействия для WindowAddClients.xaml
    /// </summary>
    public partial class WindowAddClients : Window
    {
        GymDBEntities GymDBEntities = new GymDBEntities();
        public WindowAddClients()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int numberphoneValue;
            if (!int.TryParse(numberphone.Text, out numberphoneValue))
            {
                MessageBox.Show("Введите корректное значение номера телефона");
                return;
            }

            Сlients сlients = new Сlients
            {
                numberphone = numberphoneValue,
                fio = fio.Text,
                subscriber = subscriber.Text
            };

            GymDBEntities.Сlients.Add(сlients);
            GymDBEntities.SaveChanges();
            Close();
        }
    }
}
