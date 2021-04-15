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
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var _appusuario = new appUsuario();
                //Chamando camada de aplicação
                return Ok(await _appusuario.GetAllAsync());
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
        [Route("GetByIdAsync/{id}", Name = "GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var _appusuario = new appUsuario();
                //Chamando camada de aplicação
                return Ok(await _appusuario.GetByIdAsync(id));
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
        [Route("DeleteByIdAsync/{id}", Name = "DeleteByIdAsync")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var _appusuario = new appUsuario();
                //Chamando camada de aplicação
                return Ok(await _appusuario.DeleteAsyncById(id));
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
        [Route("CreateAsync", Name = "CreateAsync")]
        public async Task<IActionResult> CreateAsync(UsuarioView dados)
        {
            try
            {
                var _appusuario = new appUsuario();
                //Chamando camada de aplicação
                return Ok(await _appusuario.CreateAsync(dados));
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
        [Route("EditAsync", Name = "EditAsync")]
        public async Task<IActionResult> EditAsync(UsuarioView dados)
        {
            try
            {
                var _appusuario = new appUsuario();
                //Chamando camada de aplicação
                return Ok(await _appusuario.EditAsync(dados));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            
        }
        
    }
}