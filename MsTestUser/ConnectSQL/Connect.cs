
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

