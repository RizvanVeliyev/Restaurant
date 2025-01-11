using Microsoft.Extensions.Localization;
using System.Text;

namespace Restaurant.DAL.Localizers
{
    public class ContactLocalizer
    {
        private readonly IStringLocalizer _localizer;
        public ContactLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Contact", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
