using MediatR;

namespace Application.Editoriales.Commands.DeleteEditorial
{
    public class DeleteEditorialCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
