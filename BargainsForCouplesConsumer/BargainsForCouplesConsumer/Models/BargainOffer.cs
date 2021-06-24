using System.Collections.Generic;

namespace BargainsForCouplesConsumer.Models
{
    public class BargainOffer
    {
        public Hotel Hotel { get; set; } = new Hotel();
        public List<Rate> Rates { get; set; } = new List<Rate>();
    }
}