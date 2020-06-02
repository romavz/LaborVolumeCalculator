using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Helpers
{
    public static class DisplayExtentions
    {
        public static string DisplayGroupNameFor<TModel, TDataModel>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TDataModel>> expression) 
                where TModel: class 
                where TDataModel: class
        {
            Type modelType = typeof(TDataModel);
            DisplayAttribute displayAttribute = GetDisplayAttributeFor(modelType);

            string gruoupName = displayAttribute?.GetGroupName() ?? modelType.Name;

            return gruoupName;
        }

        private static DisplayAttribute GetDisplayAttributeFor(Type modelType)
        {
            bool includeInherited = true;
            object[] attributes = modelType.GetCustomAttributes(includeInherited);

            return (DisplayAttribute)attributes.First(attr => attr is DisplayAttribute);
        }
    }
}
