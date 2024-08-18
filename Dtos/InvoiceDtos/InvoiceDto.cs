namespace Task1.Dtos.InvoiceDtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date Time field is required")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Price field is required")]
        public double Price { get; set; }

        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
