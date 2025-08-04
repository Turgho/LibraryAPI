using BibliotecaAPI.DTOs;

namespace BibliotecaAPI.Services.Interfaces;

public interface IBookServices
{
    Task<List<ReadBookDto>?> ListBooksAsync();
    Task<ReadBookDto?> GetBookByIdAsync(int id);
    Task<ReadBookDto?> CreateBookAsync(CreateBookDto dto);
    Task<ReadBookDto?> UpdateBookAsync(int id, UpdateBookDto dto);
    Task<bool> DeleteBookAsync(int id);
}