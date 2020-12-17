using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class StandardModulesUsingRateCreateDtoValidator : AbstractValidator<StandardModulesUsingRateCreateDto>
    {
        public StandardModulesUsingRateCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Value).GreaterThanOrEqualTo(0d).WithName("Значение");
        }
    }

    public class StandardModulesUsingRateDtoValidator : AbstractValidator<StandardModulesUsingRateDto>
    {
        public StandardModulesUsingRateDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new StandardModulesUsingRateCreateDtoValidator());
        }
    }
}