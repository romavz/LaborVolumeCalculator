using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class CorrectionRatesBundleCreateDtoValidator : AbstractValidator<CorrectionRatesBundleCreateDto>
    {
        public CorrectionRatesBundleCreateDtoValidator()
        {
            RuleFor(m => m.Number).GreaterThan(0).WithName("Номер");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");

            RuleFor(m => m.SolutionInnovationRateID).GreaterThan(0).WithMessage("Необходимо указать ссылку на Коэффициент новизны решения");
            RuleFor(m => m.SolutionInnovationRateValue).GreaterThan(0).WithName("Коэффициент новизны решения");

            RuleFor(m => m.StandardModulesUsingRateID).GreaterThan(0).WithMessage("Необходимо указать ссылку на Коэффициент использования стандартных модулей");
            RuleFor(m => m.StandardModulesUsingRateValue).GreaterThan(0).WithName("Коэффициент использования стандартных модулей");

            RuleFor(m => m.InfrastructureComplexityRateID).GreaterThan(0).WithMessage("Необходимо указать ссылку на Коэффициент инфраструктурной сложности");
            RuleFor(m => m.InfrastructureComplexityRateValue).GreaterThan(0).WithName("Коэффициент инфраструктурной сложности");

            RuleFor(m => m.TestsDevelopmentRateID).GreaterThan(0).WithMessage("Необходимо указать ссылку на Коэффифиент сложности тестирования");
            RuleFor(m => m.TestsDevelopmentRateValue).GreaterThan(0).WithName("Коэффициент сложности тестирования");

            RuleFor(m => m.ArchitectureComplexityRateID).GreaterThan(0).WithMessage("Необходимо указать ссылку на Коэффициент Архитектурной сложности");
            RuleFor(m => m.ArchitectureComplexityRateValue).GreaterThan(0).WithName("Коэффициент Архитектурной сложности");
        }
    }

    public class CorrectionRatesBundleDtoValidator : AbstractValidator<CorrectionRatesBundleDto>
    {
        public CorrectionRatesBundleDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new CorrectionRatesBundleCreateDtoValidator());
        }
    }
}