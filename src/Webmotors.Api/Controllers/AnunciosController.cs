using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Anuncios.Query;
namespace Webmotors.Repository.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return await GetResponseAsync<IList<ObterAnuncioViewModel>>(AnunciosViewModel);
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
            return await GetResponseAsync<ObterAnuncioViewModel>(AnunciosViewModel);
        }
      



    }
}