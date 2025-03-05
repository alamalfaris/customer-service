using System.Text.Json.Serialization;

namespace customer_service.Models
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("statusCode")]
        [JsonPropertyOrder(1)]
        public int StatusCode { get; set; }

        [JsonPropertyName("message")]
        [JsonPropertyOrder(2)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }

        [JsonPropertyName("traceIdentifier")]
        [JsonPropertyOrder(3)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TraceIdentifier { get; set; }

        [JsonPropertyName("page")]
        [JsonPropertyOrder(4)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Page { get; set; }

        [JsonPropertyName("pageSize")]
        [JsonPropertyOrder(4)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PageSize { get; set; }

        [JsonPropertyName("data")]
        [JsonPropertyOrder(4)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        public static ApiResponse<T> Success(T data, int statusCode)
        {
            return new ApiResponse<T> { Data = data, StatusCode = statusCode };
        }

        public static ApiResponse<T> SuccessPaging(T data, int statusCode, int page, int pageSize)
        {
            return new ApiResponse<T> { Data = data, StatusCode = statusCode, Page = page, PageSize = pageSize };
        }

        public static ApiResponse<T> Failure(string message, int statusCode, string? traceIdentifier = null)
        {
            return new ApiResponse<T> { Message = message, StatusCode = statusCode, TraceIdentifier = traceIdentifier };
        }
    }
}
