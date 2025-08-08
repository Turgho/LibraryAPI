using BibliotecaAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BibliotecaAPI.Pages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public List<ReadBookDto>? Books { get; set; }

    [BindProperty]
    public UpdateBookDto Book { get; set; } = new UpdateBookDto();
    
    [BindProperty]
    public int? EditBookId { get; set; }

    public IndexModel(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("ApiClient");
    }

    public async Task OnGetAsync()
    {
        await LoadBooksAsync();
    }

    public async Task<IActionResult> OnPostEditAsync(int editBookId)
    {
        var bookToEdit = await _httpClient.GetFromJsonAsync<ReadBookDto>($"api/books/{editBookId}");
        if (bookToEdit == null) return NotFound();

        Book = new UpdateBookDto
        {
            Title = bookToEdit.Title,
            Author = bookToEdit.Author,
            PublicationYear = bookToEdit.PublicationYear,
            AvailableForLoan = bookToEdit.AvailableForLoan
        };
        EditBookId = editBookId;

        await LoadBooksAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostSaveAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadBooksAsync();
            return Page();
        }

        var response = await _httpClient.PutAsJsonAsync($"api/books/{EditBookId}", Book);

        if (response.IsSuccessStatusCode)
            return RedirectToPage();

        ModelState.AddModelError(string.Empty, "Erro ao atualizar o livro.");
        await LoadBooksAsync();
        return Page();
    }

    private async Task LoadBooksAsync()
    {
        Books = await _httpClient.GetFromJsonAsync<List<ReadBookDto>>("api/books");
    }
}
