namespace Task1.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price field is required")]
        public double Price { get; set; }
    }
}
