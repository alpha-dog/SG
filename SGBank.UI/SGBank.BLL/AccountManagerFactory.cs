using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class AccountManagerFactory
    {
        public static AccountManager Create() //most factory classes name the primary method 'create'
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString(); 

            switch(mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                default:
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository());
                case "PremiumTest":
                    return new AccountManager(new PremiumAccountTestRepository());
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
