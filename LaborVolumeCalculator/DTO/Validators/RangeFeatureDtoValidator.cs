using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class RangeFeatureCreateDtoValidator : AbstractValidator<RangeFeatureCreateDto>
    {
        public RangeFeatureCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.RangeFeatureCategoryID).GreaterThan(0).WithName("Идентификатор категории");
        }
    }

    public class RangeFeatureChangeDtoValidator : AbstractValidator<RangeFeatureChangeDto>
    {
        public RangeFeatureChangeDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new RangeFeatureCreateDtoValidator());
        }
    }

    public class RangeFeatureCreateDto_ListItemValidator : AbstractValidator<RangeFeatureCreateDto_ListItem>
    {
        public RangeFeatureCreateDto_ListItemValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }
}