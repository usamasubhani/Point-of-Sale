using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace LogicLayer.Objects
{
    public class User
    {
        public int userId { get; set; }
        public string name;
        public string username;
        public string type;
        public string password;

        public User(int id,string name,string username,string type)
        {
            this.userId = id;
            this.name = name.Trim();
            this.username = username.Trim();
            this.type = type.Trim();
        }
        public User(string name, string username,string password, string type)
        {
            this.name = name;
            this.username = username;
            this.password = password;
            this.type = type;
        }

        public int AddUser()
        {
            return DataAccess.Login.AddUser(this.name, this.username, this.password, this.type);
        }
    }
}
