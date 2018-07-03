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
using LogicLayer;
using LogicLayer.Objects;
namespace POS_2
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static bool signedIn;
        public LoginWindow()
        {
            InitializeComponent();
            signedIn = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != string.Empty && passTextBox.Password != string.Empty) //Empty Field Check
            {
                FacadeController f = FacadeController.GetFacade();
                
                User loginResult = f.Authenticate(nameTextBox.Text, passTextBox.Password.ToString());
                nameTextBox.Text = "";
                passTextBox.Password = string.Empty;
                if (loginResult != null)
                {
                    if (loginResult.type == "Salesman")
                    {
                        MessageBox.Show(loginResult.type);
                    }
                    else if (loginResult.type == "Admin")
                    {
                        signedIn = true;
                        StockWindow stockWindow = new StockWindow(false);
                        this.Hide();
                        stockWindow.ShowDialog();
                        if (!signedIn)
                            this.Show();
                    }
                    else if (loginResult.type == "Root")
                    {
                        signedIn = true;
                        RootMenu rm = new RootMenu();
                        this.Hide();
                        rm.ShowDialog();
                        if(!signedIn)
                            this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
            }
        }
    }
}
