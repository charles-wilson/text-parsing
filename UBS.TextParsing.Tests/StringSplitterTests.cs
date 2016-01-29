using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UBS.TextParsing.Tests
{
    [TestFixture]
    public class StringSplitterTests
    {
        private readonly Tuple<string, List<string>>[] _testCases =

        {
            new Tuple<string, List<string>>("This is a statement, and so is this.",
                new List<string>
                {
                    "This",
                    "is",
                    "a",
                    "statement",
                    "and",
                    "so",
                    "is",
                    "this"
                }),

            new Tuple<string, List<string>>("This is second statement,this time with no space!",
                new List<string>
                {
                    "This",
                    "is",
                    "second",
                    "statement",
                    "this",
                    "time",
                    "with",
                    "no",
                    "space"
                }),

            new Tuple<string, List<string>>("Is this another another\nstatement,\rnow with new line?!",
                new List<string>
                {
                    "this",
                    "Is",
                    "another",
                    "another",
                    "statement",
                    "now",
                    "with",
                    "new",
                    "line",
                }),

            new Tuple<string, List<string>>(
                "Mendel;showed showed! this in several\\ ways: for/ example, by a back-cross.",
                new List<string>
                {
                    "Mendel",
                    "showed",
                    "showed",
                    "this",
                    "in",
                    "several",
                    "ways",
                    "for",
                    "example",
                    "by",
                    "a",
                    "back",
                    "cross",
                }),
        };


        [Test]
        public void SplitIntoWords_EmptyStringPassed_ReturnsZeroStrings()
        {
            var splitter = new StringSplitter();

            var words = splitter.SplitIntoWords(string.Empty);

            CollectionAssert.AreEquivalent(new string[]{}, words);
        }

        [Test]
        public void SplitIntoWords_NullPassed_ThrowsArgumentNullException()
        {
            var splitter = new StringSplitter();

            Assert.Throws<ArgumentNullException>(() => splitter.SplitIntoWords(null));
        }

        [Test, TestCaseSource("_testCases")]
        public void SplitIntoWords_ArbitrarySentencePassed_ReturnsWords(Tuple<string, List<string>> testCase)
        {
            var splitter = new StringSplitter();

            var words = splitter.SplitIntoWords(testCase.Item1);

            CollectionAssert.AreEquivalent(testCase.Item2, words);
        }
    }
}
