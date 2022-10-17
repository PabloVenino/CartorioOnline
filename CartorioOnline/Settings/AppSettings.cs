namespace CartorioOnline.Services
{
    public class AppSettings : IAppSettings
    {
        // JWT Settings
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public string JwtKey { get; set; }

        // DB Connection Settings
        public string ConnectionString { get; set; }
    }
}
