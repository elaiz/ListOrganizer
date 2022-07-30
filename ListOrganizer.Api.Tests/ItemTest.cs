

namespace ListOrganizer.Api.Tests
{
    [TestClass]
    public class ItemTest
    {
        private int itemId = 1;

        public Mock<IItemRepo> GetRepo()
        {
            var item = new Item { Id = itemId, Name = "Item #1", CategoryId = 1, Description = "Description of Item #1", Own = false, Priority = 0 };
            var collection = new List<Item> { item };
            var repo = new Mock<IItemRepo>();

            repo.Setup(x => x.GetItem(itemId)).Returns(item);
            repo.Setup(x => x.GetItems()).Returns(collection);

            return repo;
        }

        public ItemController GetController()
        {
            return new ItemController(GetRepo().Object);
        }

        [TestMethod]
        public void ItemController_Get_ReturnItemList()
        {
            var result = GetController().Get();
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void ItemController_Get_ReturnItem()
        {
            var result = GetController().Get(itemId);
            Assert.IsNotNull(result);
        }
    }
}
