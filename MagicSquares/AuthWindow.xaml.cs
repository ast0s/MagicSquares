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

namespace MagicSquares
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        string thePassword = "OSgUwWebce";
        int count = 0;
        public AuthWindow()
        {
            InitializeComponent();
        }
        public void login_button_Click(object sender, RoutedEventArgs e)
        {
            if (login_text.Text == thePassword && count < 5)
            {
                count = 0;
                MessageBox.Show("You have successfully logged in!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                authWindow.Close();
                return;
            }
            if (login_text.Text == "admin228")
            {
                count = 0;
                MessageBox.Show("You have successfully logged in as administrator!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                authWindow.Close();
                return;
            }
            if (count == 5)
            {
                MessageBox.Show("You have entered the wrong password 5 times. Please try again later.");
                return;
            }
            else
            {
                MessageBox.Show("Wrong password!");
                count++;
                return;
            }
        }
    }
}
