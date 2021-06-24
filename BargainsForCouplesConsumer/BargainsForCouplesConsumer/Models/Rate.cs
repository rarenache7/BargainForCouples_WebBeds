using BargainsForCouplesConsumer.Models.Enums;

namespace BargainsForCouplesConsumer.Models
{
    public class Rate
    {
        public RateType RateType { get; set; }
        public BoardType BoardType { get; set; }
        public double Value { get; set; }
    }
}