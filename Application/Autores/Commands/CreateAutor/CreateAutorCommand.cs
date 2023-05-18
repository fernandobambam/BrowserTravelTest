using MediatR;

namespace Application.Autores.Commands.CreateAutor
{
    public class CreateAutorCommand : IRequest<Unit>
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
