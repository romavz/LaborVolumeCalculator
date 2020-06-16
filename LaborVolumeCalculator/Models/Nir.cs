using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models
{
    [Description("НИР")]
    public class Nir : BasicModel
    {
        public Nir() : base() { }
        public Nir(string name) : base(name) { }
    }
}
