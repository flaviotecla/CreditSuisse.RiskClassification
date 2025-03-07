using RiskClassification.Domain.Interfaces;

namespace RiskClassification.Domain.Services
{
    public interface ITradeRiskClassificationService
    {
        string ClassifyTrade(ITrade trade, DateTime referenceDate);
        Task<IEnumerable<string>> ClassifyTrades(IEnumerable<ITrade> trades, DateTime referenceDate);
    }
}
