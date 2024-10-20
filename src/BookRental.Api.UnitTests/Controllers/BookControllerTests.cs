using BookRental.Api.Contracts.Requests;
using BookRental.Api.Controllers;
using BookRental.Api.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;

namespace BookRental.Api.UnitTests.Controllers;
internal class BookControllerTests
{
    public BookController _controller;

    // TODOs
    // GET (empty, existing, non-existing)
    // POST (empty, existing, non-existing)
    // DELETE (empty, existing, non-existing)

    [SetUp]
    public void SetUp()
    {
        var logger = Substitute.For<ILogger<BookController>>();
        var repository = Substitute.For<IBookRepository>();
        _controller = new BookController(logger, repository);
    }

    [TearDown]
    public void TearDown()
    {
        _controller.Dispose();
    }

    [Test]
    public async Task UpdateBook_ReturnsNotFound_ForEmptyId()
    {
        var request = new CreateOrUpdateBookRequest()
        {
            Title = string.Empty,
            Author = string.Empty,
            ISBN = string.Empty,
            Status = default,
        };

        var result = await _controller.Update(request, Guid.Empty) as IStatusCodeHttpResult;

        var statusCode = (HttpStatusCode)result!.StatusCode!;
        statusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Test]
    public async Task UpdateBook_ReturnsNotFound_ForNonExistingId()
    {
        var request = new CreateOrUpdateBookRequest()
        {
            Title = string.Empty,
            Author = string.Empty,
            ISBN = string.Empty,
            Status = default,
        };

        var result = await _controller.Update(request, new Guid("bfc95608-c810-4a51-ba61-ffe108263c4c")) as IStatusCodeHttpResult;

        var statusCode = (HttpStatusCode)result!.StatusCode!;
        statusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
