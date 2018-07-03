using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace DataAccess
{
    public class GetInventory
    {
        SqlCommand sqlCommand;
        SqlConnection DBConnection;
        SqlDataAdapter da;
        SqlCommandBuilder commandBuilder;
        DataSet ds;
        string query;

        public GetInventory()
        {
            string t = ConfigurationManager.ConnectionStrings["POS_2.Properties.Settings.POSConnectionString"].ConnectionString;
            DBConnection = new SqlConnection(t);
            DBConnection.Open();
            query = "Select * From Inventory";
            this.da = new SqlDataAdapter();
            sqlCommand = new SqlCommand(query, DBConnection);
            commandBuilder = new SqlCommandBuilder(this.da);
            this.ds = new DataSet();
        }
        public DataSet GetInventoryData()
        {
            da.SelectCommand = sqlCommand;
            this.da.Fill(this.ds, "Inventory");
            return this.ds;
        }
        
        public void UpdateData(DataSet updatedData)
        {
            da.Update(updatedData, "Inventory");
        }

        public void CloseConnection()
        {
            DBConnection.Close();
        }
    }
}
