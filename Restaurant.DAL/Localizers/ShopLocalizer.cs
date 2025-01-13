using Microsoft.Extensions.Localization;
using System.Text;

namespace Restaurant.DAL.Localizers
{
    public class ShopLocalizer
    {
        private readonly IStringLocalizer _localizer;
        public ShopLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Shop", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
