using BookRental.Api.Validation;
using FluentValidation.TestHelper;

namespace BookRental.Api.UnitTests.Validation;

internal class IsbnRequestValidatorTests
{
    private IsbnValidator _validator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _validator = new IsbnValidator();
    }

    [TestCase("0-306-40615-2")]
    [TestCase("978-3-16-148410-0")]
    [TestCase("123456789X")]
    [TestCase("9783161484100")]
    [TestCase(" 978-1-60309-502-0")]
    [TestCase("9781-60309-517-4")]
    [TestCase("978-160309-442-9")]
    [TestCase("  978-1-60309542-6 ")]
    [TestCase("978-1-60309-5273")]
    [TestCase("978-1-60309535-8 ")]
    [TestCase("978-160309520-4")]
    [TestCase("9781603095211")]
    [TestCase("978-1-891830-02-0")]
    public void IsValid(string isbn)
    {
        var result = _validator.TestValidate(isbn);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [TestCase("sometext")]
    [TestCase("978-1-60309-454-1")] // Check digit incorrect - should be "2"
    [TestCase("9781603094541")] // Check digit incorrect
    public void IsNotValid(string isbn)
    {
        var result = _validator.TestValidate(isbn);

        result.ShouldHaveAnyValidationError();
    }
}
