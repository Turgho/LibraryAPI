using BibliotecaAPI.Models;

namespace BibliotecaAPI.DTOs;

public record ReadBookDto(
    int Id,
    string Title,
    string Author,
    int PublicationYear,
    bool AvailableForLoan,
    DateTime CreatedAt,
    DateTime UpdatedAt
)
{
    public static ReadBookDto FromEntity(Book book) =>
        new (
            book.Id,
            book.Title,
            book.Author,
            book.PublicationYear,
            book.AvailableForLoan,
            book.CreatedAt,
            book.UpdatedAt
        );
}