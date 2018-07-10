using EventsApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EventsApi
{
    public class StartupDevelopment : Startup
    {
        public StartupDevelopment(IConfiguration config) : base(config)
        {
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(IdentityProviderSeedData.GetApiResourceses())
                .AddInMemoryClients(IdentityProviderSeedData.GetClients());

            base.ConfigureServices(services);
        }
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IServiceProvider serviceProvider)
        {
            app.UseDeveloperExceptionPage();
            app.UseIdentityServer();

            base.Configure(app, env, loggerFactory, serviceProvider);

            var eventDbContext = serviceProvider.GetService<EventDbContext>();
            eventDbContext.Database.EnsureCreated();
            SeedData.Initialize(eventDbContext);
        }
    }
}