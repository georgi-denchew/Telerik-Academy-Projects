using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.StringContainingLibraryWCF
{
    public class ServiceStringContainCounter : IServiceStringContainer
    {
        public string PrintContainCount(string part, string container)
        {
            Regex rx = new Regex(part);

            MatchCollection matches = rx.Matches(container);

            return string.Format("The number of times the second string contains the first string is: {0}", matches.Count);
        }
    }
}
