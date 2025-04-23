using System.ComponentModel.DataAnnotations;

namespace ARS.Models
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int Description { get; set; }
        public ICollection<FlightSchedule> Flights { get; set; }
        public ICollection<PricingRule> Rules { get; set; }
    }
}
