using GiftCardSystem.Domain.Entities.Base;

namespace GiftCardSystem.Domain.Entities
{
    public class GiftCardTransaction : EntityBase
    {
        public int GiftCardPurchaseId { get; set; }
        public virtual GiftCardPurchase GiftCardPurchase { get; set; }
        public decimal Amount { get; set; }
        public int Type { get; set; }
    }
}
