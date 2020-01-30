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
using System.Diagnostics;

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
            var arquivos = Directory.GetFiles(folder, "*.txt", SearchOption.AllDirectories);
            var total = arquivos.Length;
            var atual = 0;
            var sw = new Stopwatch();
            long ticksMedio = 0;
            var parar = false;

            Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs e) =>
            {
                parar = true;
                e.Cancel = true;
            };

            foreach (var file in arquivos)
            {
                atual++;
                if (file.ToLower().Contains(" (1).txt"))
                {
                    File.Delete(file);
                    continue;
                }

                var fileName = Path.GetFileName(file);
                Console.WriteLine($"{DateTime.Now}: {atual:0000}/{total} - {fileName}");

                if (_service.CollectionExists(fileName))
                    continue;

                sw.Restart();
                ITokenizer tokenizer = new Tokenizer(File.ReadAllText(file));
                IInterpreter interpreter = new EnglishInterpreter(tokenizer);
                var words = interpreter.Interprete();
                var collection = new Collection()
                {
                    Description = fileName,
                    Name = fileName
                };
                Console.WriteLine($"Palavras encontradas {words.Count()}");
                CreateFlashCards(collection, words);
                _service.AddCollection(collection);
                _unityOfWork.Commit();                

                sw.Stop();
                if (ticksMedio == 0)
                    ticksMedio += sw.ElapsedTicks;
                ticksMedio += sw.ElapsedTicks;
                ticksMedio /= 2;
                var timesPan = new TimeSpan(ticksMedio);
                var tempoEstimado = new TimeSpan(ticksMedio * (total - atual));
                var horaFinal = DateTime.Now.Add(tempoEstimado);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Tempo Médio: {timesPan} |||| Tempo Estimado: {tempoEstimado} |||| Tempo Finalizar: {horaFinal}");
                Console.WriteLine("-----------------------------------");

                if (parar)
                {
                    Console.WriteLine("Parada requisitada");
                    return;
                }
                    
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
