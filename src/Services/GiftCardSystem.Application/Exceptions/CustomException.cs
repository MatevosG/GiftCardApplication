namespace GiftCardSystem.Application.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
            
        }
       
        public CustomException(string name, object key) : base($"{name} ({key}) was not found")
        {

        }
    }
}
