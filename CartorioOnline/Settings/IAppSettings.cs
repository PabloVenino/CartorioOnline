namespace CartorioOnline.Services
{
    public interface IAppSettings
    {
        // JWT Settings
        string JwtIssuer { get; set; }
        string JwtAudience { get; set; }
        string JwtKey { get; set; }


        // DB Connection Settings
        string ConnectionString { get; set; }
    }
}
