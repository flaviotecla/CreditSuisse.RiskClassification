namespace RiskClassification.Application.DTOs
{
    public class TradeDto
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public bool IsPoliticallyExposed { get; set; }
    }
}
