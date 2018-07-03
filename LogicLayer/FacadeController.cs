using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace LogicLayer
{
    public class FacadeController
    {
        static FacadeController facade = new FacadeController();

        public static FacadeController GetFacade()
        {
            if (facade == null)
                facade = new FacadeController();
            return facade;
        }

        public Objects.User Authenticate(string userName, string password)
        {
            return Login.Authenticate(userName, password);
        }

        public DataSet GetInventoryData()
        {
            return GetInventory.GetInventoryData();
        }

        public void UpdateInventory(DataSet updated)
        {
            GetInventory.UpdateInventoryData(updated);
        }
        public void CloseConnection()
        {
            GetInventory.CloseConnection();
        }
    }
}
