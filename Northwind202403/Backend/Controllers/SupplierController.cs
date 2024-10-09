using Backend.DTO;
using Backend.Services.Implementations;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<SupplierDTO> Get()
        {
            return supplierService.Get();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public SupplierDTO Get(int id)
        {
            return supplierService.Get(id);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult Post([FromBody] SupplierDTO supplier)
        {
            supplierService.Add(supplier);
            return Ok(supplier);
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] SupplierDTO supplier)
        {
            supplierService.Update(supplier);
            return Ok(supplier);
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SupplierDTO supplier = new SupplierDTO 
            {
                SupplierId = id
            };
            supplierService.Delete(supplier);
        }
    }
}
