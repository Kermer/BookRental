using BookRental.Api.Contracts;
using BookRental.Api.Contracts.Requests;
using BookRental.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookRental.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public sealed class BookController
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookRepository _bookRepository;

    public BookController(ILogger<BookController> logger, IBookRepository repository)
    {
        _logger = logger;
        _bookRepository = repository;
    }

    [HttpGet("{id}", Name = "GetBookById")]
    public async Task<IResult> GetById(Guid id)
    {
        var book = await _bookRepository.GetById(id);

        return book != null
            ? Results.Ok(book.MapToResponse())
            : Results.NotFound();
    }

    [HttpGet(Name = "GetAllBooks")]
    public async Task<IResult> Get()
    {
        var books = await _bookRepository.GetAll();
        return Results.Ok(books.MapToResponse());
    }

    [HttpPost(Name = "CreateBook")]
    public async Task<IResult> Create(CreateBookRequest request)
    {
        var book = request.MapToBook();
        var result = await _bookRepository.Create(book);

        return result.Match(
            _ => Results.CreatedAtRoute("GetBookById", new { id = book.Id }, book.MapToResponse()),
            failed => Results.BadRequest(failed.MapToResponse()));
    }

    [HttpPut("{id}", Name = "UpdateBook")]
    public async Task<IResult> Update(UpdateBookRequest request, Guid id)
    {
        var book = request.MapToBook(id);
        var result = await _bookRepository.Update(book);

        return result.Match(
            _ => Results.Ok(book.MapToResponse()),
            failed => Results.BadRequest(failed.MapToResponse()));
    }

    [HttpDelete("{id}", Name = "DeleteBook")]
    public async Task<IResult> Delete(Guid id)
    {
        var deleted = await _bookRepository.Delete(id);
        return deleted ? Results.Ok() : Results.NotFound();
    }
}
