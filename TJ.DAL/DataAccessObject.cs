using System.Configuration;


namespace TJ.DAL
{
    public class DataAccessObject
    {

        public POTJDataContext DataContext = new POTJDataContext(ConfigurationManager.ConnectionStrings["conString"].ToString());

    }
}
