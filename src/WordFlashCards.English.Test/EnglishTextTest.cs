using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using WordFlashCards.English;

namespace WordFlashCards.TextTokenizer.Test
{
    public class EnglishTextTest{
        [Fact]
        public void SimpleWords()
        {
            var words = Text2Words("This is right");
            Assert.Equal(3, words.Count());
        }


        [Fact]
        public void PhrasalVerb()
        {
            var words = Text2Words("We must carry on");

            Assert.Equal(3, words.Count());
            Assert.Equal("carry on", words[2].Text);
        }        

        [Fact]
        public void ComplexPhrasalVerb()
        {
            var words = Text2Words("Please check this out");
            Assert.Equal(3, words.Count());
            Assert.Equal("check out", words[1].Text);
        }

        private static WordsFlashCards.Domain.Word[] Text2Words(string text)
        {
            var tokenizer = new Tokenizer(text);
            var english = new EnglishInterpreter(tokenizer);
            var words = english.Interprete().ToArray();
            return words;
        }

        [Fact]
        public void WithNumbersAndRepeteadWord()
        {
            var words = Text2Words("For a moment Rand stared at the Warder, not grasping what it was he 115 was talking about.");
            var phrase = words[0].Phrases.First();
            Assert.Equal(16, words.Count());
            Assert.Equal("For a moment Rand stared at the Warder, not grasping what it was he 115 was talking about.", phrase.Text);
        }

        [Fact]
        public void LotsOfSpaces()
        {
            var words = Text2Words("Too  \n\r\tmany  spaces\rwill\ndisapear!");
            var phrase = words[0].Phrases.First();
            Assert.Equal(5, words.Count());
            Assert.Equal("Too many spaces will disapear!", phrase.Text);
        }
    }
}