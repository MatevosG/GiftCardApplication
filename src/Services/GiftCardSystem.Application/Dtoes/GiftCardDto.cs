namespace GiftCardSystem.Application.Dtoes
{
    public class GiftCardDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public int ExpirationMonthPeriod { get; set; }
    }
}
