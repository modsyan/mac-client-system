namespace MacClientSystem.Application.Common.Options;

public class IntegrationOptions
{
    
    
    public const string MACSYS_ONLINE_API = "Integration:MacSysOnlineApi";
    public const string INTEGRATION_CLIENTS = "Integration:Clients";
    
    public class MacSysOnlineApi
    {
        public string BaseUrl { get; set; } = null!;
        public string TokenEndPoint { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public string Secret { get; set; } = null!;
    }
    
    public class Clients
    {
        public string ClientId { get; set; } = null!;
        public string Secret { get; set; } = null!;
    }
    
}
