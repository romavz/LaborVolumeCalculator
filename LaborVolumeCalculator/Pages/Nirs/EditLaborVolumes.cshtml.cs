using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using System.Security.Cryptography.X509Certificates;
using LaborVolumeCalculator.ViewModels;
using LaborVolumeCalculator.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaborVolumeCalculator.Pages.Nirs
{
    public class EditLaborVolumesModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditLaborVolumesModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nir Nir { get; set; }
        public IList<NirStageVM> NirStagesVM { get; set; }

        public IOrderedEnumerable<NirLabor> NirLabors { get; set; }

        [BindProperty]
        public List<NirLaborVolumeReg> RegistredLabors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nir = await _context.Nirs
                .Include(n => n.NirInnovationProperty)
                .Include(n => n.NirScale).FirstOrDefaultAsync(m => m.ID == id);

            NirStagesVM = await _context.StagesForNir
                .OrderBy(m => m.Name)
                .Select(nirStage => new NirStageVM(nirStage)).ToListAsync();

            var a = _context.NirLabors.ToList();
            NirLabors = a.OrderBy(x => x.Code, CodeComparer.Instance);

            RegistredLabors = await _context.NirLaborVolumeRegs.Include(m => m.Labor)
                .Where(m => m.NirID == Nir.ID).ToListAsync();

            foreach (var nirStage in NirStagesVM)
            {
                nirStage.AttachedLaborVolumes = RegistredLabors
                    .Where(m => m.StageID == nirStage.ID);
                
                var attachedLabors = nirStage.AttachedLaborVolumes
                    .Select(m => m.Labor)
                    .OrderBy(m => m.Code, CodeComparer.Instance);
            }

            if (Nir == null)
            {
                return NotFound();
            }
            return Page();
        }

        public SoftwareDevLaborGroupReg SoftwareDevLaborGroupReg { get; set; }
        public PartialViewResult OnGetSoftwareDevLaborGroupSelectionForm(int[] excepts)
        {
            var sdlGroups = _context.NirSoftwareDevLaborGroups;
            var result = sdlGroups
                .Except(sdlGroups.Where(m => excepts.Contains(m.ID)))
                .ToList()
                .OrderBy(m => m.Code, CodeComparer.Instance);

            ViewData["SoftwareDevLaborGroups"] = _context.NirSoftwareDevLaborGroups.ToArray().OrderBy(m => m.Code, CodeComparer.Instance);

            ViewData["ComponentsInteractionArchitectures"] = _context.ComponentsInteractionArchitectures.OrderBy(m => m.Name).ToArray();
            ViewData["ComponentsMakroArchitectures"] = _context.ComponentsMakroArchitectures.OrderBy(m => m.Name).ToArray();
            ViewData["ComponentsMicroArchitectures"] = _context.ComponentsMicroArchitectures.OrderBy(m => m.ID).ToArray();
            ViewData["InfrastructureComplexityRates"] = _context.InfrastructureComplexities.OrderBy(m => m.Value).ToArray();
            ViewData["SolutionInnovationRates"] = _context.SolutionInnovationRates.ToArray();
            ViewData["StandardModulesUsingRateID"] = _context.StandardModulesUsingRates.OrderBy(m => m.Name).Select(m => new SelectListItem($"{m.Name} - {m.Value}", $"{m.ID}")).ToList<SelectListItem>();
            ViewData["TestsCoverageLevels"] = _context.TestsCoverageLevels.OrderBy(m => m.Name).ToArray();
            ViewData["TestsScales"] = _context.TestsScales.OrderByDescending(m => m.ID).ToArray();
            ViewData["TestsDevelopmentRates"] = _context.TestsDevelopmentRates.ToArray();
            ViewData["ArchitectureComplexityRates"] = _context.ArchitectureComplexityRates.ToArray();
            return Partial("_SoftwareDevLaborGroupSelectionForm", this);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var niokrLaborVolumes = _context.NirLaborVolumeRegs.Where(m => m.NirID == Nir.ID);
            _context.RemoveRange(niokrLaborVolumes);

            await _context.AddRangeAsync(RegistredLabors);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NirExists(Nir.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NirExists(int id)
        {
            return _context.Nirs.Any(e => e.ID == id);
        }
    }
}
