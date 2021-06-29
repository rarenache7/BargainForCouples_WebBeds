using BargainsForCouplesConsumer.Models.Enums;

namespace BargainsForCouplesConsumer.Models
{
    public class Rate
    {
        public ERateType RateType { get; set; }
        public EBoardType BoardType { get; set; }
        public double Value { get; set; }
    }
}