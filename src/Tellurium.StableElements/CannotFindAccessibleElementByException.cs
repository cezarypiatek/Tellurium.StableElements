using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Tellurium.StableElements
{
    public class CannotFindAccessibleElementByException:CannotFindElementByException
    {
        private List<string> candidatesDescriptions;

        public IReadOnlyList<IWebElement> Candidates { get; }

        public CannotFindAccessibleElementByException(By @by, ISearchContext context, IReadOnlyList<IWebElement> candidates, Exception? originalException = null) 
            : base(@by, context, originalException)
        {
            Candidates = candidates;
            this.candidatesDescriptions = GetCandidatesDescriptions();
        }

        public override string Message
        {
            get
            {
                if (Candidates.Count == 0)
                {
                    return base.Message;
                }
                return $"{base.Message} which meets accessibility criteria. Potential candidates:{string.Join("", candidatesDescriptions)}";
            }
        }

        private List<string> GetCandidatesDescriptions()
        {
            return Candidates.Select(x=>
            {
                try
                {
                    return $"\r\n\t- {x.TagName}[Displayed={x.Displayed}, Enabled={x.Enabled}]";
                }
                catch
                {
                    return null;
                }
                    
            }).OfType<string>().ToList();
        }
    }
}