using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class TestsScaleDtoValidator : AbstractValidator<TestsScaleDto>
    {
        public TestsScaleDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Code).GreaterThan(0);
        }
    }

    public class TestsScaleCreateDtoValidator : AbstractValidator<TestsScaleCreateDto>
    {
        public TestsScaleCreateDtoValidator()
        {
            RuleFor(m => m.Code).GreaterThan(0);
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }
}