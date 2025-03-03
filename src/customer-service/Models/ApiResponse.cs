using System.Text.Json.Serialization;

namespace customer_service.Models
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }

        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RequestId { get; set; }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { Data = data };
        }

        public static ApiResponse<T> Failure(string message, string? requestId = null)
        {
            return new ApiResponse<T> { Message = message, RequestId = requestId };
        }
    }
}
