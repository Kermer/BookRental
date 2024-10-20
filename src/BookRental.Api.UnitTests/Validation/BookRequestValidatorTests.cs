using BookRental.Api.Contracts.Requests;
using BookRental.Api.Validation;
using FluentValidation.TestHelper;
using NSubstitute;

namespace BookRental.Api.UnitTests.Validation;

internal class BookRequestValidatorTests
{
    private BookRequestValidator _validator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var isbnValidator = Substitute.For<IIsbnValidator>();
        _validator = new BookRequestValidator(isbnValidator);
    }

    [TestCase("Foo")]
    [TestCase("Bar")]
    public void Title_IsValid(string title)
    {
        var model = new CreateOrUpdateBookRequest()
        {
            Title = title,
            Author = string.Empty,
            ISBN = string.Empty,
            Status = default
        };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveValidationErrorFor(nameof(CreateOrUpdateBookRequest.Title));
    }

    [TestCase("")]
    [TestCase(" ")]
    public void Title_IsNotValid(string title)
    {
        var model = new CreateOrUpdateBookRequest()
        {
            Title = title,
            Author = string.Empty,
            ISBN = string.Empty,
            Status = default
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(nameof(CreateOrUpdateBookRequest.Title));
    }
}
