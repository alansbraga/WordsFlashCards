using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordFlashCards.TextTokenizer
{
    public class Token : IEquatable<string>
    {
        public static string[] SPACES = new string[] { " ", "\n", "\r", "\t" };
        public static char[] SEPARATORS = new char[] { ' ', '.', ',', ';', '[', ']', '{', '}', '<', '>', '\\', '|', '+', '-', '/', '*', '=', '\'', '"', ':', '(', ')', '!', '?', '\t', '\n', '\r', '“', '‘', '’', '…', '”', '—', '©', '®', '™', '–' };

        public const string Anything = "anythingyouwant";

        public string Text { get; set; }


        public Token(string texto)
        {
            Text = texto;
        }


        public bool Equals(string other)
        {
            return (other.ToLower() == Anything) || (Text.ToUpper() == other.ToUpper());
        }


        public bool IsSpace()
        {
            return SPACES.Contains(Text);
        }

        public bool IsNumber()
        {
            int i;
            return Int32.TryParse(Text, out i);
        }

        public bool IsWord()
        {
            var notEmpty = !string.IsNullOrEmpty(Text);
            var notSeparator = !((Text.Length == 1) && (SEPARATORS.Contains(Text[0])));
            var notNumber = !IsNumber();
            return (notEmpty &&
                    notSeparator &&
                    notNumber);
        }

        public override string ToString()
        {
            return $"Text: '{Text}'";
        }
    }
}
