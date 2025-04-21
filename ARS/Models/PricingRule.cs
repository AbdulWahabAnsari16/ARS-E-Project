using System.ComponentModel.DataAnnotations;

namespace ARS.Models
{
    public class PricingRule
    {
        [Key]
        public int RuleID { get; set; }
        public string Class { get; set; }
        public int MinDaysBefore { get; set; }
        public int MaxDaysBefore { get; set; }
        public decimal PriceMultiplier { get; set; }
    }
}
