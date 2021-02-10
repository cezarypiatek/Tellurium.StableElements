using System;
using OpenQA.Selenium;

namespace Tellurium.StableElements
{
    public class CannotFindElementByException: WebElementNotFoundException
    {
        public By By { get; }

        public ISearchContext Context { get; }

        public CannotFindElementByException(By @by, ISearchContext context, Exception? originalException = null)
            :base($"Cannot find element {by} inside {context.GetElementDescription()}", originalException)
        {
            By = @by;
            Context = context;
        }
    }
}