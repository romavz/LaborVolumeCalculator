using LaborVolumeCalculator.Models.Registers;
using System;
using System.Collections.Generic;
using LaborVolumeCalculator.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaborVolumeCalculator.ViewModels;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Utils;

namespace LaborVolumeCalculator.Services
{
    public interface ILaborVolumeRegService
    {
        IEnumerable<LaborVolumeReg> GetNiokrStageLaborVolumes(int niokrID, int niokrStageID);
    }

    public class LaborVolumeRegService : ILaborVolumeRegService
    {
        private readonly LVCContext _context;
        
        public LaborVolumeRegService(LVCContext context)
        {
            this._context = context;
        }

        public IEnumerable<LaborVolumeReg> GetNiokrStageLaborVolumes(int niokrID, int niokrStageID)
        {
            return _context.LaborVolumeRegs
                .Include(m => m.Labor)
                .Where(m =>
                    m.NiokrID == niokrID
                    && m.NiokrStageID == niokrStageID)
                .ToList()
                .OrderBy(m => m.Labor.Code, CodeComparer.Instance);
        }
    }
}
