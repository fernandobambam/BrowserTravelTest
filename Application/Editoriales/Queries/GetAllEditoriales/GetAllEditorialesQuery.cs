using Application.Editoriales.Queries.Common;
using MediatR;
using System.Collections.Generic;

namespace Application.Editoriales.Queries.GetAllEditoriales
{
    public class GetAllEditorialesQuery : IRequest<IEnumerable<EditorialDto>>
    {
    }
}
