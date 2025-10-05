using FluentValidation;
using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Equipments;
public class EquipmentValidator : AbstractValidator<RequestEquipmentJson>
{
    public EquipmentValidator()
    {
        RuleFor(equipment => equipment.Name).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(equipment => equipment.Quantity).GreaterThanOrEqualTo(1).WithMessage("A quantidade deve ser pelo menos 1 (um).");
    }
}
