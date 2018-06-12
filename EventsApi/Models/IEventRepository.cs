using System.Collections.Generic;

namespace EventsApi.Models
{
    public interface IEventRepository
    {
        IEnumerable<EventDetail> GetList(bool processed);
    }
}