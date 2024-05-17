using Microsoft.Extensions.Configuration;

namespace TechShop.Utility
{
    internal  static class DBPropertyUtil
    {
        private static IConfiguration _iconfiguration;
          static DBPropertyUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();

        }

        public static string GetConnectionString() 
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
