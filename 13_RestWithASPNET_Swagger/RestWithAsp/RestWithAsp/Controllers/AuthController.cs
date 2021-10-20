using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAsp.Data.VO;
using RestWithAsp.Negocios;
using RestWithASP.Data.VO;
using RestWithASP.Hypermedia.Filters;
using System.Collections.Generic;

namespace RestWithAsp.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AuthController : ControllerBase
    {


        private ILoginNegocios _loginNegocios;

        public AuthController(ILoginNegocios loginNegocios)
        {
            _loginNegocios = loginNegocios;
        }



        [HttpPost]
        [ProducesResponseType((200))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Ivalid client request");
            var token = _loginNegocios.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }


        [HttpPost]
        [ProducesResponseType((200))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo is null) return BadRequest("Ivalid client request");
            var token = _loginNegocios.ValidateCredentials(tokenVo);
            if (token == null) return BadRequest("Ivalid client request");
            return Ok(token);
        }


        [HttpGet]
        [ProducesResponseType((200))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = _loginNegocios.RevokeToken(username);

            if (!result) return BadRequest("Ivalid client request");
            return NoContent();
        }
    }
}
