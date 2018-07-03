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
namespace POS_2
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        
        public AddUser()
        {
            InitializeComponent();
            typeCombo.Items.Add("Admin");
            typeCombo.Items.Add("Salesman");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FacadeController f = FacadeController.GetFacade(); //TODO: create user using facade controller
            if (nameTxtBox.Text != string.Empty && usernameTxtBox.Text != string.Empty && pswdBox.Password != string.Empty && typeCombo.SelectedItem != null)
            {
                LogicLayer.Objects.User user = new LogicLayer.Objects.User(nameTxtBox.Text, usernameTxtBox.Text,pswdBox.Password.ToString(), typeCombo.SelectedItem.ToString());
                if (user.AddUser() > 0)
                    MessageBox.Show("User Added.");
                else
                    MessageBox.Show("Error adding user. Contact sysadmin");
                this.Close();
            }
        }
    }
}
