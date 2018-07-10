using System;

namespace EventsApi.Dtos
{
    public class EventDetailDto
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public bool Processed { get; set; }
        public DateTime? EventDateTime { get; set; }
        public string EventData { get; set; }      
        public string OrderNumber { get; set; }
        public int? LineItemNumber { get; set; }
        public string PartNumber { get; set; }
    }
}