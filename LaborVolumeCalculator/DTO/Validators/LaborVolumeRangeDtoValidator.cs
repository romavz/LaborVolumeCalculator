using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{

    public class LaborVolumeRangeCreateDtoValidator : AbstractValidator<LaborVolumeRangeCreateDto>
    {
        public LaborVolumeRangeCreateDtoValidator()
        {
            CascadeMode = CascadeMode.Continue;

            RuleFor(m => m.LaborID).GreaterThan(0).WithName("Идентификатор работы");
            RuleFor(m => m.RangeFeatureID).GreaterThan(0).WithName("Идентификатор особенности");
            RuleFor(m => m.MinVolume).GreaterThanOrEqualTo(0d).WithName("Минимальный объем");
            RuleFor(m => m.MaxVolume).GreaterThanOrEqualTo(0d).WithName("Максимальный объем")
                .GreaterThanOrEqualTo(m => m.MinVolume).WithMessage("'Максимальный объем' должен быть больше или равен значению 'Минимальный объем'");
        }
    }

    public class LaborVolumeRangeChangeDtoValidator : AbstractValidator<LaborVolumeRangeChangeDto>
    {
        public LaborVolumeRangeChangeDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new LaborVolumeRangeCreateDtoValidator());
        }
    }
}