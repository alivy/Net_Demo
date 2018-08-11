using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Type_Conver
{
    public class UserModel
    {
        private long id = 1;

        private string name = "name";

        private int gender = 0;

        private int age = 20;

        private string userName = "userName";

        private string password = "password";

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }  
    }

  
}