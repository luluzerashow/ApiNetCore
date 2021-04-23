using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application;
using Api.Domain.Models;
using Api.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class FaixasController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("FaixasGetAllAsync")]
        public async Task<IActionResult> FaixasGetAllAsync()
        {
            try
            {
                var _app = new appFaixas();
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
        [Route("FaixasGetByIdAsync/{id}", Name = "FaixasGetByIdAsync")]
        public async Task<IActionResult> FaixasGetByIdAsync(int id)
        {
            try
            {
                var _app = new appFaixas();
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
        [Route("FaixasDeleteByIdAsync/{id}", Name = "FaixasDeleteByIdAsync")]
        public async Task<IActionResult> FaixasDeleteByIdAsync(int id)
        {
            try
            {
                var _app = new appFaixas();
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
        [Route("FaixasCreateAsync", Name = "FaixasCreateAsync")]
        public async Task<IActionResult> FaixasCreateAsync(Faixas dados)
        {
            try
            {
                var _app = new appFaixas();
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
        [Route("FaixasEditAsync", Name = "FaixasEditAsync")]
        public async Task<IActionResult> FaixasEditAsync(Faixas dados)
        {
            try
            {
                var _app = new appFaixas();
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