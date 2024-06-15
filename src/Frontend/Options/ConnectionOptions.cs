namespace Frontend.Options
{
    public class ConnectionOptions
    {
        public const string Key = "connection";

        public string BaseUrl { get; set; } = string.Empty;
        public string CombatHubRoute { get; set; } = string.Empty;
    }
}
