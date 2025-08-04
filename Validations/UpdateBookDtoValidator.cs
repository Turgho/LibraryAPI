using BibliotecaAPI.DTOs;
using FluentValidation;

namespace BibliotecaAPI.Validations;

public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
{
    public UpdateBookDtoValidator()
    {
        // Title
        RuleFor(b => b.Title)
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters")
            .When(b => b.Title != null);

        // Author
        RuleFor(b => b.Author)
            .MinimumLength(3).WithMessage("Author must be at least 3 characters long")
            .MaximumLength(100).WithMessage("Author must not exceed 100 characters")
            .When(b => b.Author != null);

        // PublicationYear
        RuleFor(b => b.PublicationYear)
            .InclusiveBetween(1450, DateTime.UtcNow.Year)
            .WithMessage($"PublicationYear must be between 1450 and {DateTime.UtcNow.Year}")
            .When(b => b.PublicationYear.HasValue);
    }
}