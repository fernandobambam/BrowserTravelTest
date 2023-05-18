using Application.Editoriales.Queries.Common;
using MediatR;

namespace Application.Editoriales.Queries.GetEdtiroialById
{
    public class GetEditorialByIdQuery : IRequest<EditorialDto>
    {
        public int Id { get; set; }
    }
}
