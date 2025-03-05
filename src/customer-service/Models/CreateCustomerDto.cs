using System.Text.Json.Serialization;

namespace customer_service.Models
{
    public class CreateCustomerDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("placeOfBirth")]
        public string PlaceOfBirth { get; set; } = string.Empty;
    }
}
