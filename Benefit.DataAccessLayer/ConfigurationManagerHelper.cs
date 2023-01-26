using System.Configuration;

namespace Benefit.DataAccessLayer
{
    public static class ConfigurationManagerHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BenefitConnectionString"].ConnectionString.ToString();
        }

        public static string GetConnectionString1()
        {
            return "Server=INLPF2SRVPV;Database=MvcDemoDb;Trusted_Connection=True";
        }

    }
}