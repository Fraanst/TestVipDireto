using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FluxosTestes_Vip.Controller
{
    public class QueryDAO
    {
        static ConnectionFactory Con = new ConnectionFactory(ConfigurationManager.ConnectionStrings["Vip_Dev"].ToString());

        public static bool Update_email()
        {        
           return  Con.ExecuteNonQuery("Update VipDireto.Usuario set IsEmailConfirmado= 1 where CPF = '136.628.961-49'");
        }
    }
}
