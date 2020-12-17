using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class InfrastructureComplexityRateCreateDtoValidator : AbstractValidator<InfrastructureComplexityRateCreateDto>
    {
        public InfrastructureComplexityRateCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Value).GreaterThan(0).WithName("Значение");
        }
    }

    public class InfrastructureComplexityRateDtoValidator : AbstractValidator<InfrastructureComplexityRateDto>
    {
        public InfrastructureComplexityRateDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new InfrastructureComplexityRateCreateDtoValidator());
        }
    }



}