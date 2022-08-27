using ListOrganizer.Repo.Model;
using Microsoft.EntityFrameworkCore;

namespace ListOrganizer.Repo
{
    public class CategoryRepo : BaseRepo, ICategoryRepo
    {
        public CategoryRepo(DbContextOptions<ItemInventoryContext> options) : base(options)
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            return Db.Categories;
        }

        public Category GetCategory(int id)
        {
            return Db.Categories.Find(id);
        }

        public bool Save(Category category)
        {
            if (category.Id <= 0)
            {
                var save = Db.Categories.Add(category);
            }
            else
            {
                Db.Categories.Attach(category);
                Db.Entry(category).State = EntityState.Modified;
            }


            return Db.SaveChanges() > 0;
        }
    }
}
