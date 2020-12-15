using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class DevLaborVolumeCreateDtoValidator : AbstractValidator<DevLaborVolumeCreateDto>
    {
        public DevLaborVolumeCreateDtoValidator()
        {
            RuleFor(m => m.LaborVolumeRangeID).GreaterThan(0).WithMessage("Необходимо указать ссылку на диапазон трудозатрат");
            RuleFor(m => m.Volume).GreaterThanOrEqualTo(0).WithName("Объем");
        }
    }
}