using Microsoft.AspNetCore.Mvc;

namespace Generic_MOngo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Person person)
        {
            await _personRepository.InsertOneAsync(person);
            return Ok(person);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var product = await _personRepository.GetAllAsync();
            return Ok(product);
        }
        [HttpGet("{Name}")]
        public async Task<IActionResult> GetProductById(string Name)
        {
            var product = await _personRepository.GetByIdAsync(Name);
            return Ok(product);
        }

        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeleteProduct(string Name)
        {
            await _personRepository.DeleteOneAsync(Name);
            return Ok();
        }


    }
}
