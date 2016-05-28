using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsFlashCards.Domain.interfaces
{
    public interface IInterpreter
    {
        string Name();
        IEnumerable<Word> Interprete();
    }
}
