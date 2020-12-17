using System.Security.Cryptography.X509Certificates;
using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class DevelopmentLaborCategoryCreateDtoValidator : AbstractValidator<DevelopmentLaborCategoryCreateDto>
    {
        public DevelopmentLaborCategoryCreateDtoValidator()
        {
            RuleFor(m => m.Number).GreaterThan(0).WithName("Номер");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");

            RuleForEach(m => m.Labors).SetValidator(new DevelopmentLaborCreateDto_ListItemValidator());
        }
    }

    public class DevelopmentLaborCategoryDtoValidator : AbstractValidator<DevelopmentLaborCategoryDto>
    {
        public DevelopmentLaborCategoryDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            RuleFor(m => m.Number).GreaterThan(0).WithName("Номер");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }
}