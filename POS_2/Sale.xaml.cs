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


namespace POS_2
{
    /// <summary>
    /// Interaction logic for Sale.xaml
    /// </summary>
    public partial class Sale : Window
    {
        FacadeController f = FacadeController.GetFacade();
        public DataSet inventoryData;
        public DataTable dt;
        public DataTable saleTable;
        private DataSet saleData;

        public Sale()
        {
            InitializeComponent();
            saleTable = new DataTable();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.GetData();
        }

        private void GetData()
        {
            inventoryData = f.GetInventoryData();
            dt = inventoryData.Tables[0];
            DataRow[] t = dt.Select("ProductName like  '" + searchBox.Text + "%'");
            dataGrid1.ItemsSource = new DataView(dt, "ProductName like  '" + searchBox.Text + "%'", "ProductID", DataViewRowState.CurrentRows);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.GetData();
        }

        private void dataGrid1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DataRowView tempRow = (DataRowView)dataGrid1.SelectedItems[0];
                saleTable.Rows.Add(tempRow);
                currentSale.ItemsSource = new DataView(saleTable);
            }
               
        }
    }
}
