using ASB.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.Domain
{
    public class FlashCard: Entidade<int>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public ICollection<Sample> Samples { get; set; }
        public StatusFlashCard Status { get; set; }

        public FlashCard()
        {
        }
    }
}
