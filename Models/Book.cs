using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models;

public class Book
{
    [Key]
    [Display(Name = "ID")]
    [Description("The ID of the book")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
    [Display(Name = "Title")]
    [Description("The name of the book")]
    public string Title { get; set; } = null!; // Avoid null

    [Required(ErrorMessage = "Author is required")]
    [MaxLength(100, ErrorMessage = "Author can't be longer than 100 characters")]
    [Display(Name = "Author")]
    [Description("The author of the book")]
    public string Author { get; set; } = null!;

    [Required(ErrorMessage = "Publication year is required")]
    [Range(1450, 2100, ErrorMessage = "Publication year must be a valid year")]
    [Display(Name = "Publication Year")]
    [Description("The publish date of the book")]
    public int PublicationYear { get; set; }

    [Display(Name = "Available for Loan")]
    [Description("If the book is available for loan")]
    public bool AvailableForLoan { get; set; } = true; // True as Default
    
    [Display(Name = "Created Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Description("The created date of the book")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Updated Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Description("The last updated date of the book")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}