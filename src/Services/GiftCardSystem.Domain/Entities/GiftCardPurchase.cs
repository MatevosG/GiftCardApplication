using GiftCardSystem.Domain.Entities.Base;

namespace GiftCardSystem.Domain.Entities
{
    public class GiftCardPurchase : EntityBase
    {
        public decimal Balance { get; set; }
        public bool IsRedeemed { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int GiftCardId { get; set; }
        public virtual GiftCard GiftCard { get; set; }
        public virtual ICollection<GiftCardTransaction> GiftCardTransactions { get; set; }
    }
}
