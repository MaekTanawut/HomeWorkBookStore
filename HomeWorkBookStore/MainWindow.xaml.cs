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

namespace HomeWorkBookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool loginStatus = DataAccess.CheckLogin(txtUsername.Text, txtPassword.Password);

            if (txtUsername.Text != "" & txtPassword.Password != "")
            {
                if (loginStatus)
                {
                    HomeMenu homeMenu = new HomeMenu();
                    homeMenu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username หรือ Password ผิดกรุณากรอกใหม่", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Clear();
                }
            }
            else
            {

                if (txtUsername.Text != "")
                {
                    MessageBox.Show("กรุณากรอก Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txtPassword.Password != "")
                {
                    MessageBox.Show("กรุณากรอก Username", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show("กรุณากรอก Username และ Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
