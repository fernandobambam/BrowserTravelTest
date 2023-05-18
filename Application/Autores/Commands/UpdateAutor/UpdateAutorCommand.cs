using MediatR;

namespace Application.Autores.Commands.UpdateAutor
{
    public class UpdateAutorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
