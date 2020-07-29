﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Dictionary
{
    [Display(Name = "Трудозатраты на разработку АЧ", GroupName = "Трудозатраты на разработку АЧ")]
    public class HardwareDevLabor : Labor
    {
        public HardwareDevLabor()
        {
        }

        public HardwareDevLabor(string code, string name, PlatePointsCountRange pointsCountRange, float minVolume, float maxVolume) : base(code, name, minVolume, maxVolume)
        {
            PlatePointsCountRange = pointsCountRange ?? throw new ArgumentNullException("pointsCountRange");
            PlatePointsCountRangeID = pointsCountRange.ID;
        }

        public int PlatePointsCountRangeID { get; set; }

        [DisplayName("Количество точек")]
        public PlatePointsCountRange PlatePointsCountRange { get; set; }

    }
}