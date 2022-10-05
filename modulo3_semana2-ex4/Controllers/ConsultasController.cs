using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace modulo3_semana2_ex4.Controllers
{
    [ApiController]
    [Route("consultas")]
    [Authorize]
    public class ConsultasController : ControllerBase
    {

        [HttpGet("publicas")]
        [AllowAnonymous]
        public IActionResult GetSemAutorizacao()
            => Ok(new
            {
                resultado = "Welcome stranger!"
            });


        [HttpGet("privadas")]
        [Authorize]
        public IActionResult GetComAutorizacao()
            => Ok(new
            {
                resultado = "Dados que apenas usuários logados podem ver",
                usuarioLogado = User.FindFirstValue(ClaimTypes.Name)
            });
        
    }
}
