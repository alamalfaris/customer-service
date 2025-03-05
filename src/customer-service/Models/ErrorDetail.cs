using System.Text.Json.Serialization;

namespace customer_service.Models
{
    public class ErrorDetail
    {
        [JsonPropertyName("field")]
        [JsonPropertyOrder(1)]
        public string Field { get; set; } = string.Empty;

        [JsonPropertyName("error")]
        [JsonPropertyOrder(2)]
        public string Error { get; set; } = string.Empty;
    }
}
