using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAsp.Negocios;
using RestWithASP.Data.VO;
using RestWithASP.Hypermedia.Filters;
using System.Collections.Generic;

namespace RestWithAsp.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        // Declaracao do serviço usado
        private IPersonNegocios _personService;

        // INjecao de uma instância do Serviço de Iperson
        // Ao criar uma instância do controlador de pessoas
        public PersonController(ILogger<PersonController> logger, IPersonNegocios personService)
        {
            _logger = logger;
            _personService = personService;
        }


        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {


            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]

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

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}
