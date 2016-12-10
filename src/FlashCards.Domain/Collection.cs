using ASB.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.Domain
{
    public class Collection: Entidade<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<FlashCardCollection> FlashCards { get; set; }
    }
}
