﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозатраты ОНТД", GroupName = "Трудозатраты ОНТД")]
    public class OntdLabor : Labor
    {
        public OntdLabor()
        {
        }

        public OntdLabor(string code, string name, float minVolume, float maxVolume) : base(code, name, minVolume, maxVolume)
        {
        }
    }
}
