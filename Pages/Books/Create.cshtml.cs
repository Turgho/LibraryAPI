using BibliotecaAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BibliotecaAPI.Pages.Books;

public class Create : PageModel
{
    private readonly HttpClient _httpClient;

    [BindProperty]
    public CreateBookDto BookDto { get; set; } = new CreateBookDto();

    public Create(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }
    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var response = await _httpClient.PostAsJsonAsync("api/books", BookDto);

        if (response.IsSuccessStatusCode) return RedirectToPage("../Index");
        
        var errorContent = await response.Content.ReadAsStringAsync();
        ModelState.AddModelError(string.Empty, $"Erro da API: {errorContent}");
        return Page();

    }
}