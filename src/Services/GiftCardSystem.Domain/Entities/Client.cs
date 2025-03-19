using GiftCardSystem.Domain.Entities.Base;

namespace GiftCardSystem.Domain.Entities
{
    public class Client : EntityBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<GiftCardPurchase> GiftCardPurchases { get; set; }
    }
}
