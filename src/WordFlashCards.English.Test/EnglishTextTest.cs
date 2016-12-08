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
        //Given
            var tokenizer = new Tokenizer("This is right");
            var english = new EnglishInterpreter(tokenizer);
        //When
            var words = english.Interprete();
        //Then
            Assert.Equal(3, words.Count());
        }


        [Fact]
        public void PhrasalVerb()
        {
        //Given
            var tokenizer = new Tokenizer("We must carry on");
            var english = new EnglishInterpreter(tokenizer);
        //When
            var words = english.Interprete().ToArray();
        //Then
            Assert.Equal(3, words.Count());
            Assert.Equal("carry on", words[2].Text);
        }        

        [Fact]
        public void ComplexPhrasalVerb()
        {
        //Given
            var tokenizer = new Tokenizer("Please check this out");
            var english = new EnglishInterpreter(tokenizer);
        //When
            var words = english.Interprete().ToArray();
        //Then
            Assert.Equal(3, words.Count());
            Assert.Equal("check out", words[1].Text);
        }                
    }
}