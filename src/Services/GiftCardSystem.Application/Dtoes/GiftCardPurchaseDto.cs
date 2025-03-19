namespace GiftCardSystem.Application.Dtoes
{
    public class GiftCardPurchaseDto : BaseDto
    {
        public decimal Balance { get; set; }
        public bool IsRedeemed { get; set; }
        public int ClientId { get; set; }
        public int GiftCardId { get; set; }
        public List<GiftCardTransactionDto> GiftCardTransactions { get; set; }
    }
}
