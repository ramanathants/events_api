using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsApi.Models
{
    [Table("EventDetail")]
    public class EventDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EventDetailId")]
        public int Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string EventType { get; set; }
        [Column(TypeName = "bit")]
        public bool Processed { get; set; }
        public DateTime? EventDateTime { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string EventData { get; set; }
        public DateTime? InsertedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string OrderNumber { get; set; }
        public int? LineItemNumber { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string PartNumber { get; set; }
    }
}