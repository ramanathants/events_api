using System.Collections.Generic;
using System.Linq;

namespace EventsApi.Models
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _context;

        public EventRepository(EventDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EventDetail> GetList(bool processed)
        {
            return _context.EventDetails.Where(p => p.Processed == processed).ToList();
        }

    }
}