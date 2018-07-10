using EventsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using EventsApi.Dtos;
using AutoMapper;

namespace EventsApi.Controllers
{
    [Route("v1/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _repository;
        private readonly ILogger _logger;

        public EventsController(IEventRepository repository,
            ILogger<EventsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(bool processed)
        {
           _logger.LogInformation("Mytesting "+ ControllerContext.HttpContext.TraceIdentifier);
            var response = _repository.GetList(processed);

            return Ok(Mapper.Map<List<EventDetailDto>>(response));
        }

    }
}
