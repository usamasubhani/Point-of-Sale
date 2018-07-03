using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
namespace LogicLayer
{
    class GetInventory
    {
        static DataAccess.GetInventory i;

        public static DataSet GetInventoryData()
        {
            i = new DataAccess.GetInventory();
            return i.GetInventoryData();
        }
        public static void UpdateInventoryData(DataSet updatedData)
        {
            i.UpdateData(updatedData);
        }
        public static void CloseConnection()
        {
            i.CloseConnection();
        }
    }
}
