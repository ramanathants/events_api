using System;
using EventsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventsApi.Tests.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public EventDbContext EventDbContext { get; }
        public IConfiguration Configuration { get; }

        public DatabaseFixture()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json");

            Configuration = configurationBuilder.Build();

            var contextBuilder = new DbContextOptionsBuilder<EventDbContext>();
            contextBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            EventDbContext = new EventDbContext(contextBuilder.Options);
            EventDbContext.Database.EnsureCreated();
            SeedData.Initialize(EventDbContext);
        }

        public void Dispose()
        {
            EventDbContext.Database.EnsureDeleted();
            EventDbContext.Dispose();
        }
    }
}