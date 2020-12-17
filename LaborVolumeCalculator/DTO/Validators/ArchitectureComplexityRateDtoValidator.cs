using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class ArchitectureComplexityRateCreateDtoValidator : AbstractValidator<ArchitectureComplexityRateCreateDto>
    {
        public ArchitectureComplexityRateCreateDtoValidator()
        {
            RuleFor(m => m.Value).GreaterThanOrEqualTo(0).WithName("Объем");
            RuleFor(m => m.ComponentsInteractionArchitectureID).GreaterThan(0).WithName("Идентификатор архитектуры взаимодействия компонент");
            RuleFor(m => m.ComponentsMakroArchitectureID).GreaterThan(0).WithName("Идентификатор мАкроархитектуры компонент");
        }
    }

    public class ArchitectureComplexityRateCnageDtoValidator : AbstractValidator<ArchitectureComplexityRateCnageDto>
    {
        public ArchitectureComplexityRateCnageDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new ArchitectureComplexityRateCreateDtoValidator());
        }
    }
}