using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class StageLaborVolumeDto_ListItemValidator : AbstractValidator<StageLaborVolumeDto_ListItem>
    {
        public StageLaborVolumeDto_ListItemValidator()
        {
            RuleFor(m => m.LaborID).GreaterThan(0).WithName("Идентификатор работы");
            RuleFor(m => m.Volume).GreaterThanOrEqualTo(0).WithName("Объем");
        }
    }
}