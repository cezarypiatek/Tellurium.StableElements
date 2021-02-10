using System;

namespace Tellurium.StableElements
{
    public class WebElementNotFoundException: Exception
    {
        public WebElementNotFoundException(string message, Exception? innerException=null) 
            : base(message, innerException)
        {
        }
    }
}