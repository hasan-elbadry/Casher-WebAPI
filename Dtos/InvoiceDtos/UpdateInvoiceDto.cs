namespace Task1.Dtos.InvoiceDtos
{
    public class UpdateInvoiceDto
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Price { get; set; }

        public List<int>? Products { get; set; }
    }
}
