using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
namespace LogicLayer
{
    class Login
    {
        public static Objects.User Authenticate(string userName, string password)
        {
            DataSet user = DataAccess.Login.Authenticate(userName, password);
            if (user != null)
            {
                DataRow userRow = user.Tables[0].Rows[0];
                Objects.User u = new Objects.User(int.Parse(userRow["UserID"].ToString()), userRow["Name"].ToString(), userRow["Username"].ToString(), userRow["Type"].ToString());
                return u;
            }
            else
                return null;
        }
    }
}
