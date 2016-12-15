using ASB.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.Domain
{
    public class Collection: Entidade<int>
    {
        public Collection()
        {
            FlashCards = FlashCards ?? new List<FlashCardCollection>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<FlashCardCollection> FlashCards { get; protected set;  }

        public void AddFlashCard(FlashCard flashcard, int ocurrencies = 1)
        {
            var fc = FlashCards.SingleOrDefault(p => p.FlashCard.Question == flashcard.Question);
            if (fc == null)
            {
                fc = new FlashCardCollection
                {
                    FlashCard = flashcard,
                    Occurrences = 0,
                };
                FlashCards.Add(fc);
            }
            fc.Occurrences += ocurrencies;
        }
    }
}
