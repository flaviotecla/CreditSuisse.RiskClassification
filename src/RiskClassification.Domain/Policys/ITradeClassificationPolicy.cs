using RiskClassification.Domain.Enums;
using RiskClassification.Domain.Interfaces;

namespace RiskClassification.Domain.Policys
{
    public interface ITradeClassificationPolicy
    {
        bool CanBeClassified(ITrade trade, DateTime referenceDate);

        RiskCategory GetRiskCategory();
    }
}
