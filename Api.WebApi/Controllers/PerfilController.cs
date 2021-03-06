using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application;
using Api.Domain.ViewModels;
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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("PerfilGetAllAsync")]
        public async Task<IActionResult> PerfilGetAllAsync()
        {
            try
            {
                var _app = new appPerfil();
                //Chamando camada de aplicação
                return Ok(await _app.GetAllAsync());
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
        [Route("PerfilGetByIdAsync/{id}", Name = "PerfilGetByIdAsync")]
        public async Task<IActionResult> PerfilGetByIdAsync(int id)
        {
            try
            {
                var _app = new appPerfil();
                //Chamando camada de aplicação
                return Ok(await _app.GetByIdAsync(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("PerfilDeleteByIdAsync/{id}", Name = "PerfilDeleteByIdAsync")]
        public async Task<IActionResult> PerfilDeleteByIdAsync(int id)
        {
            try
            {
                var _app = new appPerfil();
                //Chamando camada de aplicação
                return Ok(await _app.DeleteAsyncById(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        // [Consumes("application/json")]
        [Route("PerfilCreateAsync", Name = "PerfilCreateAsync")]
        public async Task<IActionResult> PerfilCreateAsync(PerfilView dados)
        {
            try
            {
                var _app = new appPerfil();
                //Chamando camada de aplicação
                return Ok(await _app.CreateAsync(dados));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        // [Consumes("application/json")]
        [Route("PerfilEditAsync", Name = "PerfilEditAsync")]
        public async Task<IActionResult> PerfilEditAsync(PerfilView dados)
        {
            try
            {
                var _app = new appPerfil();
                //Chamando camada de aplicação
                return Ok(await _app.EditAsync(dados));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            
        }     
    }
}