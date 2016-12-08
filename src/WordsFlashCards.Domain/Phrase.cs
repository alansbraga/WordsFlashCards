using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsFlashCards.Domain
{
    public class Phrase
    {
        public string Text { get; set; }

        public Phrase()
        {
            Text = "";
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
