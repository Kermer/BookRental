using BookRental.Api.Contracts.Requests.Parameters;
using BookRental.Api.Validation;
using FluentValidation.TestHelper;

namespace BookRental.Api.UnitTests.Validation;

public class SortingParametersValidatorTests
{
    private SortingParametersValidator _validator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _validator = new SortingParametersValidator();
    }
    
    [TestCase("title", "asc")]
    [TestCase("Author", "asc")]
    [TestCase("isBN", "asc")]
    [TestCase("StAtUs", "asc")]
    [TestCase("tItLe", "desc")]
    [TestCase("AUTHOR", "desc")]
    [TestCase("ISbn", "desc")]
    [TestCase("status", "desc")]
    public void IsValid(string sortBy, string sortOrder)
    {
        var sortingParameters = new SortingParameters
        {
            SortBy = sortBy,
            SortOrder = sortOrder
        };
        
        var result = _validator.TestValidate(sortingParameters);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [TestCase(" title", "asc")] // whitespaces not allowed
    [TestCase("foo", "asc")] // unknown column name
    [TestCase("title", "ascending")] // unknown sort order
    public void IsNotValid(string sortBy, string sortOrder)
    {
        var sortingParameters = new SortingParameters
        {
            SortBy = sortBy,
            SortOrder = sortOrder
        };
        
        var result = _validator.TestValidate(sortingParameters);

        result.ShouldHaveAnyValidationError();
    }
    
    [Test]
    public void IsValidForDefaultValues()
    {
        var sortingParameters = new SortingParameters();
        
        var result = _validator.TestValidate(sortingParameters);

        result.ShouldNotHaveAnyValidationErrors();
    }
}