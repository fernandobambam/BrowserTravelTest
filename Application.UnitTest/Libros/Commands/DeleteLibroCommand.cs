using Application.Libros.Commands.DeleteLibro;
using Application.Libros.Handlers;
using Application.UnitTest.Common;
using Domain.Exceptions;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UnitTest.Libros.Commands
{
    [TestFixture]
    public class DeleteLibroCommandTest : CommandTestBase
    {
        private readonly DeleteLibroHandler _sut;

        public DeleteLibroCommandTest()
            : base()
        {
            _sut = new DeleteLibroHandler(_context);
        }

        [Test]
        public async Task Handle_GivenInvalid_ThrowsNotFoundException()
        {
            DeleteLibroCommand command = new DeleteLibroCommand
            {
                Id = 100
            };

            async Task Act() => await _sut.Handle(command, CancellationToken.None);

            Assert.That(Act, Throws.TypeOf<NotFoundException>());
        }
    }
}
