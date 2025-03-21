using GiftCardSystem.Domain.Entities.Base;

namespace GiftCardSystem.Domain.Entities
{
    public class Address : EntityBase
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public bool IsDeleted { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<GiftCardPurchase> GiftCardPurchases { get; set; }
    }
}
