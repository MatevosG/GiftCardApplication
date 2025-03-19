namespace GiftCardSystem.Application.Dtoes
{
    public class RegisterClientDto : ClientDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
