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

namespace GymManagementSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GymDBEntities GymDBEntities = new GymDBEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loginfo = GymDBEntities.Users.Where(p => p.login == Login.Text && p.pass == Pass.Password).Single();
                if (loginfo.idRole == 1)
                {
                    WindowAdmin windowAdmin = new WindowAdmin();
                    windowAdmin.Show();
                    this.Close();
                }
                else if (loginfo.idRole == 2)
                {
                    WindowTrainers windowTrainers = new WindowTrainers();
                    windowTrainers.Show();
                    this.Close();
                }
                else if (loginfo.idRole == 3)
                {
                    WindowManager windowManager = new WindowManager();
                    windowManager.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

    }
}

