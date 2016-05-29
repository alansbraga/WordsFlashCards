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
            var result = new List<Word>();
            var currentPhrase = new Phrase();
            var t = _tokenizer.CurrentToken();

            while (t != null)
            {
                if (currentPhrase.Text != "")
                    currentPhrase.Text += " ";
                currentPhrase.Text += t.Text;

                if (t.IsWord())
                {
                    var w = new Word();
                    w.Text = t.Text;
                    w.AddPhrase(currentPhrase);
                    if (!TestPhrasalVerb(result, w))
                        AddToList(result, w);

                    if ((w.Text.Length == 1) && (".;!".Contains(w.Text[0])))
                    {
                        var nextToken = _tokenizer.QueryToken(1, true);
                        if (nextToken == null)
                            currentPhrase = new Phrase();
                    }
                }

                t = _tokenizer.NextToken();
            }


            return result;
        }

        private bool TestPhrasalVerb(List<Word> result, Word w)
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

        private bool AddToList(List<Word> result, Word newWord)
        {
            foreach (var w in result)
            {
                if (w.Text == newWord.Text)
                {
                    foreach (var p in newWord.Phrases)
                    {
                        w.AddPhrase(p);
                    }
                    return false;
                }
            }
            result.Add(newWord);
            return true;
        }

        public string Name()
        {
            return "English";
        }
    }
}
