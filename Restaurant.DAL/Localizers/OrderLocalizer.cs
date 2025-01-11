using Microsoft.Extensions.Localization;
using System.Text;

namespace Restaurant.DAL.Localizers
{
    public class OrderLocalizer
    {
        private readonly IStringLocalizer _localizer;
        public OrderLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Order", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
