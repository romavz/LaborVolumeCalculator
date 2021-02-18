using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class TestsCoverageLevelCreateDtoValidator : AbstractValidator<TestsCoverageLevelCreateDto>
    {
        public TestsCoverageLevelCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Code).GreaterThan(0);
        }
    }

    public class TestsCoverageLevelDtoValidator : AbstractValidator<TestsCoverageLevelDto>
    {
        public TestsCoverageLevelDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.Code).GreaterThan(0);
        }
    }
}