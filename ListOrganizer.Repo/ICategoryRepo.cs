
using ListOrganizer.Repo.Model;

namespace ListOrganizer.Repo
{
    public interface ICategoryRepo
    {
        public Category GetCategory(int id);
        public IEnumerable<Category> GetCategories();
    }
}
