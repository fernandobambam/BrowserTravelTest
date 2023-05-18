using MediatR;

namespace Application.Editoriales.Commands.CreateEditorial
{
    public class CreateEditorialCommand : IRequest<Unit>
    {
        public string Nombre { get; set; }
        public string Sede { get; set; }
    }
}
