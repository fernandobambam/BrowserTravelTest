using MediatR;

namespace Application.Libros.Commands.DeleteLibro
{
    public class DeleteLibroCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
