using RiskClassification.Domain.Interfaces;
using RiskClassification.Domain.Policys;

namespace RiskClassification.Domain.Services
{
    public class TradeRiskClassificationService : ITradeRiskClassificationService
    {
        private readonly List<ITradeClassificationPolicy> _classificationPolicies;

        public TradeRiskClassificationService()
        {
            _classificationPolicies = new List<ITradeClassificationPolicy>
            {
                //new PepClassificationPolicy(),
                new ExpiredTradeClassificationPolicy(),
                new HighRiskTradeClassificationPolicy(),
                new MediumRiskTradeClassificationPolicy()
            };
        }

        public string ClassifyTrade(ITrade trade, DateTime referenceDate)
        {
            ITradeClassificationPolicy matchingPolicy = null;

            foreach (var policy in _classificationPolicies)
            {
                bool canBeClassified = policy.CanBeClassified(trade, referenceDate);

                if (canBeClassified)
                {
                    matchingPolicy = policy;
                    break;
                }
            }

            return matchingPolicy?.GetRiskCategory().ToString() ?? "Unknown";
        }

        public async Task<IEnumerable<string>> ClassifyTrades(IEnumerable<ITrade> trades, DateTime referenceDate)
        {
            if (trades == null || !trades.Any())
                return Enumerable.Empty<string>();

            var results = trades.Select(trade => this.ClassifyTrade(trade, referenceDate));
            return await Task.FromResult(results);
        }
    }
}
