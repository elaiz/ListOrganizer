namespace ListOrganizer.Api.Tests
{
    [TestClass]
    public class CategoryTests
    {
        private int categoryId = 1;

        private Mock<ICategoryRepo> GetRepo()
        {
            var category = new Category { Id = categoryId, Description = "Description", Name = "Category Name" };
            var categoryList = new List<Category> { category } ;
            
            var repo = new Mock<ICategoryRepo>();
            repo.Setup(x => x.GetCategories()).Returns(categoryList);
            repo.Setup(x => x.GetCategory(categoryId)).Returns(category);

            return repo;
        }

        private CategoryController GetController()
        {
            var repo = GetRepo();
            return new CategoryController(repo.Object);
        }

        [TestMethod]
        public void GetCategoryController_Get_returnCategoryList()
        {
            var result = GetController().Get();

            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCategoryController_GetById_returnCategory()
        {
            var result = GetController().Get(categoryId);

            Assert.IsNotNull(result);
        }
    }
}