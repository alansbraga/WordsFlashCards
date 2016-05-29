using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordFlashCards.English
{
    public class Verb
    {
        public string Infinitive { get; set; }
        public string Form { get; set; }

        public Verb(string infinitive, string form)
        {
            Infinitive = infinitive;
            Form = form;
        }
        
    }
}
