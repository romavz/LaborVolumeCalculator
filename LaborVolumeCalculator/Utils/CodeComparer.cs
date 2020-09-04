using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LaborVolumeCalculator.Utils
{
    public class CodeComparer : IComparer<String>
    {
        static CodeComparer()
        {
            Instance = new CodeComparer();
        }

        public static CodeComparer Instance { get; private set; }

        public int Compare([AllowNull] String x, [AllowNull] String y)
        {
            var x_values_withIndex = x.Split('.').Select((value, index) => (int.Parse(value), index));
            int[] y_values = y.Split('.').Select(value => int.Parse(value)).ToArray();

            foreach((int x_value, int i) in x_values_withIndex.Take(y_values.Count()))
            {
                if (x_value == y_values[i]) continue;
                return x_value > y_values[i] ? 1 : -1;
            }
            
            if (x_values_withIndex.Count() == y_values.Count()) return 0;   // количество элементов и их значения равны
            return x_values_withIndex.Count() > y_values.Count() ? 1 : -1;
        }
    }
}