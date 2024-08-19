namespace Task1.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CreateProductDto Createproduct)
        {
            var product = _mapper.Map<Product>(Createproduct);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public bool Delete(int Id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == Id);
            if(product == null)
                return false;
            _context.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var Products = _context.Products.ToList();

            return _mapper.Map<IEnumerable<ProductDto>>(Products);
        }

        public ProductDto GetById(int id)
        {
            var Product = _context.Products.SingleOrDefault(p => p.Id == id);
            return _mapper.Map<ProductDto>(Product);
        }

        public ProductDto Update(ProductDto productDto)
        {
            if (!_context.Products.Any(x => x.Id == productDto.Id))
                return null!;
            var Product = _mapper.Map<Product>(productDto);
            _context.Update(Product);
            _context.SaveChanges();
            return _mapper.Map<ProductDto>(Product);
        }
    }
}
