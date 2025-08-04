using AutoMapper;
using BibliotecaAPI.DTOs;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;
using BibliotecaAPI.Repositories.Interfaces;
using BibliotecaAPI.Services.Interfaces;

namespace BibliotecaAPI.Services;

public class BookServices : IBookServices
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookServices(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<List<ReadBookDto>?> ListBooksAsync()
    {
        var booksList = await _bookRepository.ListBooksAsync();
        if (booksList.Count == 0)
            return null;

        var books = _mapper.Map<List<ReadBookDto>>(booksList);
        return books;
    }

    public async Task<ReadBookDto?> GetBookByIdAsync(int id)
    {
        var existingBook = await _bookRepository.GetBookEntityByIdAsync(id);
        if  (existingBook == null)
            return null;
        
        var book = _mapper.Map<ReadBookDto>(existingBook);
        return book;
    }

    public async Task<ReadBookDto?> CreateBookAsync(CreateBookDto dto)
    {
        var book = _mapper.Map<Book>(dto);
        var newBook = await _bookRepository.CreateBookAsync(book);
        
        return newBook == null ? null : _mapper.Map<ReadBookDto>(book);
    }

    public async Task<ReadBookDto?> UpdateBookAsync(int id, UpdateBookDto dto)
    {
        var book = _mapper.Map<Book>(dto);
        var updatedBook = await _bookRepository.UpdateBookAsync(id, book);
        
        return updatedBook == null ? null : _mapper.Map<ReadBookDto>(updatedBook);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        return await _bookRepository.DeleteBookAsync(id);
    }
}
