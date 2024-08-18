namespace Task1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price field is required")]
        public double Price { get; set; }

        public int? InvoiceId { get; set; }

        public Invoice? InVoice { get; set; }
    }
}
