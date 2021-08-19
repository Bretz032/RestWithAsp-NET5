using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAsp.Model;
using RestWithAsp.Services;



namespace RestWithAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        // Declaracao do serviço usado
        private IPersonService _personService;

        // INjecao de uma instância do Serviço de Iperson
        // Ao criar uma instância do controlador de pessoas
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }


        [HttpGet]
        public IActionResult Get( )
        {

             
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);

            }
        }

        [HttpPost("{id}")]
        public IActionResult Post([FromBody] Person person)
        {
             if (person == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_personService.Create(person));

            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_personService.Update(person));

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
             _personService.Delete(id);
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();

            }
        }

    }
}
