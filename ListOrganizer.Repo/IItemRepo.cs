using ListOrganizer.Repo.Model;

namespace ListOrganizer.Repo
{
    public interface IItemRepo
    {
        public Item GetItem(int id);
        public IEnumerable<Item> GetItems();

        public bool Save(Item item);

    }
}
