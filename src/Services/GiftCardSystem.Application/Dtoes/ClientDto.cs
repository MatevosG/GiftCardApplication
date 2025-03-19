namespace GiftCardSystem.Application.Dtoes
{
    public class ClientDto : BaseDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<GiftCardPurchaseDto>?  GiftCardPurchases { get; set; }
        public List<AddressDto>? Addresses { get; set; }
    }
}
