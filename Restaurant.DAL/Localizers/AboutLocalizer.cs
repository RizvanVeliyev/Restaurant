using Microsoft.Extensions.Localization;
using System.Text;

namespace Restaurant.DAL.Localizers
{
    public class AboutLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public AboutLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("About", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
