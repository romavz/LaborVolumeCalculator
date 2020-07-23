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

namespace LaborVolumeCalculator.Pages.Nirs
{
    public class EditLaborVolumesModel : PageModel
    {
        private readonly LaborVolumeCalculator.Data.LVCContext _context;

        public EditLaborVolumesModel(LaborVolumeCalculator.Data.LVCContext context)
        {
            _context = context;
        }

        public Nir Nir { get; set; }
        public IList<NirStageVM> NirStagesVM { get; set; }

        public List<NirStage> FilledStages { get; set; } // чтоб заполненные эпапы показывать развернутыми

        public IOrderedEnumerable<NirLabor> NirLabors { get; set; }

        public List<LaborVolumeReg> RegistredLabors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nir = await _context.Nirs
                .Include(n => n.NirInnovationProperty)
                .Include(n => n.NirInnovationRate)
                .Include(n => n.NirScale).FirstOrDefaultAsync(m => m.ID == id);

            NirStagesVM = await _context.NirStages
                .OrderBy(m => m.Name)
                .Select(nirStage => new NirStageVM(nirStage)).ToListAsync();

            FilledStages = await (from laborReg in _context.LaborVolumeRegs
                                  where laborReg.NiokrID == Nir.ID
                                  join nirStage in _context.NirStages on laborReg.NiokrStageID equals nirStage.ID
                                    select nirStage).ToListAsync();

            var a = _context.NirLabors.ToList();
            NirLabors = a.OrderBy(x => x.Code, LaborCodeComparer.Instance);

            RegistredLabors = await _context.LaborVolumeRegs.Include(m => m.Labor)
                .Where(m => m.NiokrID == Nir.ID).ToListAsync();

            foreach (var nirStage in NirStagesVM)
            {
                nirStage.Labors = RegistredLabors
                    .Where(m => m.NiokrStageID == nirStage.ID)
                    .Select(m => (NirLabor)m.Labor)
                    .OrderBy(m => m.Code, LaborCodeComparer.Instance);

                nirStage.ExceptedLabors = NirLabors.Except(nirStage.Labors)
                    .OrderBy(m => m.Code, LaborCodeComparer.Instance);
            }

            if (Nir == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
