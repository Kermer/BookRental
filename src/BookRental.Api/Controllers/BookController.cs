using BookRental.Api.Contracts;
using BookRental.Api.Contracts.Requests;
using BookRental.Api.Contracts.Requests.Parameters;
using BookRental.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookRental.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookRepository _bookRepository;

    public BookController(ILogger<BookController> logger, IBookRepository repository)
    {
        _logger = logger;
        _bookRepository = repository;
    }

    [HttpGet("{id}", Name = "GetBookById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var book = await _bookRepository.GetById(id);

        return book != null
            ? Ok(book.MapToResponse())
            : NotFound();
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<IActionResult> Get([FromQuery] PaginationParameters paginationParams, [FromQuery] SortingParameters sortingParams)
    {
        var books = await _bookRepository.Get(paginationParams, sortingParams);
        return Ok(books.MapToResponse());
    }

    [HttpPost(Name = "CreateBook")]
    public async Task<IActionResult> Create(CreateOrUpdateBookRequest request)
    {
        var book = request.MapToBook();
        var result = await _bookRepository.Create(book);

        return result.Match<IActionResult>(
            _ => CreatedAtRoute("GetBookById", new { id = book.Id }, book.MapToResponse()),
            failed => BadRequest(failed.MapToResponse()));
    }

    [HttpPut("{id}", Name = "UpdateBook")]
    public async Task<IActionResult> Update(CreateOrUpdateBookRequest request, Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var existingBook = await _bookRepository.GetById(id);
        if (existingBook is null)
        {
            return NotFound();
        }

        var book = request.MapToBook(id);
        var result = await _bookRepository.Update(book);

        return result.Match<IActionResult>(
            _ => Ok(book.MapToResponse()),
            failed => BadRequest(failed.MapToResponse()));
    }

    [HttpDelete("{id}", Name = "DeleteBook")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _bookRepository.Delete(id);
        return deleted ? Ok() : NotFound();
    }
}
