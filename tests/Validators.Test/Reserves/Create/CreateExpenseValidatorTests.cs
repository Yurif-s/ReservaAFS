using CommonTestsUtilities.Requests;
using ReservaAFS.Application.UseCases.Reserves;
using ReservaAFS.Communication.Enums;
using Shouldly;

namespace Validators.Test.Reserves.Create;
public class CreateExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new ReserveValidator();
        var request = RequestCreateReserveJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeTrue();
    }
    [Fact]
    public void ErrorReservesCannotPast()
    {
        var validator = new ReserveValidator();
        var request = RequestCreateReserveJsonBuilder.Build();

        request.ReservationTime = DateTime.UtcNow.AddDays(-1);
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.ShouldHaveSingleItem(),
            errors => errors.ShouldContain(e => e.ErrorMessage.Equals("Reserva não pode ser para o passado"))
            );
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void ErrorDescriptionInvalid(string description)
    {
        var validator = new ReserveValidator();
        var request = RequestCreateReserveJsonBuilder.Build();

        request.Description = description; 
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.ShouldHaveSingleItem(),
            errors => errors.ShouldContain(e => e.ErrorMessage.Equals("Descrição é obrigatória"))
            );
    }
    [Fact]
    public void ErrorReserveTypeInvalid()
    {
        var validator = new ReserveValidator();
        var request = RequestCreateReserveJsonBuilder.Build();

        request.ReserveType = (ReserveType)10;
        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(
            errors => errors.ShouldHaveSingleItem(),
            errors => errors.ShouldContain(e => e.ErrorMessage.Equals("Recurso reservado é inválido"))
            );
    }
}
