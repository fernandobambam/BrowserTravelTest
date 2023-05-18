using Application.Autores.Commands.CreateAutor;
using Application.Autores.Commands.DeleteAutor;
using Application.Autores.Commands.UpdateAutor;
using Application.Autores.Queries.Common;
using Application.Autores.Queries.GetAllAutores;
using Application.Autores.Queries.GetAutorById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllAutoresQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetById(int id)
        {
            AutorDto editorialDto = await _mediator.Send(new GetAutorByIdQuery
            {
                Id = id
            });

            return Ok(editorialDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateAutorCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateAutorCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteAutorCommand()
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
