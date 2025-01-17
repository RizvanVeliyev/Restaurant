using Microsoft.Extensions.Localization;
using System.Text;

namespace Restaurant.DAL.Localizers
{
    public class AccountLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public AccountLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Account", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
