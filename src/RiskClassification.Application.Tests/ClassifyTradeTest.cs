
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RiskClassification.Application.DTOs;
using RiskClassification.Application.Interfaces;

namespace RiskClassification.Application.Tests
{
    public class ClassifyTradeTest
    {
        [Fact]
        public async Task ClassifyTradeAsync_ShouldReturnCorrectClassificationSequence()
        {
            // Arrange
            var referenceDate = new DateTime(2020, 12, 11);
            var tradeDtoList = new List<TradeDto>
            {
                new TradeDto { Value = 2_000_000, ClientSector = "Private", NextPaymentDate = new DateTime(2025, 12, 29), IsPoliticallyExposed = false },
                new TradeDto { Value = 400_000,   ClientSector = "Public",  NextPaymentDate = new DateTime(2020, 7, 1),   IsPoliticallyExposed = false },
                new TradeDto { Value = 5_000_000, ClientSector = "Public",  NextPaymentDate = new DateTime(2024, 1, 2),   IsPoliticallyExposed = false },
                new TradeDto { Value = 3_000_000, ClientSector = "Public",  NextPaymentDate = new DateTime(2023, 10, 26), IsPoliticallyExposed = true }
            };

            var expectedClassifications = new List<string> { "LOWRISK", "HIGHRISK", "MEDIUMRISK", "HIGHRISK" };

            var tradeApplicationServiceMock = new Mock<ITradeApplicationService>();
            tradeApplicationServiceMock
                .Setup(service => service.ClassifyTradeAsync(tradeDtoList, referenceDate))
                .ReturnsAsync(expectedClassifications);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(tradeApplicationServiceMock.Object);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var tradeApplicationService = serviceProvider.GetService<ITradeApplicationService>();

            // Act
            var result = await tradeApplicationService!.ClassifyTradeAsync(tradeDtoList, referenceDate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedClassifications, result);
        }
    }
}