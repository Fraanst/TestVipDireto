using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxosTestes_Vip.Controller
{
    public class WritetextFile

    {

        DateTime localDate;
        private static string LogErro = ConfigurationManager.AppSettings["LogErro"];
        private static string Log = ConfigurationManager.AppSettings["_LogErro"];

            public void SalvaTxt(string Erro)
            {

            string line1 = "************************************************";
            string line2 = Erro;
            string line3 = "************************************************";
            string lines = line1 +"\n"+ line2 +"\n"+ line3;
             // System.IO.File.WriteAllLines(LogErro, lines);
            System.IO.File.WriteAllText(LogErro, lines);
            }
            
            

        public void SalvaTxtBk(string Erro)
        {
            string line1 = "************************************************";
            string line2 = Erro;
            string line3 = "************************************************";
            string lines = line1 + "\n" + line2 + "\n" + line3;
            // System.IO.File.WriteAllLines(LogErro, lines);
            System.IO.File.WriteAllText(Log, lines);
        }

}
        //Output (to WriteLines.txt):
        //   First line
        //   Second line
        //   Third line
}
