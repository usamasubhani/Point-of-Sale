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
using System.Data;
using LogicLayer;
using Microsoft.VisualBasic;
namespace POS_2
{
    /// <summary>
    /// Interaction logic for Stock_AddItem.xaml
    /// </summary>
    public partial class Stock_AddItem : Window
    {
        LogicLayer.Objects.Product tempProduct;

        List<string> cat;
        List<string> man;

        public static string temp = ""; //Used to retrieve value from single input dialog to add categories in combos

        public Stock_AddItem(LogicLayer.Objects.Product tempProduct, bool isUpdate)
        {
            InitializeComponent();
            this.tempProduct = tempProduct;
            if (isUpdate)
            {
                NameTxtBox.Text = tempProduct.productName;
                CategoryCombo.SelectedItem = tempProduct.category;
                PriceTxtBox.Text = tempProduct.price.ToString();
                ManCombo.SelectedItem = tempProduct.manufacturer;
                QuantityTxtBox.Text = tempProduct.quantity.ToString();
                DateSelector.SelectedDate = tempProduct.dateAdded;
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void SetComboValues(List<string> categories, List<string> manufacturers)
        {
            cat = categories;
            man = manufacturers;
            CategoryCombo.ItemsSource = cat;
            ManCombo.ItemsSource = man;
            DateSelector.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTxtBox.Text == string.Empty || PriceTxtBox.Text == string.Empty || QuantityTxtBox.Text == string.Empty)
                MessageBox.Show("ERROR");
            else
            {
                tempProduct.productName = NameTxtBox.Text;
                tempProduct.category = CategoryCombo.Text;
                tempProduct.price = int.Parse(PriceTxtBox.Text);
                tempProduct.manufacturer = ManCombo.Text;
                tempProduct.quantity = int.Parse(QuantityTxtBox.Text);
                tempProduct.dateAdded = DateSelector.SelectedDate.Value.Date;

                
                this.DialogResult = true;
                this.Close();
            }
        }

        //Add new categroy
        private void AddCatBtn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            
            singleInput catInput = new singleInput(temp);
            if (catInput.ShowDialog() == true)
            {
                cat.Add(temp);
                this.SetComboValues(cat,man);
                CategoryCombo.SelectedItem = temp;
            }
            
        }

        //Add new manufacturer
        private void AddManBtn_Click(object sender, RoutedEventArgs e)
        {
            singleInput manInput = new singleInput(temp);
            if (manInput.ShowDialog() == true)
            {
                man.Add(temp);
                this.SetComboValues(cat, man);
                ManCombo.SelectedItem = temp;
            }
        }
    }
}
