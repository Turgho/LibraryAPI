using BibliotecaAPI.DTOs;
using BibliotecaAPI.Services;
using BibliotecaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : Controller
{
    private readonly IBookServices _bookServices;

    public BookController(IBookServices bookServices)
    {
        _bookServices = bookServices;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadBookDto>>> GetAllBooks()
    {
        var books = await _bookServices.ListBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadBookDto>> GetBookById(int id)
    {
        var book = await _bookServices.GetBookByIdAsync(id);
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<ReadBookDto>> CreateBook(CreateBookDto dto)
    {
        var createdBook = await _bookServices.CreateBookAsync(dto);
        return Ok(createdBook);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadBookDto>> UpdateBook(int id, UpdateBookDto dto)
    {
        var updatedBook = await _bookServices.UpdateBookAsync(id, dto);
        if (updatedBook == null)
            return NotFound();

        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var success = await _bookServices.DeleteBookAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}