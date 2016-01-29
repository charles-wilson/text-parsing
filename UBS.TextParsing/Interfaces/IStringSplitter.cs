using System.Collections.Generic;

namespace UBS.TextParsing.Interfaces
{
    public interface IStringSplitter
    {
        IEnumerable<string> SplitIntoWords(string sentence);
    }
}
