using Application.Libros.Handlers;
using Application.Libros.Queries.Common;
using Application.Libros.Queries.GetAllLibros;
using Application.UnitTest.Common;
using Domain.Common;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTest.Libros.Queries
{
    public class GetAllLibroQueryHandler : QueryTestFixture
    {
        private readonly GetAllLibrosHandler _sut;

        public GetAllLibroQueryHandler()
            : base()
        {
            var paginationOptions = Options.Create(new FiltersOptions { DefaultPageNumber = 1, DefaultPageSize = 10 });
            _sut = new GetAllLibrosHandler(Context, Mapper, paginationOptions);
        }

        [Test]
        public async Task Handle_GetAllLibros_WithFilters()
        {
            var result = await _sut.Handle(new GetAllLibroQuery
            {
                Titulo = "It"
            }, CancellationToken.None);

            Assert.IsInstanceOf<PagedList<LibroDto>>(result);
            Assert.AreEqual("It", result[0].Titulo);
        }
    }
}
