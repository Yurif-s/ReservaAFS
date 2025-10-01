using CommonTestsUtilities.Requests;
using ReservaAFS.Application.UseCases.Reserves;
using ReservaAFS.Exception;
using Shouldly;

namespace Validators.Test.Reserves.Create;
public class CreateExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new ReserveValidator();
        var request = RequestReserveJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeTrue();
    }
    [Fact]
    public void ErrorReservesCannotPast()
    {
        var validator = new ReserveValidator();
        var request = RequestReserveJsonBuilder.Build();

        request.ReservationTime = DateTime.UtcNow.AddDays(-1);
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.ShouldHaveSingleItem(),
            errors => errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrorMessages.RESERVES_CANNOT_PAST))
            );
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void ErrorDescriptionInvalid(string description)
    {
        var validator = new ReserveValidator();
        var request = RequestReserveJsonBuilder.Build();

        request.Description = description; 
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.ShouldHaveSingleItem(),
            errors => errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceErrorMessages.DESCRIPTION_INVALID))
            );
    }
}
