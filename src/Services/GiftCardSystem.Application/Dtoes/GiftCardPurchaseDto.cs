namespace GiftCardSystem.Application.Dtoes
{
    public class GiftCardPurchaseDto : BaseDto
    {
        public decimal? Balance { get; set; }
        public bool? IsRedeemed { get; set; }
        public int ClientId { get; set; }
        public int GiftCardId { get; set; }
        public string? GiftCardName { get; set; }
        public string? ClientEmail { get; set; }
        public int AddressId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public AddressDto? Address { get; set; }
        public List<GiftCardTransactionDto>? GiftCardTransactions { get; set; }
    }
}
