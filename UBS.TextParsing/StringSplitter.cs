using System;
using System.Collections.Generic;
using System.Text;
using UBS.TextParsing.Interfaces;

namespace UBS.TextParsing
{
    public class StringSplitter : IStringSplitter
    {
        public IEnumerable<string> SplitIntoWords(string sentence)
        {
            Guard.NotNull(() => sentence, sentence);

            var stringList = new List<string>();

            var currentWordSb = new StringBuilder();

            foreach (var chr in sentence)
            {
                if (Char.IsPunctuation(chr) || Char.IsSeparator(chr) || Char.IsWhiteSpace(chr))
                {
                    AddToList(currentWordSb, stringList);
                    currentWordSb.Clear();
                }
                else
                {
                    currentWordSb.Append(chr);
                }
            }

            AddToList(currentWordSb, stringList);

            return stringList;
        }

        private void AddToList(StringBuilder stringBuilder, ICollection<string> collection)
        {
            var word = stringBuilder.ToString();
            if(!string.IsNullOrEmpty(word))
                collection.Add(word);
        }
    }
}
