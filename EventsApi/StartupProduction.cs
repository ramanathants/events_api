using Microsoft.Extensions.Configuration;
using System;

namespace EventsApi
{
    public class StartupProduction : Startup
    {
        public StartupProduction(IConfiguration config, IServiceProvider provider) : base(config)
        {
        }
    }
}