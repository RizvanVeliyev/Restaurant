using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Localizers
{
    public class ErrorLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public ErrorLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Errors", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
