using AutoMapper;
using BibliotecaAPI.Database;
using BibliotecaAPI.DTOs;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<BookRepository> _logger;

    // Constructor with dependencies
    public BookRepository(AppDbContext context, ILogger<BookRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    // Get book entity by ID or throw if not found
    public async Task<Book?> GetBookEntityByIdAsync(int id)
    {
        _logger.LogInformation("Searching book with ID {id}", id);
        return await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
    }

    // Get all books as a list of DTOs
    public async Task<List<Book>> ListBooksAsync()
    {
        _logger.LogInformation("Searching books");
        return await _context.Books.ToListAsync();
    }

    // Create a new book
    public async Task<Book?> CreateBookAsync(Book book)
    {
        _logger.LogInformation("Creating new book");

        var newBook = await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Book created with ID {id}", newBook.Entity.Id);

        return newBook.Entity;
    }

    // Update book partially using DTO
    public async Task<Book?> UpdateBookAsync(int id, Book book)
    {
        var existingBook = await GetBookEntityByIdAsync(id);
        if (existingBook is null)
        {
            _logger.LogError("Error to update book with ID {id}", id);
            return null;
        }
        
        _logger.LogInformation("Updating book with ID {id}", id);
        
        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.PublicationYear = book.PublicationYear;
        existingBook.AvailableForLoan = book.AvailableForLoan;
        existingBook.UpdatedAt = DateTime.UtcNow.AddHours(-3);
        
        await _context.SaveChangesAsync();
        return existingBook;
    }

    // Delete a book by ID
    public async Task<bool> DeleteBookAsync(int id)
    {
        _logger.LogInformation("Deleting book with ID {id}", id);
        var book = await GetBookEntityByIdAsync(id);

        if (book is null)
        {
            _logger.LogError("Error to remove book with ID {id}", id);
            return false;
        }
        
        _context.Books.Remove(book);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
