using LaborVolumeCalculator.Migrations;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Data.Fillers
{
    public abstract class LaborsList
    {
        public LaborsList(LaborGroup laborGroup)
        {
            LaborGroup = laborGroup ?? throw new ArgumentNullException("laborGroup");

            LoadLabors();
        }

        public LaborGroup LaborGroup { get; set; }
        protected abstract void LoadLabors();

        protected void AddLabor(string code, string name)
        {
            //string fullCode = getFullCode(code, LaborGroup.ParentGroups);
            LaborGroup.Labors.Add(new Labor(fullCode, name, LaborGroup));
        }

        protected string getFullCode(string code)
        {
            
            string result = code;
            foreach( var parent in LaborGroup.ParentGroups)
            {
                result = result + "." + parent.ParentGroup.Code;
            }
            result.Remove(0);
            return result;
        }
    }
}
