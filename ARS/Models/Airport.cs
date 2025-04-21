using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class Airport
    {
        [Key]
        public int AirportId { get; set; }
        public string Name { get; set; }
        public string IATACode { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        // Collections for routes where this airport is the origin or destination
        public ICollection<FlightRoutes> OriginRoutes { get; set; }
        public ICollection<FlightRoutes> DestinationRoutes { get; set; }
        //[NotMapped]
        //public ICollection<FlightSchedule> FlightSchedules { get; set; }
    }
}
