using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Binders
{
    // Not used at the moment
    //public class DateTimeModelBinder : DefaultModelBinder
    //{
    //    private readonly string customFormat;

    //    public DateTimeModelBinder(string customFormat)
    //    {
    //        this.customFormat = customFormat;
    //    }

    //    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    //    {
    //        var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    //        return DateTime.ParseExact(value.AttemptedValue, customFormat, CultureInfo.InvariantCulture);
    //    }
    //}
}
