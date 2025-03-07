using RiskClassification.Application.DTOs;

namespace RiskClassification.Application.Interfaces
{
    public interface ITradeApplicationService
    {
        Task<IEnumerable<string>> ClassifyTradeAsync(List<TradeDto> tradeDtoList, DateTime referenceDate);
    }
}
