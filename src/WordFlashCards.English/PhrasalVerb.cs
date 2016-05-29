using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordFlashCards.TextTokenizer;

namespace WordFlashCards.English
{
    public class PhrasalVerb
    {
        private int _offset;

        public string InitialVerb { get; protected set; }
        public string Rule { get; protected set; }
        public string Presentation { get; protected set; }

        public PhrasalVerb(string verb, string rule)
        {
            InitialVerb = verb;
            Rule = rule;
            CreatePresentation();
        }

        private void CreatePresentation()
        {
            var sb = new StringBuilder();

            foreach (var s in Rule.Split(' '))
            {
                if ((s != "*") && (s != "+"))
                {
                    if (sb.Length != 0)
                        sb.Append(" ");
                    sb.Append(s);
                }
            }
            Presentation = sb.ToString();
        }

        public bool TestRule(ITokenizer tokenizer)
        {
            var terms = Rule.Split(' ');
            var currentTerm = 1;
            _offset = 0;
            var usedTokens = new List<Token>();
            while (currentTerm < terms.Length)
            {
                var search = false;
                if (terms[currentTerm] == "*")
                {
                    currentTerm++;
                    search = true;
                }
                var t = searchToken(tokenizer, terms[currentTerm], search);
                if (t == null)
                    return false;
                usedTokens.Add(t);
                currentTerm++;
            }
            foreach (var token in usedTokens)
            {
                token.Text = "";
            }

            return true;
        }

        private Token searchToken(ITokenizer tokenizer, string term, bool search)
        {
            _offset += 1;
            var result = tokenizer.QueryToken(_offset, false);
            while (result != null)
            {
                if (!result.IsWord())
                {
                    if (search && (result.Text == "."))
                        result = null;
                    else
                    {
                        _offset += 1;
                        result = tokenizer.QueryToken(_offset, false);
                    }
                }
                else if (result.Text == term)
                    break;
                else
                {
                    if (!search)
                        result = null;
                    else
                    {
                        _offset += 1;
                        result = tokenizer.QueryToken(_offset, false);
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            return Presentation;
        }
    }
}
