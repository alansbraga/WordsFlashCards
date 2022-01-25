using ASB.DI;
using ASB.Dominio.Interfaces;
using FlashCards.Domain.Services;
using FlashCards.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordFlashCards.English;
using WordFlashCards.TextTokenizer;
using WordsFlashCards.Domain.interfaces;

namespace FlashCards.WordFlashCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new ContainerDI(false);
            container.Registrar<IUnidadeTrabalho, UnityOfWorkFlashCard>(EscopoComponente.WebRequest);
            container.Registrar<TextFileToFlashCards, TextFileToFlashCards>();
            container.Registrar<ICollectionFlashCardService, CollectionFlashCardService>();
            container.FinalizarRegistros();

            try
            {
                var importer = container.GetService<TextFileToFlashCards>();
                importer.ProcessFolder(@"C:\tmp\LivrosEmTexto");
                Console.WriteLine("Acabou");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                
            }
            _ = Console.ReadLine();
        }
    }
}
