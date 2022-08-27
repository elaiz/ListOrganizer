using ListOrganizer.Repo;
using ListOrganizer.Repo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadItemController : ControllerBase
    {

        private readonly IItemRepo _itemRepo;

        public ReadItemController(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _itemRepo.GetItems();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _itemRepo.GetItem(id);
        }

        [Route("api/[controller]")]
        [ApiController]
        public class WriteItemController : ControllerBase
        {

            private readonly IItemRepo _itemRepo;


            public WriteItemController(IItemRepo itemRepo)
            {
                _itemRepo = itemRepo;
            }

            /// <summary>
            /// Save an item
            /// </summary>
            /// <param name="item"></param>
            /// <returns>The id of the item saved</returns>
            [HttpPost]
            public int Save(Item item)
            {
                if (_itemRepo.Save(item))
                {
                    return item.Id;
                }

                return -1;
            }
        }
    }
}
