using FluentValidation;

namespace Application.Libros.Commands.CreateLibro
{
    public class CreateLibroCommandValidator : AbstractValidator<CreateLibroCommand>
    {
        public CreateLibroCommandValidator()
        {
            RuleFor(libro => libro.Titulo)
                .NotNull()
                .NotEmpty()
                .MaximumLength(45);

            RuleFor(libro => libro.NPaginas)
                .NotNull()
                .NotEmpty()
                .MaximumLength(45);
        }
    }
}
