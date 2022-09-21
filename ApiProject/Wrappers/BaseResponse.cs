namespace ApiProject.Wrappers
{
    public class BaseResponse
    {
        public Guid ResponseId { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string[] Errors { get; set; }
    }
}
