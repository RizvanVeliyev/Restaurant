using Restaurant.Core.Enums;

namespace Restaurant.BLL.Services.Abstractions
{

    public interface ILanguageService
    {
        void SelectCulture(string culture);
        Languages RenderSelectedLanguage();
    }
}
