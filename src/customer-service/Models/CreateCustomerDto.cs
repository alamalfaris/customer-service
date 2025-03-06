using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace customer_service.Models
{
    public class CreateCustomerDto
    {
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("dateOfBirth")]
        [Required(ErrorMessage = "Date of Birth is required.")]
        [CustomValidation(typeof(ModelValidator), nameof(ModelValidator.ValidateDateOfBirth))]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("placeOfBirth")]
        [Required(ErrorMessage = "Place of Birth is required.")]
        [StringLength(20, ErrorMessage = "Place of Birth cannot exceed 20 characters.")]
        public string PlaceOfBirth { get; set; } = string.Empty;
    }
}
