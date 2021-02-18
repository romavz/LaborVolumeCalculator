using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class ComponentsMicroArchitectureDtoValidator : AbstractValidator<ComponentsMicroArchitectureDto>
    {
        public ComponentsMicroArchitectureDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Code).GreaterThan(0);
        }

    }

    public class ComponentsMicroArchitectureCreateDtoValidator : AbstractValidator<ComponentsMicroArchitectureCreateDto>
    {
        public ComponentsMicroArchitectureCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Code).GreaterThan(0);
        }
    }
}