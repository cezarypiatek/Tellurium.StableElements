using System;
using OpenQA.Selenium;

namespace Tellurium.StableElements
{
    internal static class GenericHelpers
    {
        public static TInterface As<TInterface>(this IWebElement element) where TInterface : class
        {
            if (element is TInterface typed)
            {
                return typed;
            }
            throw new NotSupportedException($"Underlying element does not support this operation. It should implement {typeof(TInterface).FullName} interface");
        }
    }
}