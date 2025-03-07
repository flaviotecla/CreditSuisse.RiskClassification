using RiskClassification.Domain.Constants;
using RiskClassification.Domain.Enums;
using RiskClassification.Domain.Interfaces;

namespace RiskClassification.Domain.Policys
{
    public class HighRiskTradeClassificationPolicy : ITradeClassificationPolicy
    {
        private const double _referenceValue = 1_000_000;

        public bool CanBeClassified(ITrade trade, DateTime referenceDate)
        {
            if (trade == null)
                throw new ArgumentNullException(nameof(trade), "Trade cannot be null");

            if (!TradeConstants.AllowedSectors.Contains(trade.ClientSector))
                throw new ArgumentNullException($"Invalid sector: {trade.ClientSector}");

            return trade.Value > _referenceValue && trade.ClientSector == "Private";
        }

        public RiskCategory GetRiskCategory()
        {
            return RiskCategory.HighRisk;
        }
    }
}
