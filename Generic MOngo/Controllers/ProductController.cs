using Microsoft.AspNetCore.Mvc;

namespace Generic_MOngo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {

        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _productRepository.InsertOneAsync(product);
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var product = await _productRepository.GetAllAsync();
            return Ok(product);
        }
        [HttpGet("{Name}")]
        public async Task<IActionResult> GetProductById(string Name)
        {
            var product = await _productRepository.GetByIdAsync(Name);
            return Ok(product);
        }
      
        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteProduct(string Name)
        {
            await _productRepository.DeleteOneAsync(Name);
            return Ok();
        }


    }
}
