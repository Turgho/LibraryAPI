using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTOs;

public class UpdateBookDto
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Author { get; set; }
    public int? PublicationYear { get; set; }
    public bool AvailableForLoan { get; set; }
}