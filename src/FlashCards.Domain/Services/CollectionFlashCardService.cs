using ASB.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.Domain.Services
{
    public class CollectionFlashCardService : ICollectionFlashCardService
    {
        private IRepositorio<Collection, int> _collectionRepository;
        private IRepositorio<FlashCard, int> _flashCardRepository;

        public CollectionFlashCardService(IRepositorio<Collection, int> collectionRepository, IRepositorio<FlashCard, int> flashCardRepository)
        {
            _collectionRepository = collectionRepository;
            _flashCardRepository = flashCardRepository;
        }

        public void AddCollection(Collection collection)
        {
            var newCollection = new Collection()
            {
                Description = collection.Description,
                Name = collection.Name
            };
            VerifyFlashCards(newCollection, collection.FlashCards);
            _collectionRepository.Adicionar(newCollection);
        }

        public bool CollectionExists(string name)
        {
            return _collectionRepository.Obter(a => a.Name == name).Any();
        }

        private void VerifyFlashCards(Collection newCollection, IEnumerable<FlashCardCollection> flashcards)
        {
            foreach (var fc in flashcards)
            {
                var flashCard = _flashCardRepository.Obter(fcp => fcp.Question == fc.FlashCard.Question, i => i.Samples).SingleOrDefault();
                if (flashCard == null)
                {
                    flashCard = new FlashCard
                    {
                        Question = fc.FlashCard.Question,
                        Answer = fc.FlashCard.Answer,
                        Status = fc.FlashCard.Status,
                        Samples = fc.FlashCard.Samples
                    };
                }
                else
                {
                    /*
                    foreach (var sample in fc.FlashCard.Samples)
                    {
                        flashCard.Samples.Add(sample);
                    }*/
                }

                newCollection.AddFlashCard(flashCard, fc.Occurrences);                
            }
        }
    }
}
