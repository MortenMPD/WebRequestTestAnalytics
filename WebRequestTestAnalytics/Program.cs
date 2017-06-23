using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebRequestTestAnalytics {
    class Program {
        static void Main(string[] args)
        {
            var apiAddress =
                "http://envtools/Analytics/Grids?date=2017-05-25&todate=2017-06-23&filterteam=MO-MO-T,MO-PEM-T,MO-RIM-T&grouping=testdata,testcase&measure=results,rerunned,passed,failed,analysed,defects,falsepositives,notanalysed,passedpct,failedpct,defectspct,analysedpct,falsepositivespct,notanalysedpct";
            Uri uri = new Uri(apiAddress);
            ICredentials credentials = CredentialCache.DefaultCredentials;
            NetworkCredential credential = credentials.GetCredential(uri, "Basic");
            WebReader webReader = new WebReader(apiAddress, credential);
            var texts = webReader.GetData();
            foreach (string text in texts)
            {
                System.Console.WriteLine(text);
            }
            System.Console.Read();
        }
    }
}
