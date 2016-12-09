using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordFlashCards.TextTokenizer;
using WordsFlashCards.Domain;
using WordsFlashCards.Domain.interfaces;

namespace WordFlashCards.English
{
    public class EnglishInterpreter : IInterpreter
    {
        public static HashSet<string> PhraseEndings = new HashSet<string>()
        {
            ".",
            ";",
            "!",
            "?"
        };
        private ITokenizer _tokenizer;
        private VerbList _verbs;
        private PhrasalVerbList _phrasalVerbs;

        public EnglishInterpreter(ITokenizer tokenizer)
        {
            _tokenizer = tokenizer;
            _verbs = new VerbList();
            _phrasalVerbs = new PhrasalVerbList();
        }

        public IEnumerable<Word> Interprete()
        {
            var result = new Dictionary<string,Word>();
            var currentPhrase = new Phrase();
            var t = _tokenizer.CurrentToken();
            var wasSpace = false;

            while (t != null)
            {

                if ((t.IsSpace()) && (!wasSpace))
                    currentPhrase.Text += " ";
                if (!t.IsSpace())
                    currentPhrase.Text += t.Text;
                wasSpace = t.IsSpace();

                if (t.IsWord() && !t.Ignore)
                {
                    var w = new Word();
                    w.Text = t.Text;
                    w.AddPhrase(currentPhrase);
                    if (!TestPhrasalVerb(result, w))
                        AddToList(result, w);

                }

                if ((t.Text.Length == 1) && (PhraseEndings.Contains(t.Text)))
                {
                    currentPhrase = new Phrase();
                }


                t = _tokenizer.NextToken();
            }


            return result.Values;
        }

        private bool TestPhrasalVerb(IDictionary<string,Word> result, Word w)
        {
            foreach (var v in _verbs.FindConjugatedVerb(w.Text))
            {
                foreach (var pv in _phrasalVerbs.FindPhrasalVerb(_tokenizer, v.Infinitive))
                {
                    var newWord = new Word();
                    newWord.Text = pv.Presentation;
                    newWord.AddPhrase(w.Phrases.First());
                    AddToList(result, newWord);
                    return true;
                }
            }

            return false;
        }

        private bool AddToList(IDictionary<string,Word> result, Word newWord)
        {
            var key = newWord.Text.ToLower();

            if (result.ContainsKey(key))
            {
                var w = result[key];
                foreach (var p in newWord.Phrases)
                {
                    w.AddPhrase(p);
                }
                return false;
            }

            result.Add(key, newWord);
            return true;
        }

        public string Name()
        {
            return "English";
        }
    }
}
