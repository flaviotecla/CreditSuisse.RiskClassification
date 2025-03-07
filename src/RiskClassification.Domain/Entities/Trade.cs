using RiskClassification.Domain.Interfaces;

namespace RiskClassification.Domain.Entities
{
    public class Trade : ITrade
    {
        public double Value { get; set; }

        public required string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public bool IsPoliticallyExposed { get; set; }
    }
}
