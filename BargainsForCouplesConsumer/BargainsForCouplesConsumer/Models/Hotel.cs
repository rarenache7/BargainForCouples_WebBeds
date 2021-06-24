namespace BargainsForCouplesConsumer.Models
{
    public class Hotel
    {
        public int PropertyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int GeoId { get; set; }
        public int Rating { get; set; }
    }
}