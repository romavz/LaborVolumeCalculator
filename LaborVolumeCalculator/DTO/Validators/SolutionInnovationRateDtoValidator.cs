using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class SolutionInnovationRateCreateDtoValidator : AbstractValidator<SolutionInnovationRateCreateDto>
    {
        public SolutionInnovationRateCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Value).GreaterThanOrEqualTo(0d).WithName("Значение");
        }
    }

    public class SolutionInnovationRateDtoValidator : AbstractValidator<SolutionInnovationRateDto>
    {
        public SolutionInnovationRateDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new SolutionInnovationRateCreateDtoValidator());
        }
    }
}