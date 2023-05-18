using Application.Editoriales.Commands.CreateEditorial;
using Application.Editoriales.Commands.DeleteEditorial;
using Application.Editoriales.Commands.UpdateEditorial;
using Application.Editoriales.Queries.Common;
using Application.Editoriales.Queries.GetAllEditoriales;
using Application.Editoriales.Queries.GetEdtiroialById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IMediator _mediator; 

        public EditorialController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditorialDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllEditorialesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EditorialDto>> GetById(int id)
        {
            EditorialDto editorialDto = await _mediator.Send(new GetEditorialByIdQuery
            {
                Id = id
            });

            return Ok(editorialDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateEditorialCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateEditorialCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEditorialCommand()
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
