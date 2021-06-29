using System.Collections.Generic;
using System.Threading.Tasks;
using BargainsForCouplesConsumer.Models;

namespace BargainsForCouplesConsumer.Interfaces
{
    public interface IConsumerService
    {
        Task<List<BargainOffer>> GetBargains(int destinationId, int numberOfNights);
    }
}