using System.Configuration;

namespace Capitu.Infra
{
    public class SecureConfigurationManager
    {
        public static string Web_EnderecoCDN
        {
            get { return ConfigurationManager.AppSettings["Web_EnderecoCDN"].Decrypt().Replace("localhost", System.Net.Dns.GetHostName()); }
        }
    }
}
