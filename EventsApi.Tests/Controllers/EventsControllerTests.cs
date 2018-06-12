using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using EventsApi.Tests.Fixtures;
using Newtonsoft.Json;
using Xunit;

namespace EventsApi.Tests.Controllers
{
    [Trait("Category", "Integration")]
    [Collection("TestServerCollection")]
    public class EventsControllerTests
    {
        private readonly HttpClient _client;

        public EventsControllerTests(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }

        
        [Fact(DisplayName = "GetAll processed should return all processed events with Ok Status Code")]
        public void GetAllProcessedShouldReturnAllProcessedEventsWithOkStatusCode()
        {
            var response = _client.GetAsync("v1/Events?processed=true").Result;
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            var responseString = response.Content.ReadAsStringAsync().Result;
            Assert.NotEmpty(responseString);

            var result =
                JsonConvert.DeserializeObject<List<dynamic>>(responseString);

            Assert.Equal(2, result.Count);
            Assert.Equal("Shipping", result[0]["event_type"].ToString());
            Assert.Equal(
                "R120324A|1|R75G12|REG-PROREAD PIT GAL 6WHL 2 HP TURBINE|03576100|0||0|1.0000000000|1.0000000000|02-26-2018",
                result[0]["event_data"].ToString());
          
            Assert.Equal("Shipping", result[1]["event_type"].ToString());
            Assert.Equal(
                "S293014|5|RYM2G21|REG-ECODER L900i PIT 3/4 GAL|04346500|0||0|20.0000000000|20.0000000000|03-02-2018",
                result[1]["event_data"].ToString());
          }


    }
}