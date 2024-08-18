namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _Productservices;

        public ProductsController(IProductService services)
        {
            _Productservices = services;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var Products = _Productservices.GetAll();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(int id)
        {
            var Product = _Productservices.GetById(id);
            if(Product==null)
                return NotFound("User not found");
            return Ok(Product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody]CreateProductDto productDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _Productservices.Create(productDto);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _Productservices.Update(productDto);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var IsDeleted = _Productservices.Delete(id);
            if(!IsDeleted)
                return NotFound(new { error = "User not found" });
            return Ok();
        }
    }
}
