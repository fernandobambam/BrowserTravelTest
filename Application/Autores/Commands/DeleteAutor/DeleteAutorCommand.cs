using MediatR;

namespace Application.Autores.Commands.DeleteAutor
{
    public class DeleteAutorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
