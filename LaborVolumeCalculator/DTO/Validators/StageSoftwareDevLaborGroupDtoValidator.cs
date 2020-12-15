using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{

    internal class StageSoftwareDevLaborGroupBaseDtoValidator : AbstractValidator<StageSoftwareDevLaborGroupBaseDto>
    {
        public StageSoftwareDevLaborGroupBaseDtoValidator()
        {
            RuleFor(m => m.SoftwareDevLaborGroupID).GreaterThan(0).WithName("Идентификатор группы работ");
            RuleFor(m => m.CorrectionRatesBundleID).GreaterThan(0).When(m => m.CorrectionRatesBundleID.HasValue);

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

    public class StageSoftwareDevLaborGroupCreateDtoValidator : AbstractValidator<StageSoftwareDevLaborGroupCreateDto>
    {
        public StageSoftwareDevLaborGroupCreateDtoValidator()
        {
            Include(new StageSoftwareDevLaborGroupBaseDtoValidator());
            RuleForEach(m => m.LaborVolumes).SetValidator(new DevLaborVolumeCreateDtoValidator());
        }
    }
}