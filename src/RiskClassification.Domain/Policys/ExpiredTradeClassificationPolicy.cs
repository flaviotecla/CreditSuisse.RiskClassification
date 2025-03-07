using RiskClassification.Domain.Enums;
using RiskClassification.Domain.Interfaces;

namespace RiskClassification.Domain.Policys
{
    public class ExpiredTradeClassificationPolicy : ITradeClassificationPolicy
    {
        public bool CanBeClassified(ITrade trade, DateTime referenceDate)
        {
            if (trade == null)
                throw new ArgumentNullException(nameof(trade), "Trade cannot be null");

            var baseDate = referenceDate.AddDays(-30);
            return trade.NextPaymentDate < baseDate;
        }

        public RiskCategory GetRiskCategory()
        {
            return RiskCategory.Expired;
        }
    }
}
