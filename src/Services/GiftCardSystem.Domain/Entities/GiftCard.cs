using GiftCardSystem.Domain.Entities.Base;

namespace GiftCardSystem.Domain.Entities
{
    public class GiftCard : EntityBase
    {
        public int Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public int ExpirationMonthPeriod { get; set; }
        public virtual ICollection<GiftCardPurchase> GiftCardPurchases { get; set; }
    }
}
