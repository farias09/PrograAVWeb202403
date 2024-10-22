using Backend.DTO;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        ICategoryService categoryService;

        #region Constructor
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        #endregion

        #region CRUD

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            return categoryService.Obtener();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            return categoryService.Obtener(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO category)
        {
            categoryService.Agregar(category);  
            return Ok(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CategoryDTO category)
        {
            categoryService.Editar(category);
            return Ok(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryDTO category = new CategoryDTO
            {
                CategoryId = id
            };
            categoryService.Eliminar(category);
        }

        #endregion
    }
}
