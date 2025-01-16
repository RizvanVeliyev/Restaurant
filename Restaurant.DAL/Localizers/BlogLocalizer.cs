using Microsoft.Extensions.Localization;
using System.Text;

namespace Restaurant.DAL.Localizers
{
    public class BlogLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public BlogLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Blog", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
