namespace BibliotecaAPI.DTOs;

public class UpdateBookDto
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int? PublicationYear { get; set; }
    public bool? AvailableForLoan { get; set; }
}