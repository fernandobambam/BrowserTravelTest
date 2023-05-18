using MediatR;

namespace Application.Editoriales.Commands.UpdateEditorial
{
    public class UpdateEditorialCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }
    }
}
