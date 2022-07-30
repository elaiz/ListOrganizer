using ListOrganizer.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOrganizer.Repo
{
    public class ItemRepo : BaseRepo, IItemRepo
    {
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
    }
}
