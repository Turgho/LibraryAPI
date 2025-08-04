// using BibliotecaAPI.DTOs;
// using BibliotecaAPI.Models;
// using BibliotecaAPI.Repositories.Interfaces;
// using BibliotecaAPI.Services;
// using Moq;
//
// public class BookServicesTests
// {
//     private readonly Mock<IBookRepository> _mockRepo;
//     private readonly BookServices _service;
//
//     public BookServicesTests()
//     {
//         _mockRepo = new Mock<IBookRepository>();
//         _service = new BookServices(_mockRepo.Object);
//     }
//
//     [Fact]
//     public async Task ListBooksAsync_ReturnsListOfBooks()
//     {
//         // Arrange
//         var books = new List<ReadBookDto> {
//             new ReadBookDto(1, "Title1", "Author1", 2000, true, System.DateTime.UtcNow, System.DateTime.UtcNow),
//             new ReadBookDto(2, "Title2", "Author2", 2001, false, System.DateTime.UtcNow, System.DateTime.UtcNow)
//         };
//         _mockRepo.Setup(r => r.ListBooksAsync()).ReturnsAsync(books);
//
//         // Act
//         var result = await _service.ListBooksAsync();
//
//         // Assert
//         Assert.NotNull(result);
//         Assert.Equal(2, result.Count);
//     }
//
//     [Fact]
//     public async Task GetBookByIdAsync_ReturnsBook()
//     {
//         // Arrange
//         var bookEntity = new Book { Id = 1, Title = "Title", Author = "Author", PublicationYear = 2020, AvailableForLoan = true };
//         _mockRepo.Setup(r => r.GetBookEntityByIdAsync(1)).ReturnsAsync(bookEntity);
//
//         // Act
//         var result = await _service.GetBookByIdAsync(1);
//
//         // Assert
//         Assert.NotNull(result);
//         Assert.Equal("Title", result.Title);
//     }
// }