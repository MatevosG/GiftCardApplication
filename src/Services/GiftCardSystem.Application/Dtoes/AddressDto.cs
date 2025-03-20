using System.Text.Json.Serialization;

namespace GiftCardSystem.Application.Dtoes
{
    public class AddressDto : BaseDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string? PostalCode { get; set; }
        public string Street { get; set; }
        public int ClientId { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
