using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Login
    {
        public static DataSet Authenticate(string userName, string password)
        {
            try
            {
                ConnectToDatabase c = new ConnectToDatabase();
                c.ConnectToDB();
                string query = "select * from Users where Username='" +userName+ "' AND Password='" +password+ "' ";
                
                DataSet tempData = c.ExceuteQuerySet(query, "Users");
                c.CloseConnection();
                if (tempData.Tables[0].Rows.Count == 1) //Credentials matched with one record
                    return tempData; //return type of user
                else
                    return null;
                
            }
            catch
            {
                return null;
            }

            

        }


        public static int AddUser(string name, string username,string password, string type)
        {
            ConnectToDatabase c = new ConnectToDatabase();
            c.ConnectToDB();
            string query = "INSERT INTO users (Name,Username,Password,type) values ( '" + name + "' , '" + username + "' , '" + password + "', '" + type + "')";

            int result = c.UpdateQuery(query);
            c.CloseConnection();

            return result;
        }
    }
}
