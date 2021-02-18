using System.Security.Cryptography.X509Certificates;
using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class ComponentsInteractionArchitectureDtoValidator : AbstractValidator<ComponentsInteractionArchitectureDto>
    {
        public ComponentsInteractionArchitectureDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Code).GreaterThan(0);
        }
    }

    public class ComponentsInteractionArchitectureCreateDtoValidator : AbstractValidator<ComponentsInteractionArchitectureCreateDto>
    {
        public ComponentsInteractionArchitectureCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Code).GreaterThan(0);
        }
    }
}