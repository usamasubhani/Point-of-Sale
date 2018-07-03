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

namespace POS_2
{
    /// <summary>
    /// Interaction logic for RootMenu.xaml
    /// </summary>
    public partial class RootMenu : Window
    {
        public RootMenu()
        {
            InitializeComponent();
            LoginWindow.signedIn = true;
        }

        private void MngStcBtn_Click(object sender, RoutedEventArgs e)
        {
            StockWindow stockWindow = new StockWindow(true);
            this.Hide();
            stockWindow.ShowDialog();
            this.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
            //LoginWindow.signedIn = false;
        }

        private void AddUsrBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }

        private void ViewAllBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewAllBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void POSbtn_Click(object sender, RoutedEventArgs e)
        {
            Sale sale = new Sale();
            sale.ShowDialog();
        }
    }
}
