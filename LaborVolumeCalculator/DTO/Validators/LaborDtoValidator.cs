using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{

    public class LaborCreateDtoValidator : AbstractValidator<LaborCreateDto>
    {      
        public LaborCreateDtoValidator()
        {
            CascadeMode = CascadeMode.Continue;

            RuleFor(m => m.Code).IsGroupOfDidgitsSeparatedByDot().WithName("Код");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.MinVolume).GreaterThanOrEqualTo(0d).WithName("Минимальный объем");
            RuleFor(m => m.MaxVolume).GreaterThanOrEqualTo(0d).WithName("Максимальный объем")
                .GreaterThanOrEqualTo(m => m.MinVolume).WithMessage("Значение должно быть больше чем в поле 'Минимальный объем'");
        }
    }

    public class LaborDtoValidator : AbstractValidator<LaborDto>
    {
        public LaborDtoValidator()
        {
            Include(new LaborCreateDtoValidator());
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
        }
    }
}