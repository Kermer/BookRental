using BookRental.Api.Contracts.Requests.Parameters;
using BookRental.Api.Validation;
using FluentValidation.TestHelper;

namespace BookRental.Api.UnitTests.Validation;

public class PaginationParametersValidatorTests
{
    private PaginationParametersValidator _validator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _validator = new PaginationParametersValidator();
    }

    [TestCase(1, 2)]
    [TestCase(int.MaxValue, 100)]
    public void IsValid(int page, int perPage)
    {
        var paginationParameters = new PaginationParameters
        {
            Page = page,
            PerPage = perPage
        };
        
        var result = _validator.TestValidate(paginationParameters);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [TestCase(0, 1)] // page must be >= 1
    [TestCase(-2, 1)] // page must be >= 1
    [TestCase(1, 0)] // per page must be >= 1
    [TestCase(1, -1)] // per page must be >= 1
    [TestCase(1, 101)] // per page must be <= 100
    [TestCase(1, int.MaxValue)] // per page must be <= 100
    public void IsNotValid(int page, int perPage)
    {
        var paginationParameters = new PaginationParameters
        {
            Page = page,
            PerPage = perPage
        };
        
        var result = _validator.TestValidate(paginationParameters);

        result.ShouldHaveAnyValidationError();
    }
    
    [Test]
    public void IsValidForDefaultValues()
    {
        var paginationParameters = new PaginationParameters();
        
        var result = _validator.TestValidate(paginationParameters);

        result.ShouldNotHaveAnyValidationErrors();
    }
}