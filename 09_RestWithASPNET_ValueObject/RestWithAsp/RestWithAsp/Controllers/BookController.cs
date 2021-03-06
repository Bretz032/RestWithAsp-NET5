using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAsp.Model;
using RestWithAsp.Negocios;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithAsp.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;

        // Declaracao do serviço usado
        private IBookNegocios _bookService;

        // INjecao de uma instância do Serviço de Iperson
        // Ao criar uma instância do controlador de pessoas
        public BookController(ILogger<BookController> logger, IBookNegocios bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }


        [HttpGet]
        public IActionResult Get()
        {


            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookService.FindByID(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookService.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookService.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookService.Delete(id);
            return NoContent();
        }

    }
}
