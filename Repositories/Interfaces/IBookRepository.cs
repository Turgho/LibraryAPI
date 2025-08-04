using BibliotecaAPI.DTOs;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories.Interfaces;

public interface IBookRepository
{
    Task<Book?> GetBookEntityByIdAsync(int id);
    Task<List<Book>> ListBooksAsync();
    Task<Book?> CreateBookAsync(Book dto);
    Task<Book?> UpdateBookAsync(int id, Book dto);
    Task<bool> DeleteBookAsync(int id);
}