using Microsoft.Extensions.DependencyInjection;
using RiskClassification.Application.DTOs;
using RiskClassification.Application.Interfaces;
using RiskClassification.Application.Services;
using RiskClassification.Domain.Enums;
using RiskClassification.Domain.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            #region Dependency injection
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<TradeRiskClassificationService>();
            serviceCollection.AddSingleton<ITradeApplicationService, TradeApplicationService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            #endregion

            DateTime referenceDate = new DateTime(2020, 12, 11);

            var tradeDtoList = new List<TradeDto>
            {
                new TradeDto
                {
                    Value = 2_000_000,
                    ClientSector = ClientSector.Private.ToString(),
                    NextPaymentDate = new DateTime(2025, 12, 29),
                    IsPoliticallyExposed = false
                },
                new TradeDto
                {
                    Value = 400_000,
                    ClientSector = ClientSector.Public.ToString(),
                    NextPaymentDate = new DateTime(2020, 7, 1),
                    IsPoliticallyExposed = false
                },
                new TradeDto
                {
                    Value = 5_000_000,
                    ClientSector = ClientSector.Public.ToString(),
                    NextPaymentDate = new DateTime(2024, 1, 2),
                    IsPoliticallyExposed = false
                },
                new TradeDto
                {
                    Value = 3_000_000,
                    ClientSector = ClientSector.Public.ToString(),
                    NextPaymentDate = new DateTime(2023, 10, 26),
                    IsPoliticallyExposed = true
                }
            };

            var tradeApplicationService = serviceProvider.GetService<ITradeApplicationService>();
            var result = await tradeApplicationService!.ClassifyTradeAsync(tradeDtoList, referenceDate);

            foreach (var item in result)
            {
                Console.WriteLine(item.ToUpper());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}