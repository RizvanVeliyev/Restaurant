using Microsoft.Extensions.Localization;

namespace Restaurant.DAL.Localizers
{
    public class ReservationLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public ReservationLocalizer(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create("Reservation", "Restaurant");
        }

        public string GetValue(string key)
        {
            return _localizer.GetString(key);
        }
    }
}
