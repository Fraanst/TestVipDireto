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
        ConnectionFactory Connection = new ConnectionFactory(ConfigurationManager.ConnectionStrings[""].ToString());

    }
}
