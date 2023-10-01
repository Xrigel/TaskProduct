using System.Text.Json;

namespace TaskBook.Models
{
    public class ErrorResponse
    {
        public string? Response { get; set; }
        public int StatusCode { get; set; }
        public string? StackTrace { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
