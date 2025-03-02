using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Managers
{
    public static class LoginManager
    {
        static HotelContext context = new HotelContext();
        public static bool Login(string table,string username, string password)
        {
            if(table == "frontend")
            {
                return context.Frontends.Any(p => p.UserName == username && p.Password == password);
            }
            else if(table == "kitchen")
            {
                return context.Kitchens.Any(p => p.UserName == username && p.Password == password);
            }
            return false;
        }
    }
}
