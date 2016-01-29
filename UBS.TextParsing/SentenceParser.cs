using System.Collections.Generic;
using System.Linq;
using UBS.TextParsing.Interfaces;

namespace UBS.TextParsing
{
    public class SentenceParser
    {
        private IStringSplitter _splitter;

        public SentenceParser(IStringSplitter splitter)
        {
            _splitter = splitter;
        }

        public IDictionary<string, int> Parse(string sentence)
        {
            Guard.NotNullOrEmpty(() => sentence, sentence);

            var words = _splitter.SplitIntoWords(sentence);

            var wordsCounts = from word in words
                group word by word.ToLower()
                into g
                select new {Word = g.Key, Count = g.Count()};
            
            return wordsCounts.ToDictionary(wc => wc.Word, wc => wc.Count);
        }
    }
}
