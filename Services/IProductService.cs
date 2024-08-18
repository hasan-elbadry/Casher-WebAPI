namespace Task1.Services
{
    public interface IProductService
    {
        void Create(CreateProductDto product);
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
        ProductDto Update(ProductDto product);
        bool Delete(int Id);
    }
}
