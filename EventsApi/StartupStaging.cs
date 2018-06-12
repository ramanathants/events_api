using Microsoft.Extensions.Configuration;

namespace EventsApi
{
    public class StartupStaging : Startup
    {
        public StartupStaging(IConfiguration config) : base(config)
        {
        }
    }
}