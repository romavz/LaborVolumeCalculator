using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class ComponentsMacroArchitectureDtoValidator : AbstractValidator<ComponentsMacroArchitectureDto>
    {
        public ComponentsMacroArchitectureDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }

    public class ComponentsMacroArchitectureCreateDtoValidator : AbstractValidator<ComponentsMacroArchitectureCreateDto>
    {
        public ComponentsMacroArchitectureCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }
}