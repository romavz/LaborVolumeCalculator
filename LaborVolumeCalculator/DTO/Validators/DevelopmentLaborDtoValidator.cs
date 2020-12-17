using System.Security.Cryptography.X509Certificates;
using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class DevelopmentLaborCreateDtoValidator : AbstractValidator<DevelopmentLaborCreateDto>
    {
        public DevelopmentLaborCreateDtoValidator()
        {
            RuleFor(m => m.Code).IsGroupOfDidgitsSeparatedByDot().WithName("Код");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.LaborCategoryID).GreaterThan(0).WithName("Идентификатор категории работ");
        }
    }

    public class DevelopmentLaborChangeDtoValidator : AbstractValidator<DevelopmentLaborChangeDto>
    {
        public DevelopmentLaborChangeDtoValidator()
        {
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор");
            Include(new DevelopmentLaborCreateDtoValidator());
        }
    }

    public class DevelopmentLaborCreateDto_ListItemValidator : AbstractValidator<DevelopmentLaborCreateDto_ListItem>
    {
        public DevelopmentLaborCreateDto_ListItemValidator()
        {
            RuleFor(m => m.Code).IsGroupOfDidgitsSeparatedByDot().WithName("Код");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
        }
    }
}