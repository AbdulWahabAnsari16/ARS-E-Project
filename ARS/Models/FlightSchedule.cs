using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class FlightSchedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public int FlightID { get; set; }

        [ForeignKey("FlightID")]
        public Flight Flight { get; set; }

        //public int DepartureAirportID { get; set; }
        //[ForeignKey("DepartureAirportID")]
        //public Airport Airport { get; set; }

        public int ArrivalAirportID { get; set; }
        [ForeignKey("ArrivalAirportID")]
        public Airport Airpor { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public string Class { get; set; }

        public int SeatsAvailable { get; set; }

        public List<ItinerarySegment> Segments { get; set; } = new();
    }

}

