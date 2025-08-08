using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTOs;

public class CreateBookDto
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    public string Title { get; set; } = String.Empty;

    [Required(ErrorMessage = "O autor é obrigatório.")]
    public string Author { get; set; } = String.Empty;

    [Range(1000, 2100, ErrorMessage = "Ano inválido.")]
    public int PublicationYear { get; set; }

    public bool AvailableForLoan { get; set; }
}