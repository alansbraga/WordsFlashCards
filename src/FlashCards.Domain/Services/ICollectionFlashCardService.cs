namespace FlashCards.Domain.Services
{
    public interface ICollectionFlashCardService
    {
        void AddCollection(Collection collection);
        bool CollectionExists(string name);
    }
}