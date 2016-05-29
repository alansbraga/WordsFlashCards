using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace WordFlashCards.TextTokenizer.Test
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class SimpleTokenTests
    {

        [Fact]
        public void FiveTokens()
        {
            var tokenizer = new Tokenizer("This is right");
            
            Assert.Equal(5, tokenizer.Tokens.Count);
        }

        [Fact]
        public void ThreeWords()
        {
            var tokenizer = new Tokenizer("This is right");
            var count = tokenizer.Tokens.Count(a => a.IsWord());
            Assert.Equal(3, count);
        }

        [Fact]
        public void NineTokensTwoSentences()
        {
            var tokenizer = new Tokenizer("First sentence. Second one.");
            var count = tokenizer.Tokens.Count;
            Assert.Equal(9, count);
        }

        [Fact]
        public void FourWordsTwoSentences()
        {
            var tokenizer = new Tokenizer("First sentence. Second one.");
            var count = tokenizer.Tokens.Count(a => a.IsWord());
            Assert.Equal(4, count);
        }

        [Fact]
        public void EightTokens()
        {
            var tokenizer = new Tokenizer("The year is 2016.");
            var count = tokenizer.Tokens.Count;
            Assert.Equal(8, count);
        }

        [Fact]
        public void ThreeWordsOneNumber()
        {
            var tokenizer = new Tokenizer("The year is 2016.");
            var count = tokenizer.Tokens.Count(a => a.IsWord());
            Assert.Equal(3, count);
            count = tokenizer.Tokens.Count(a => a.IsNumber());
            Assert.Equal(1, count);
        }

        [Fact]
        public void TwoNumbers()
        {
            var tokenizer = new Tokenizer("Pi equals 3.14.");
            var count = tokenizer.Tokens.Count(a => a.IsNumber());
            Assert.Equal(2, count);
        }
    }
}
