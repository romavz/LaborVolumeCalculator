using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Характер новизны НИР", GroupName = "Характеристики новизны НИР")]
    public class NirInnovationProperty : BasicModel
    {
        public NirInnovationProperty() : base() { }
        public NirInnovationProperty(string name) : base(name) { }
    }
}
