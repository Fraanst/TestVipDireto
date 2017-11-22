using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxosTestes_Vip.Controller
{
    public class WritetextFile

    {
        private static string LogErro = ConfigurationManager.AppSettings["LogErro"];

            public  void SalvaTxt(string Erro)
            {
                string[] lines = { "************************************************", Erro , "************************************************" };
                System.IO.File.WriteAllLines(LogErro, lines);
            }
        }
        //Output (to WriteLines.txt):
        //   First line
        //   Second line
        //   Third line
}
