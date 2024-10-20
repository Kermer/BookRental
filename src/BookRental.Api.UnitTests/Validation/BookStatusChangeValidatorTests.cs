using BookRental.Api.Contracts;
using BookRental.Api.Models;
using BookRental.Api.Validation;
using FluentValidation.TestHelper;

namespace BookRental.Api.UnitTests.Validation;

internal class BookStatusChangeValidatorTests
{
    private BookStatusChangeValidator _validator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _validator = new BookStatusChangeValidator();
    }

    [TestCase(BookStatus.OnShelf, BookStatus.Borrowed)]
    [TestCase(BookStatus.OnShelf, BookStatus.Damaged)]
    [TestCase(BookStatus.Borrowed, BookStatus.Returned)]
    [TestCase(BookStatus.Returned, BookStatus.OnShelf)]
    [TestCase(BookStatus.Returned, BookStatus.Damaged)]
    [TestCase(BookStatus.Damaged, BookStatus.OnShelf)]
    public void IsValid(BookStatus currentStatus, BookStatus newStatus)
    {
        var statusChange = new BookStatusChange()
        {
            CurrentStatus = currentStatus,
            NewStatus = newStatus
        };
        var result = _validator.TestValidate(statusChange);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [TestCase(BookStatus.Unknown, BookStatus.OnShelf)]
    [TestCase(BookStatus.Unknown, BookStatus.Borrowed)]
    [TestCase(BookStatus.Unknown, BookStatus.Returned)]
    [TestCase(BookStatus.Unknown, BookStatus.Damaged)]
    [TestCase(BookStatus.OnShelf, BookStatus.Unknown)]
    [TestCase(BookStatus.OnShelf, BookStatus.Returned)]
    [TestCase(BookStatus.Borrowed, BookStatus.Unknown)]
    [TestCase(BookStatus.Borrowed, BookStatus.Damaged)]
    [TestCase(BookStatus.Borrowed, BookStatus.OnShelf)]
    [TestCase(BookStatus.Returned, BookStatus.Unknown)]
    [TestCase(BookStatus.Returned, BookStatus.Borrowed)]
    [TestCase(BookStatus.Damaged, BookStatus.Unknown)]
    [TestCase(BookStatus.Damaged, BookStatus.Borrowed)]
    [TestCase(BookStatus.Damaged, BookStatus.Returned)]
    public void IsNotValid(BookStatus currentStatus, BookStatus newStatus)
    {
        var statusChange = new BookStatusChange()
        {
            CurrentStatus = currentStatus,
            NewStatus = newStatus
        };
        var result = _validator.TestValidate(statusChange);

        result.ShouldHaveAnyValidationError();
    }

    [Test]
    public void IsFromSelfToSelfValid([Values] BookStatus status)
    {
        var statusChange = new BookStatusChange()
        {
            CurrentStatus = status,
            NewStatus = status
        };
        var result = _validator.TestValidate(statusChange);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
