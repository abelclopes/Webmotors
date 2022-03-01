using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Anuncios.Command.AtualizarAnuncio;
using Webmotors.Application.Anuncios.Command.Cadastrar;
using Webmotors.Application.Anuncios.Command.DeletarAnuncio;
using Webmotors.Application.Anuncios.Query;
namespace Webmotors.Repository.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AnunciosController : BaseController
    {
        private readonly IMediator _mediator;

        private readonly ILogger<AnunciosController> _logger;

        public AnunciosController(ILogger<AnunciosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var query = new ObterTodosAnunciosQuery();
            var AnunciosViewModel = _mediator.Send(query);
            return GetResponse<IList<ObterAnuncioViewModel>>(AnunciosViewModel);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new ObterAnuncioQuery() { Id = id };
            var AnunciosViewModel = _mediator.Send(query);
            return GetResponse<ObterAnuncioViewModel>(AnunciosViewModel);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CadastrarAnuncio([FromBody] CadastraAnuncioCommand anuncio)
        {
            var newStatus = _mediator.Send(anuncio);
            return GetResponse<string>(newStatus);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AlterarAnuncio([FromBody] AtualizarAnuncioCommand anuncio)
        {
            var updateStatus = _mediator.Send(anuncio);
            return GetResponse<string>(updateStatus);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeletarAnuncio(int id)
        {
            var command =  new DeletarAnuncioCommand();
            command.Id = id;
            var deleteStatus = _mediator.Send(command);
            return GetResponse<string>(deleteStatus);
        }




    }
}