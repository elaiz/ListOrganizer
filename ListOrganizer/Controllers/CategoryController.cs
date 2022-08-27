using ListOrganizer.Repo;
using ListOrganizer.Repo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadCategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public ReadCategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryRepo.GetCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryRepo.GetCategory(id);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class WriteCategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public WriteCategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpPost]
        public int Save(Category category)
        {
            if(_categoryRepo.Save(category))
            {
                return category.Id;
            }

            return -1;
        }
    }
}
