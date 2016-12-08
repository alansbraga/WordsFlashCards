using System;
using System.IO;
using System.Text;
using System.Linq;
using WordFlashCards.TextTokenizer;
using WordFlashCards.English;
using WordsFlashCards.Domain;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inicio = DateTime.Now;
            var tokenizer = new Tokenizer(File.ReadAllText("eyecompleto.txt"));
            var english = new EnglishInterpreter(tokenizer);
            var words = english.Interprete().ToArray();

            words = words.OrderBy(a => a.Phrases.Count()).ToArray();

            var sb = new StringBuilder();
            sb.AppendLine($"Inicio: {inicio}");
            sb.AppendLine($"Tokens: {tokenizer.Tokens.Count}");
            sb.AppendLine($"Words: {words.Count()}");

            foreach (var w in words)
            {
                sb.AppendLine(w.Text);
                sb.AppendLine($"Frases: {w.Phrases.Count()}");
            }

            var rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                sb.AppendLine("----------------------------");
                var index = rnd.Next(words.Count());
                var w = words[index];

                sb.AppendLine(w.Text);
                foreach (var p in w.Phrases)
                {
                    sb.AppendLine(p.Text);
                }

            }

            var fim = DateTime.Now;
            sb.AppendLine($"Fim: {fim}");
            var passou = fim - inicio;
            sb.AppendLine($"Tempo dicionario: {passou}");


            File.WriteAllText("eyeprocessado.txt", sb.ToString());
        }
    }
}
