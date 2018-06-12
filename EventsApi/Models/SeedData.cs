using System;
using System.Linq;

namespace EventsApi.Models
{
    public class SeedData
    {
        public static void Initialize(EventDbContext context)
        {
           
                if (context.EventDetails.Any())
                    return; // DB has been seeded

                context.EventDetails.AddRange(
                    new EventDetail
                    {
                        EventType = "Shipping",
                        Processed = false,
                        EventDateTime = Convert.ToDateTime("2018-03-02 00:00:00"),
                        EventData = "S293014|6|.13388-000|L900 NETWORK AS A SERVIC COMCAST 10 YEAR SUB|04346500|0|M|0|20.0000000000|20.0000000000|03-02-2018",
                        InsertedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                        UpdatedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                        OrderNumber = null,
                        LineItemNumber = null,
                        PartNumber = null
                    },
                    new EventDetail
                    {
                        EventType = "Shipping",
                        Processed = false,
                        EventDateTime = Convert.ToDateTime("2018-03-02 00:00:00"),
                        EventData = "S293014|8|.13388-000|L900 NETWORK AS A SERVIC COMCAST 10 YEAR SUB|04346500|0|M|0|20.0000000000|20.0000000000|03-02-2018",
                        InsertedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                        UpdatedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                        OrderNumber = null,
                        LineItemNumber = null,
                        PartNumber = null
                    },
                   new EventDetail
                   {
                       EventType = "Shipping",
                       Processed = false,
                       EventDateTime = Convert.ToDateTime("2018-03-02 00:00:00"),
                       EventData = "S293070|1|.13383-200|L900 PIT MIU ASSY COMP 6' VERSION 2' ANTENNA|08955000|0||1|0.0000000000|100.0000000000|03-29-2018",
                       InsertedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                       UpdatedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                       OrderNumber = null,
                       LineItemNumber = null,
                       PartNumber = null
                   },
                   new EventDetail
                   {
                       EventType = "Shipping",
                       Processed = false,
                       EventDateTime = Convert.ToDateTime("2018-03-02 00:00:00"),
                       EventData = "S293070|2|.13388-100|L900 NETWORK AS A SERVIC SENET 10 YEAR SUB|08955000|0|M|1|0.0000000000|100.0000000000|03-29-2018",
                       InsertedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                       UpdatedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                       OrderNumber = null,
                       LineItemNumber = null,
                       PartNumber = null
                   },
                    new EventDetail
                    {
                        EventType = "Shipping",
                        Processed = true,
                        EventDateTime = Convert.ToDateTime("2018-03-02 00:00:00"),
                        EventData = "R120324A|1|R75G12|REG-PROREAD PIT GAL 6WHL 2 HP TURBINE|03576100|0||0|1.0000000000|1.0000000000|02-26-2018",
                        InsertedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                        UpdatedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                        OrderNumber = null,
                        LineItemNumber = null,
                        PartNumber = null
                    },
                    new EventDetail
                    {
                        EventType = "Shipping",
                        Processed = true,
                        EventDateTime = Convert.ToDateTime("2018-03-02 00:00:00"),
                        EventData = "S293014|5|RYM2G21|REG-ECODER L900i PIT 3/4 GAL|04346500|0||0|20.0000000000|20.0000000000|03-02-2018",
                        InsertedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                        UpdatedDateTime = Convert.ToDateTime("2018-05-15 09:26:00"),
                        OrderNumber = null,
                        LineItemNumber = null,
                        PartNumber = null
                    }
                );

                context.SaveChanges();
            }
        
    }
}