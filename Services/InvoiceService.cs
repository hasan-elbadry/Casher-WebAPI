namespace Task1.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Create(CreateInvoiceDto invoiceDto)
        {
            var products = _context.Products
                .Where(p => invoiceDto.ProductsId.Contains(p.Id))
                .ToList();

            if (!products.Any())
            {
                return false;
            }

            var Invoice = _mapper.Map<Invoice>(invoiceDto);
            Invoice.Products = products;
            Invoice.Price = products.Sum(x=>x.Price);
            _context.Add(Invoice);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<InvoiceDto> GetAll()
        {
            var Invoices = _context.Invoices
                .Include(x=>x.Products)
                .ToList();
            var invoicesDto = _mapper.Map<List<InvoiceDto>>(Invoices);

            return invoicesDto;
        }

        public InvoiceDto GetById(int id)
        {
            var Invoice = _context.Invoices
                .Include(x=>x.Products)
                .SingleOrDefault(x=>x.Id == id);

            return _mapper.Map<InvoiceDto>(Invoice);
        }

        public InvoiceDto Update(UpdateInvoiceDto invoiceDto)
        {
            var Invoice = _mapper.Map<Invoice>(invoiceDto);
            if(invoiceDto.DateTime == null)
                _context
                    .Entry(Invoice)
                    .Property(x=>x.DateTime)
                    .IsModified = false;
            if (invoiceDto.Price == 0)
                _context
                    .Entry(Invoice)
                    .Property(x => x.Price)
                    .IsModified = false;
            if (invoiceDto.Products == null)
                _context
                    .Entry(Invoice)
                    .Property(x => x.Products)
                    .IsModified = false;
            else
            {
                var Products = _context.Products
                    .Where(p => invoiceDto.Products.Contains(p.Id))
                    .ToList();
                Invoice.Price = Products.Sum(p => p.Price);
                Invoice.Products = Products;
            }

            _context.Invoices.Update(Invoice);
            _context.SaveChanges();

            var newInvoice = _context.Invoices.Find(Invoice.Id);
            return _mapper.Map<InvoiceDto>(newInvoice);
        }

        public bool Delete(int Id)
        {
            var Invoice = _context.Invoices.SingleOrDefault(i => i.Id == Id);
            if (Invoice == null) return false;
            _context.Remove(Invoice);
            _context.SaveChanges();
            return true;
        }
    }
}
