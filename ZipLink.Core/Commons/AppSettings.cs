using Microsoft.Extensions.Configuration;

namespace ZipLink.Core.Commons
{
    public class AppSettings
    {
        public readonly string _connectionString = string.Empty;
        public AppSettings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ConnectionString").GetSection("cs").Value;
        }
        public string ConnectionString
        {
            get => _connectionString;
        }
    }
}
