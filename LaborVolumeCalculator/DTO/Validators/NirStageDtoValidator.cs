using System;
using FluentValidation;

namespace LaborVolumeCalculator.DTO.Validators
{
    public class NirStageCreateDtoValidator : AbstractValidator<NirStageCreateDto>
    {
        public NirStageCreateDtoValidator()
        {
            RuleFor(m => m.NirID).GreaterThan(0).WithName("Идентификатор НИР");
            RuleFor(m => m.Code).IsGroupOfDidgitsSeparatedByDot().WithName("Код");
            RuleFor(m => m.Name).NotEmpty().WithName("Название");
            RuleFor(m => m.DateTo).GreaterThanOrEqualTo(m => m.DateFrom.Date.AddDays(1)).WithMessage("'Дата окончания' должна быть позже даты начала");
            RuleFor(m => m.NirInnovationRateID).GreaterThan(0).WithName("Идентификатор коэффициента новизны");
            RuleFor(m => m.Volume).GreaterThanOrEqualTo(0).WithName("Объем");
            
            RuleForEach(m => m.LaborVolumes).SetValidator(new StageLaborVolumeDto_ListItemValidator());
            RuleForEach(m => m.OntdLaborVolumes).SetValidator(new StageLaborVolumeDto_ListItemValidator());
            RuleForEach(m => m.SoftwareDevLaborGroups).SetValidator(new StageSoftwareDevLaborGroupCreateDtoValidator());
        }
    }

    public class NirStageChangeDtoValidator : AbstractValidator<NirStageChangeDto>
    {
        public NirStageChangeDtoValidator()
        {
            Include(new NirStageCreateDtoValidator());
            RuleFor(m => m.ID).GreaterThan(0).WithName("Идентификатор этапа");
        }
    }
}