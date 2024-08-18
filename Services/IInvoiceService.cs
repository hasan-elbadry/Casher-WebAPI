namespace Task1.Services
{
    public interface IInvoiceService
    {
        bool Create(CreateInvoiceDto invoiceDto);
        IEnumerable<InvoiceDto> GetAll();
        InvoiceDto GetById(int id);
        InvoiceDto Update(UpdateInvoiceDto invoiceDto);
        bool Delete(int Id);
    }
}
