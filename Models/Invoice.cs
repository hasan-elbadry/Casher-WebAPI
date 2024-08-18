namespace Task1.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date Time field is required")]
        public DateTime DateTime { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Price field is required")]
        public double Price { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}