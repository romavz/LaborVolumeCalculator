using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class RangeFeatureCategoryDtoValidator : AbstractValidator<RangeFeatureCategoryChangeDto>
    {
        public RangeFeatureCategoryDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }

    public class RangeFeatureCategoryCreateDtoValidator : AbstractValidator<RangeFeatureCategoryCreateDto>
    {
        public RangeFeatureCategoryCreateDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleForEach(m => m.RangeFeatures).SetValidator(new RangeFeatureCreateDto_ListItemValidator());
        }
    }
}