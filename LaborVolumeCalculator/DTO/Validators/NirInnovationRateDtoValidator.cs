using System.Data;
using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class NirInnovationRateCreateDtoValidator : AbstractValidator<NirInnovationRateCreateDto>
    {
        public NirInnovationRateCreateDtoValidator()
        {
            RuleFor(m => m.NirInnovationPropertyID).GreaterThan(0).WithName("Идентификатор характеристики новизны НИР");
            RuleFor(m => m.NirScaleID).GreaterThan(0).WithName("Идентификатор масштаба НИР");
            RuleFor(m => m.Value).GreaterThan(0).WithName("Значение");
        }
    }

    public class NirInnovationRateUpdateDtoValidator : AbstractValidator<NirInnovationRateUpdateDto>
    {
        public NirInnovationRateUpdateDtoValidator()
        {
            Include(new NirInnovationRateCreateDtoValidator());
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
        }
    }
}