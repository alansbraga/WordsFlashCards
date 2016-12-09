using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsFlashCards.Domain
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Word
    {
        private List<Tag> _tags;
        private List<Phrase> _phrases;

        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public IEnumerable<Tag> Tags
        {
            get
            {
                return _tags;
            }
            protected set
            {
                _tags = new List<Tag>(value);
            }
        }

        public IEnumerable<Phrase> Phrases
        {
            get
            {
                return _phrases;
            } 
            protected set
            {
                _phrases = new List<Phrase>(value);
            }
        }

        public void AddPhrase(Phrase phrase)
        {
            _phrases.Add(phrase);
        }

        public Word()
        {
            _tags = new List<Tag>();
            _phrases = new List<Phrase>();            
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
