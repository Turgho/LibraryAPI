using BibliotecaAPI.Models;
using FluentValidation;

namespace BibliotecaAPI.Validations;

public class CreateBookDtoValidator : AbstractValidator<Book>
{
    public CreateBookDtoValidator()
    {
        // Title
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters");
        
        // Author
        RuleFor(b => b.Author)
            .NotEmpty().WithMessage("Author is required")
            .MaximumLength(100).WithMessage("Author must not exceed 100 characters");
        
        // PublicationYear
        RuleFor(b => b.PublicationYear)
            .NotEmpty().WithMessage("PublicationYear is required")
            .InclusiveBetween(1450, DateTime.UtcNow.Year)
            .WithMessage($"Publication Year must be beetween 0 and {DateTime.UtcNow.Year}");
    }
}