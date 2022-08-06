using ListOrganizer.Repo;
using ListOrganizer.Repo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemRepo _itemRepo;


        public ItemController(IItemRepo itemRepo)
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
    }
}
