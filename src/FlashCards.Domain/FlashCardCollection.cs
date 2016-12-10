using ASB.Dominio.Entidades;

namespace FlashCards.Domain
{
    public class FlashCardCollection: Entidade<int>
    {
        public FlashCard FlashCard { get; set; }
        public int Occurrences { get; set; }
    }
}