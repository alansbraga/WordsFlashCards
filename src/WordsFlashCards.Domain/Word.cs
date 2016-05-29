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

        public Word()
        {
            _tags = new List<Tag>();
        }
    }
}
