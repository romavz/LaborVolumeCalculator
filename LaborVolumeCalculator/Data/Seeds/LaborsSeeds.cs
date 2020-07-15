using LaborVolumeCalculator.Migrations;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Data.Seeds
{
    public abstract class LaborsSeeds : List<Labor>
    {
        public LaborsSeeds(LaborGroup laborGroup)
        {
            LaborGroup = laborGroup ?? throw new ArgumentNullException("laborGroup");

            LoadLabors();
        }

        protected LVCContext DbContext { get; private set; }

        public LaborGroup LaborGroup { get; set; }
        protected abstract void LoadLabors();

        protected void AddLabor(string code, string name)
        {
            Add(new Labor(code, name, LaborGroup));
        }

    }
}
