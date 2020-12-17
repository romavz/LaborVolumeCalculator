using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class NirSoftwareDevLaborGroupCreateDtoValidator : AbstractValidator<NirSoftwareDevLaborGroupCreateDto>
    {
        public NirSoftwareDevLaborGroupCreateDtoValidator()
        {
            RuleFor(m => m.Code).IsGroupOfDidgitsSeparatedByDot().WithName("Код");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }

    public class NirSoftwareDevLaborGroupDtoValidator : AbstractValidator<NirSoftwareDevLaborGroupDto>
    {
        public NirSoftwareDevLaborGroupDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new NirSoftwareDevLaborGroupCreateDtoValidator());
        }
    }
}