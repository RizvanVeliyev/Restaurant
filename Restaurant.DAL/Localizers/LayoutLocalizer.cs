using Microsoft.Extensions.Localization;
using System.Text;

namespace Restaurant.DAL.Localizers
{
    public class LayoutLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public LayoutLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Layout", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
