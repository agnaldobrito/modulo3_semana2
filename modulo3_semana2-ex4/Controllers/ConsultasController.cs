using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace modulo3_semana2_ex4.Controllers
{
    [ApiController]
    [Route("consultas")]
    [Authorize]
    public class ConsultasController : ControllerBase
    {
        private string resultado;
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetSemAutorizacao()
        {
            resultado = "Hello stranger!";
            return Ok(resultado);
        }

        [HttpGet("/privadas")]
        [Authorize]
        public IActionResult GetComAutorizacao()
        {
            resultado = "You shall not pass! (If you are a balrog or unauthorized user)";
            return Unauthorized(resultado);
        }
    }
}
