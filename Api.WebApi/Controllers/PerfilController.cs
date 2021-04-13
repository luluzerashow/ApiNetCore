using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class PerfilController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("GetPerfisCombo")]
        public async Task<IActionResult> GetPerfisCombo()
        {
            try
            {
                var _appulogin = new appLogin();
                //Chamando camada de aplicação
                return Ok(await _appulogin.GetPerfisCombo());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }     
    }
}