using System;
using System.Linq;
using EventsApi.Models;
using EventsApi.Tests.Fixtures;
using Xunit;

namespace EventsApi.Tests.Models
{
    [Collection("TestServerCollection")]
    [Trait("Category", "Unit")]
    public class EventRepositoryTests 
    {
        private readonly EventRepository _eventRepository;

        public EventRepositoryTests(DatabaseFixture fixture)
        {
            _eventRepository = new EventRepository(fixture.EventDbContext);
        }

        [Fact(DisplayName = "GetAll Processed Should Return All Processed Events")]
        public void GetAllProcessedShouldReturnAllProcessedEvents()
        {
            var result = _eventRepository.GetList(true).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("Shipping", result[0].EventType);
            Assert.Equal(Convert.ToDateTime("2018-03-02 00:00:00"), result[0].EventDateTime);
            Assert.Equal(
                "R120324A|1|R75G12|REG-PROREAD PIT GAL 6WHL 2 HP TURBINE|03576100|0||0|1.0000000000|1.0000000000|02-26-2018",
                result[0].EventData);
            Assert.Equal(Convert.ToDateTime("2018-05-15 09:26:00"), result[0].InsertedDateTime);
            Assert.Equal(Convert.ToDateTime("2018-05-15 09:26:00"), result[0].UpdatedDateTime);

            Assert.Equal("Shipping", result[1].EventType);
            Assert.Equal(Convert.ToDateTime("2018-03-02 00:00:00"), result[1].EventDateTime);
            Assert.Equal(
                "S293014|5|RYM2G21|REG-ECODER L900i PIT 3/4 GAL|04346500|0||0|20.0000000000|20.0000000000|03-02-2018",
                result[1].EventData);
            Assert.Equal(Convert.ToDateTime("2018-05-15 09:26:00"), result[1].InsertedDateTime);
            Assert.Equal(Convert.ToDateTime("2018-05-15 09:26:00"), result[1].UpdatedDateTime);
        }

    
    }
}