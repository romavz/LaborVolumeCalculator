using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class NirInnovationPropertyDtoValidator : AbstractValidator<NirInnovationPropertyDto>
    {
        public NirInnovationPropertyDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }

    public class NirInnovationPropertyCreateDtoValidator : AbstractValidator<NirInnovationPropertyCreateDto>
    {
        public NirInnovationPropertyCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }
}