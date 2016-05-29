using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFlashCards.TextTokenizer
{
    public class Tokenizer : ITokenizer
    {
        private List<Token> _tokens;
        private string _text;
        private int _index;

        public int CurrentIndex
        {
            get { return _index; }
            set { _index = value; }
        }

        public List<Token> Tokens
        {
            get { return _tokens; }
            set { _tokens = value; }
        }


        public Token CurrentToken()
        {
            if ((_index < 0) || (_index >= _tokens.Count))
                return null;
            else
                return _tokens[_index];
        }

        public Token NextToken()
        {
            _index++;
            return CurrentToken();
        }

        public Token QueryToken(int offSet, bool ignoreSpaces)
        {
            if (offSet == 0)
                return CurrentToken();
            int i;
            Token result = null;
            int increment;
            i = CurrentIndex;

            if (offSet < 0)
                increment = -1;
            else
                increment = 1;

            while (offSet != 0)
            {
                i = i + increment;
                if ((i < _tokens.Count) && (i >= 0))
                {
                    result = _tokens[i];
                    if (!ignoreSpaces || (result == null) || ((result != null) && (!result.IsSpace())))
                        offSet = offSet - increment;
                }
                else
                {
                    result = null;
                    break;
                }
            }
            return result;
        }


        public Tokenizer(string text)
        {
            _tokens = new List<Token>();
            _text = text;
            ProcessText(_text);
            _index = 0;

        }
        private void ProcessText(string text)
        {
            string local = "";

            foreach (var currentChar in text)
            {
                if (Token.SEPARATORS.Contains(currentChar))
                    local = Add(local, currentChar.ToString());
                else
                    local = local + currentChar;
            }
            Add(local, "");
        }

        public string CurrentLine()
        {
            Token tk = null;
            var offSet = 0;
            do
            {
                offSet--;
                tk = QueryToken(offSet, false);
            } while ((tk != null) && (!tk.Equals("\n")));

            var result = new StringBuilder();
            do
            {
                offSet++;
                tk = QueryToken(offSet, false);
                if (tk != null)
                    result.Append(tk.Text);
            } while ((tk != null) && (!tk.Equals("\n")));


            return result.ToString();
        }

        private string Add(string local, string character)
        {
            if (!String.IsNullOrEmpty(local))
                _tokens.Add(new Token(local));
            if (!String.IsNullOrEmpty(character))
                _tokens.Add(new Token(character));
            return "";
        }

        public bool TestTokens(params string[] lista)
        {
            return TestTokens(true, lista);
        }


        public bool TestTokens(bool ignoreSpaces, params string[] list)
        {

            for (var i = 0; i < list.Count(); i++)
            {
                var s = list[i];
                var next = QueryToken(i, ignoreSpaces);
                if ((next == null) || (!next.Equals(s)))
                    return false;
            }
            return true;
        }
    }
}
