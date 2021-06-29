using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using BargainsForCouplesConsumer.Interfaces;
using BargainsForCouplesConsumer.Models;
using BargainsForCouplesConsumer.Models.Enums;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BargainsForCouplesConsumer.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IConfiguration _configuration;

        public ConsumerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<BargainOffer>> GetBargains(int destinationId, int numberOfNights)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(await GetUrlForApiCall(destinationId, numberOfNights));

            var apiResponse = await response.Content.ReadAsStringAsync();
            var bargains = JsonConvert.DeserializeObject<List<BargainOffer>>(apiResponse);

            if (bargains == null) return null;
            foreach (var rate in bargains
                .Where(bargain => bargain.Rates.Any(rate => rate.RateType == ERateType.PerNight))
                .SelectMany(bargain => bargain.Rates))
            {
                rate.Value = CalculateFinalPrice(rate.Value, numberOfNights);
            }
            return bargains;
        }

        private async Task<string> GetUrlForApiCall(int destinationId, int numberOfNights)
        {
            var uriBuilder = new UriBuilder(_configuration.GetValue<string>("ApiUrl"))
            {
                Port = -1,
                Query = await new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    {"destinationId", destinationId.ToString()},
                    {"nights", numberOfNights.ToString()},
                    {"code", _configuration.GetValue<string>("ApiKey")}
                }).ReadAsStringAsync()
            };

            return uriBuilder.ToString();
        }
        private static double CalculateFinalPrice(double pricePerNight, int numberOfNights)
        {
            return pricePerNight * numberOfNights;
        }
    }
}