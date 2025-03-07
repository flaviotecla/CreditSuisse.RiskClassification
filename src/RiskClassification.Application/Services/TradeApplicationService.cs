using RiskClassification.Application.DTOs;
using RiskClassification.Application.Interfaces;
using RiskClassification.Domain.Entities;
using RiskClassification.Domain.Interfaces;
using RiskClassification.Domain.Services;

namespace RiskClassification.Application.Services
{
    public class TradeApplicationService : ITradeApplicationService
    {
        private readonly TradeRiskClassificationService _domainService;

        public TradeApplicationService(
            TradeRiskClassificationService domainService
            )
        {
            _domainService = domainService;
        }

        public async Task<IEnumerable<string>> ClassifyTradeAsync(List<TradeDto> tradeDtoList, DateTime referenceDate)
        {
            var trades = this.ConvertDtoToTrade(tradeDtoList);
            return await _domainService.ClassifyTrades(trades, referenceDate);
        }

        private IEnumerable<ITrade> ConvertDtoToTrade(IEnumerable<TradeDto> tradeDtos)
        {
            if (tradeDtos == null || !tradeDtos.Any())
                return Enumerable.Empty<ITrade>();

            var trades = tradeDtos.Select(dto => new Trade
            {
                Value = dto.Value,
                ClientSector = dto.ClientSector,
                NextPaymentDate = dto.NextPaymentDate,
                IsPoliticallyExposed = dto.IsPoliticallyExposed
            });

            return trades;
        }

    }
}
