using BookRental.Api.Contracts.Requests;
using FluentAssertions;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using BookRental.Api.Models;
using BookRental.Api.Contracts.Responses;

namespace BookRental.Api.IntegrationTests;
internal class BookControllerTests
{
    private HttpClient _client;

    // TODOs
    // GET (empty, existing, non-existing)
    // POST (empty, existing, non-existing)
    // DELETE (empty, existing, non-existing)

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var factory = new CustomWebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _client?.Dispose();
    }

    [Test]
    public async Task GetAllBooks_ReturnsOk()
    {
        // Act
        var response = await _client.GetAsync("/api/v1/Book");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Test]
    public async Task UpdateBook_ReturnsNotFound_ForEmptyId()
    {
        // Arrange
        var bookId = Guid.Empty;
        var requestObj = new CreateOrUpdateBookRequest()
        {
            Title = "Title",
            Author = "Author",
            ISBN = "9780061120084",
            Status = BookStatus.OnShelf,
        };
        var jsonBody = JsonConvert.SerializeObject(requestObj, Formatting.Indented);
        var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync($"/api/v1/Book/{bookId}", httpContent);
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound, "- trying to update book with empty id should return 404");
    }

    [Test]
    public async Task UpdateBook_ReturnsNotFound_ForNonExistingId()
    {
        // Arrange
        var bookId = new Guid("bfc95608-c810-4a51-ba61-ffe108263c4c");
        var requestObj = new CreateOrUpdateBookRequest()
        {
            Title = "Title",
            Author = "Author",
            ISBN = "9780061120084",
            Status = BookStatus.OnShelf,
        };
        var jsonBody = JsonConvert.SerializeObject(requestObj, Formatting.Indented);
        var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync($"/api/v1/Book/{bookId}", httpContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound, "- trying to update non-existing book should return 404");
    }

    [Test]
    public async Task GetBooks_Page2_PerPage3_SortByAuthor_SortOrderDesc()
    {
        const string queryParams = "?page=2&perPage=3&sortBy=author&sortOrder=desc";
        // Act
        var response = await _client.GetAsync($"/api/v1/Book{queryParams}");
        var json = await response.Content.ReadAsStringAsync();
        var responseModel = JsonConvert.DeserializeObject<BooksResponse>(json)!;
        var books = responseModel.Items.ToList();

        // Assert
        // See BookContextWithData for test data
        books.Should().HaveCount(3);
        books[0].Author.Should().Be("Toni Morrison");
        books[2].Author.Should().Be("Ralph Ellison");
    }


    [Test]
    public async Task GetBooks_Page3_PerPage5_SortByIsbn_SortOrderAsc()
    {
        const string queryParams = "?page=3&perPage=5&sortBy=isbn&sortOrder=asc";
        // Act
        var response = await _client.GetAsync($"/api/v1/Book{queryParams}");
        var json = await response.Content.ReadAsStringAsync();
        var responseModel = JsonConvert.DeserializeObject<BooksResponse>(json)!;
        var books = responseModel.Items.ToList();

        // Assert
        // See BookContextWithData for test data
        books.Should().HaveCount(5);
        books[0].ISBN.Should().Be("9780140449129");
        books[4].ISBN.Should().Be("9780141439556");
    }
}
