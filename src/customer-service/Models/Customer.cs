namespace customer_service.Models
{
    public class Customer
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; } = string.Empty;
        public bool DeleteFlag { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
