namespace MasterProject.DAL
{
    public class DAL_Helper
    {
        public static string ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");
    }
}
