using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class ConnectSettings
    {
        public string server = "localhost";
        public string userid = "DenFuvier";
        public string password = "N1PGKt1mT3UAlRRa";
        public string database = "boyk";

        public string GetConnect()
        {
            return $"server={server};userid={userid};password={password};database={database}";
        }
         
    }

}

