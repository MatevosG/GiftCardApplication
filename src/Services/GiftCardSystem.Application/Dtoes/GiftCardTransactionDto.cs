namespace GiftCardSystem.Application.Dtoes
{
    public class GiftCardTransactionDto : BaseDto
    {
        public int GiftCardPurchaseId { get; set; }
        public decimal Amount { get; set; }
        public int Type { get; set; }
    }
}
