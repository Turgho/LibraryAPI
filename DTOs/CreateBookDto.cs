using BibliotecaAPI.Models;

namespace BibliotecaAPI.DTOs;

public record CreateBookDto(
    string Title,
    string Author,
    int PublicationYear,
    bool AvailableForLoan
);