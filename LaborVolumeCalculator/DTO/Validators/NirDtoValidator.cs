using System;
using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class NirCreateDtoValidator : AbstractValidator<NirCreateDto>
    {
        public NirCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.DateFrom).GreaterThanOrEqualTo(DateTime.Now.Date).WithName("Дата начала");
            RuleFor(m => m.DateTo).GreaterThanOrEqualTo(m => m.DateFrom.Date.AddDays(1)).WithMessage("'Дата окончания' должна быть позже даты начала");
            RuleFor(m => m.AnalogDurationMonthes).GreaterThan(0D).WithName("Время продолжительности");
            RuleFor(m => m.IntensiveRateValue).GreaterThan(0D).WithName("Коэффициент интенсивности");
        }
    }

    public class NirChangeDtoValidator : AbstractValidator<NirChangeDto>
    {
        public NirChangeDtoValidator()
        {
            Include(new NirCreateDtoValidator());
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Volume).GreaterThan(0).WithName("Объем");
        }

    }

}