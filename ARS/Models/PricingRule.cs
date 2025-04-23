using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class PricingRule
    {
        [Key]
        public int RuleID { get; set; }
        public int ClassID { get; set; }
        [ForeignKey("ClassID")]
        public Class Class { get; set; }
        public int MinDaysBefore { get; set; }
        public int MaxDaysBefore { get; set; }
        public decimal PriceMultiplier { get; set; }
    }
}
