using AutoMapper;
using EventsApi.Models;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;

namespace EventsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            //Register DBContext        
            services.AddDbContext<EventDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IEventRepository, EventRepository>();

            services.AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                });

            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(BindIdentityServerAuthenticationOptions);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("docs", new Info { Title = "Events Api", Version = "v1" });
                c.AddSecurityDefinition("oauth2",
                    new OAuth2Scheme
                    {
                        Description = "Requests an authorization token from Identity Provider",
                        TokenUrl = Configuration["IdentityProvider:Authority"] + "/connect/token",
                        Flow = "application"
                    });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "oauth2", new[] { "readAccess", "writeAccess" } }
                });
            });

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IServiceProvider serviceProvider)
        {
            app.UseAuthentication();

            loggerFactory.AddNLog();
            // app.UseHsts();
            // app.UseHttpsRedirection();
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c => { c.RouteTemplate = "{documentName}/swagger.json"; });
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/docs/swagger.json", "Events Api"); });

            app.UseMvc();
        }

        public virtual void BindIdentityServerAuthenticationOptions(IdentityServerAuthenticationOptions options)
        {
            Configuration.GetSection("IdentityProvider").Bind(options);
        }
    }
}
