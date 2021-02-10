using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Tellurium.StableElements
{
    public interface IStableWebElement : IWebElement, ILocatable, ITakesScreenshot, IWrapsElement, IWrapsDriver
    {
        void RegenerateElement();
        bool IsStale();
        string GetDescription();
    }
}