using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class FlightRoutes
    {
        [Key]
        public int RouteID { get; set; }

        public int OriginAirportID { get; set; }
        [ForeignKey("OriginAirportID")]
        public Airport OriginAirport { get; set; }  // Renamed from 'Airport'

        public int DestinationAirportID { get; set; }
        [ForeignKey("DestinationAirportID")]
        public Airport DestinationAirport { get; set; }  // Renamed from 'Airports'

        public double Distance { get; set; }
    }
}
