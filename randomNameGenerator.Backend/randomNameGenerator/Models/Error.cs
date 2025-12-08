namespace randomNameGenerator.Models
{
    public class Error
    {
        public string Message { get; set; } = string.Empty;

        public Error(string message)
        {
            Message = message;
        }
    }
}
