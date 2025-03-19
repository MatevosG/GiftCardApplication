namespace GiftCardSystem.Application.Models
{
    public class ResponseModel<T>  
    {
        public IEnumerable<T> Entities { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
    public class ResponseModel
    {
        public ResponseModel()
        {
            
        }
        public ResponseModel(object response)
        {
            Response = response;
        }
        public object Response { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Error { get; set; }
    }
}
