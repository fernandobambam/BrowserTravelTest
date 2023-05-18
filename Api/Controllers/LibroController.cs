using Api.Responses;
using Application.Common.Interfaces;
using Application.Libros.Commands.AddAutorLibro;
using Application.Libros.Commands.CreateLibro;
using Application.Libros.Commands.DeleteLibro;
using Application.Libros.Commands.RemoveAutorLibro;
using Application.Libros.Commands.UpdateLibro;
using Application.Libros.Queries.Common;
using Application.Libros.Queries.GetAllLibros;
using Application.Libros.Queries.GetLibroById;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService; 

        public LibroController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;   
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDto>>> Get([FromQuery] GetAllLibroQuery query)
        {
            PagedList<LibroDto> librosDto = await _mediator.Send(new GetAllLibroQuery());

            Metadata metadata = new Metadata
            {
                TotalCount = librosDto.TotalCount,
                PageSize = librosDto.PageSize,
                CurrentPage = librosDto.CurrentPage,
                TotalPages = librosDto.TotalPages,
                HasNextPage = librosDto.HasNextPage,
                HasPreviousPage = librosDto.HasPreviousPage,
                NextPageUrl = librosDto.HasNextPage ? _uriService.GetAllEntities(query.PageSize, query.PageNumber + 1, Url.RouteUrl(nameof(Get))).ToString() : string.Empty,
                PreviousPageUrl = librosDto.HasPreviousPage ? _uriService.GetAllEntities(query.PageSize, query.PageNumber - 1, Url.RouteUrl(nameof(Get))).ToString() : string.Empty
            };

            var response = new ApiResponse<PagedList<LibroDto>>(librosDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDto>> GetById(int id)
        {
            LibroDto libroDto = await _mediator.Send(new GetLibroByIdQuery
            {
                Id = id
            });

            return Ok(libroDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateLibroCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("autor")]
        public async Task<ActionResult> AddAutorLibro(AddAutorLibroCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateLibroCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLibroCommand()
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("autor")]
        public async Task<ActionResult> Delete(int autorId, int libroId)
        {
            var command = new RemoveAutorLibroCommand()
            {
                AutorId = autorId,
                LibroId = libroId
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
