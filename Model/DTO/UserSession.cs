using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UserSession
    {
      
        public UserSession()
        {
            UserName = "";
            //GrantID = false;
        }
        public UserSession(string username)
        {
            UserName = username;
            //GrantID = grantid;
        }


        public string UserName { get; set; }
        //public bool GrantID { get; set; }
    }
}

