using RiskClassification.Domain.Enums;
using RiskClassification.Domain.Interfaces;

namespace RiskClassification.Domain.Policys
{
    public class PepClassificationPolicy : ITradeClassificationPolicy
    {
        public bool CanBeClassified(ITrade trade, DateTime referenceDate)
        {
            return trade.IsPoliticallyExposed;
        }

        public RiskCategory GetRiskCategory()
        {
            return RiskCategory.PoliticallyExposedPerson;
        }
    }
}
