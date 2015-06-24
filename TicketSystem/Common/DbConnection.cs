using System.Configuration;

namespace TicketSystem.Common
{
    public class DbConnection
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["conString"].ToString();
        }
    }
}
