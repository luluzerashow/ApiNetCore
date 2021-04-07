using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("GetUserLogin/{user}", Name = "GetUserLogin")]
        public async Task<IActionResult> GetUserLogin(string user)
        {
            try
            {
                var appLogin = new appLogin();
                //Chamando camada de aplicação
                return Ok(await appLogin.GetUserLogin(user));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("GetUserCookie/{user}", Name = "GetUserCookie")]
        public async Task<IActionResult> GetUserCookie(string user)
        {
            try
            {
                var appLogin = new appLogin();
                //Chamando camada de aplicação
                return Ok(await appLogin.GetUserCookie(user));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}