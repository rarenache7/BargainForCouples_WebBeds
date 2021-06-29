using System.Collections.Generic;
using System.Threading.Tasks;
using BargainsForCouplesConsumer.Interfaces;
using BargainsForCouplesConsumer.Services;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace BargainsForCouplesConsumer.Tests
{
    public class ConsumerServiceTests
    {
        private IConsumerService _service;
        [SetUp]
        public void Setup()
        {
            var jsonData = new Dictionary<string, string>()
            {
                {"ApiKey", "aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw=="},
                {"ApiUrl", "https://webbedsdevtest.azurewebsites.net/api/"},
                {"ApiMethod", "findBargain/"}
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(jsonData).Build();
            _service = new ConsumerService(configuration);
        }

        [Test]
        public async Task Given_DestinationIdAndNumberOfNights_When_CallingGetBargains_Then_DesiredResultsAreOffered()
        {
            var result = await _service.GetBargains(279, 3);
            Assert.NotNull(result);
        }
    }
}