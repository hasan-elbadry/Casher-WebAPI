namespace Task1.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price field is required")]
        public double Price { get; set; }
    }
}
