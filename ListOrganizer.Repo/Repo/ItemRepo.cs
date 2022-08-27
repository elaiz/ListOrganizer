using ListOrganizer.Repo.Model;
using Microsoft.EntityFrameworkCore;

namespace ListOrganizer.Repo
{
    public class ItemRepo : BaseRepo, IItemRepo
    {
        public ItemRepo(DbContextOptions<ItemInventoryContext> options) : base(options)
        {
        }

        public Item GetItem(int id)
        {
            return Db.Items.Find(id);
        }

        public IEnumerable<Item> GetItems()
        {
            return Db.Items;
        }

        public IEnumerable<Item> GetItemsByCategory(int categoryId)
        {
            return Db.Items.Where(x => x.CategoryId.Equals(categoryId));
        }

        public bool Save(Item item)
        {
            if (item.Id <= 0)
            {
                var save = Db.Items.Add(item);
            }
            else
            {
                Db.Items.Attach(item);
                Db.Entry(item).State = EntityState.Modified;
            }


            return Db.SaveChanges() > 0;
        }
    }
}
