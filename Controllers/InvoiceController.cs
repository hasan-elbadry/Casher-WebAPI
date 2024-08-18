namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Invoices = _invoiceService.GetAll();
            if (Invoices == null)
                return NotFound();

            return Ok(Invoices);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Invoice = _invoiceService.GetById(id);
            if (Invoice == null)
                return NotFound();

            return Ok(Invoice);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateInvoiceDto invoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var IsCreated = _invoiceService.Create(invoiceDto);
            if (!IsCreated)
                return BadRequest("there is no products to add");

            return Ok();
        }

        [HttpPatch]
        public IActionResult Update([FromBody] UpdateInvoiceDto invoiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Invoice = _invoiceService.Update(invoiceDto);
            return Ok(Invoice);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _invoiceService.Delete(id);
            if(!isDeleted) return NotFound();
            return Ok();
        }
    }
}
