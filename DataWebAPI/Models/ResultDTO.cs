namespace DataWebAPI.Models
{
    public class ResultDTO<T>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
