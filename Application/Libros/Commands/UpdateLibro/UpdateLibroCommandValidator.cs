using FluentValidation;

namespace Application.Libros.Commands.UpdateLibro
{
    public class UpdateLibroCommandValidator : AbstractValidator<UpdateLibroCommand>
    {
        public UpdateLibroCommandValidator()
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
