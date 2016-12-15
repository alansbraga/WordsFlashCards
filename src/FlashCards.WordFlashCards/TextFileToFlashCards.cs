using ASB.Dominio.CRUD;
using FlashCards.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordFlashCards.English;
using WordFlashCards.TextTokenizer;
using WordsFlashCards.Domain.interfaces;
using WordsFlashCards.Domain;
using FlashCards.Domain.Services;
using ASB.Dominio.Interfaces;

namespace FlashCards.WordFlashCards
{
    public class TextFileToFlashCards
    {
        private ICollectionFlashCardService _service;
        private IUnidadeTrabalho _unityOfWork;

        public TextFileToFlashCards(ICollectionFlashCardService service, IUnidadeTrabalho unityOfWork)
        {
            _service = service;
            _unityOfWork = unityOfWork;
        }

        internal void ProcessFolder(string folder)
        {
            foreach (var file in Directory.GetFiles(folder, "*.txt"))
            {
                var fileName = Path.GetFileName(file);
                Console.WriteLine($"{DateTime.Now}: {fileName}");

                if (_service.CollectionExists(fileName))
                    continue;

                ITokenizer tokenizer = new Tokenizer(File.ReadAllText(file));
                IInterpreter interpreter = new EnglishInterpreter(tokenizer);
                var words = interpreter.Interprete();
                var collection = new Collection()
                {
                    Description = fileName,
                    Name = fileName
                };
                CreateFlashCards(collection, words);
                _service.AddCollection(collection);
                _unityOfWork.Commit();
            }
        }

        private void CreateFlashCards(Collection collection, IEnumerable<Word> words)
        {
            foreach (var w in words)
            {
                w.Text = w.Text.ToLower();
                collection.AddFlashCard(new FlashCard()
                    {
                        Question = w.Text,
                        Status = StatusFlashCard.New                                                
                    }, w.Phrases.Count());
            }
        }
    }
}
