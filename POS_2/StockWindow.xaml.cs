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
using System.Data.SqlClient;
using LogicLayer;

namespace POS_2
{
    /// <summary>
    /// Interaction logic for StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        FacadeController f = FacadeController.GetFacade();
        public DataSet inventoryData;
        public DataTable dt;
        public static bool isRoot; //login using root credentials
        public LogicLayer.Objects.Product product;

        public StockWindow(bool root)
        {
            InitializeComponent();
            isRoot = root;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            inventoryData =  f.GetInventoryData();
            dt = inventoryData.Tables[0];
            DataRow[] t = dt.Select("ProductName like  '" + SearchBox.Text + "%'");
            dataGrid1.ItemsSource = new DataView(dt, "ProductName like  '" + SearchBox.Text + "%'", "ProductID", DataViewRowState.CurrentRows);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.GetData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> categories = new List<string>();
            List<string> manufacturers = new List<string>();

            DataView view = new DataView(dt);

            DataTable distinctCategories = new DataTable();
            distinctCategories = view.ToTable(true, "Category");
            foreach (DataRow row in distinctCategories.Rows)
                categories.Add(row[0].ToString());

            DataTable distinctManufacturer = new DataTable();
            distinctManufacturer = view.ToTable(true, "Manufacturer");
            foreach (DataRow row in distinctManufacturer.Rows)
                manufacturers.Add(row[0].ToString());

            product = new LogicLayer.Objects.Product();
            Stock_AddItem stock_Add = new Stock_AddItem(product,false);
            stock_Add.SetComboValues(categories, manufacturers);
            if(stock_Add.ShowDialog()==true)
            {
                DataRow dr = dt.NewRow();
                
                dr["ProductName"] = product.productName;
                dr["OfferedPrice"] = product.price.ToString();
                dr["Category"] = product.category;
                dr["Manufacturer"] = product.manufacturer;
                dr["Quantity"] = product.quantity.ToString();
                dr["DateAdded"] = product.dateAdded;
                dt.Rows.Add(dr);
                UpdateData();
            }
        }

        private void UpdateData()
        {
            f.UpdateInventory(inventoryData);
            this.GetData();
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            int selected = dataGrid1.SelectedIndex;
            if (selected == -1)
                MessageBox.Show("Select an item to edit");
            else
            {
                List<string> categories = new List<string>();
                List<string> manufacturers = new List<string>();

                DataView view = new DataView(dt);

                DataTable distinctCategories = new DataTable();
                distinctCategories = view.ToTable(true, "Category");
                foreach (DataRow row in distinctCategories.Rows)
                    categories.Add(row[0].ToString());

                DataTable distinctManufacturer = new DataTable();
                distinctManufacturer = view.ToTable(true, "Manufacturer");
                foreach (DataRow row in distinctManufacturer.Rows)
                    manufacturers.Add(row[0].ToString());


                product = new LogicLayer.Objects.Product();
                DataRowView tempRow = (DataRowView)dataGrid1.SelectedItems[0];
                product.productName = tempRow["ProductName"].ToString();
                product.price = int.Parse(tempRow["OfferedPrice"].ToString());
                product.category = tempRow["Category"].ToString();
                product.manufacturer = tempRow["Manufacturer"].ToString();
                product.quantity = int.Parse(tempRow["Quantity"].ToString());
                product.dateAdded = DateTime.Parse(tempRow["DateAdded"].ToString());

                Stock_AddItem stock_Add = new Stock_AddItem(product,true);
                stock_Add.SetComboValues(categories, manufacturers);
                
                if (stock_Add.ShowDialog() == true)
                {
                    dt.Rows[selected]["ProductName"] = product.productName;
                    dt.Rows[selected]["OfferedPrice"] = product.price.ToString();
                    dt.Rows[selected]["Category"] = product.category;
                    dt.Rows[selected]["Manufacturer"] = product.manufacturer;
                    dt.Rows[selected]["Quantity"] = product.quantity.ToString();
                    dt.Rows[selected]["DateAdded"] = product.dateAdded;

                    UpdateData();
                }
            }
        }
        
        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            int s = dataGrid1.SelectedItems.Count;
            int selected = dataGrid1.SelectedIndex;
            if (selected == -1)
                MessageBox.Show("Select an item to delete");
            else
            {
                if(MessageBox.Show("Are you sure?","Confirm",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    for(int i=0;i<s;i++)
                    {
                        dt.Rows[i].Delete();
                    }
                    UpdateData();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            f.CloseConnection();
            if(!isRoot) //if not logged in as root logout of session
                LoginWindow.signedIn = false;
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
