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
    /// Interaction logic for singleInput.xaml
    /// </summary>
    public partial class singleInput : Window
    {
        string temp;
        public singleInput(string temp)
        {
            InitializeComponent();
            this.temp = temp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(textBox1.Text != string.Empty )
            {
                Stock_AddItem.temp = textBox1.Text;
                this.DialogResult = true;
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = false;
            this.Close();
        }
    }
}
