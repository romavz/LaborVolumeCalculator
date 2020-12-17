using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class NirScaleCreateDtoValidator : AbstractValidator<NirScaleCreateDto>
    {
        public NirScaleCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }

    public class NirScaleDtoValidator : AbstractValidator<NirScaleDto>
    {
        public NirScaleDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }
}