using Microsoft.AspNetCore.Mvc;
using Product.Entity.DAL;

namespace Product.Microservice.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context) => _context = context;

        [HttpGet("api/getallproduct")]
        public IActionResult GetAllProducts()
        {
            var issues = _context.Products.ToList();
            return issues == null ? NotFound() : Ok(issues);
        }

        [HttpGet("api/{id}")]
        [ProducesResponseType(typeof(Entity.Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetbyId(Guid id)
        {
            var issue = _context.Products.FirstOrDefault(x => x.Id == id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost("api/addproduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddProducts(Entity.Product issue)
        {
            if (issue == null) return BadRequest("404");
            _context.Products.Add(issue);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetbyId), new { id = issue.Id }, issue);
        }

        [HttpGet("api/{name}")]
        [ProducesResponseType(typeof(Entity.Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetbyName(string name)
        {
            var issue = _context.Products.FirstOrDefault(x => x.Name == name);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPut("api/updateproduct/{model}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateProduct(Entity.Product model)
        {
            var issue = _context.Products.FirstOrDefault(x => x.Id == model.Id);
            if (issue == null) return NotFound();
            issue.Name = model.Name;
            issue.Color = model.Color;
            issue.Type = model.Type;
            _context.SaveChanges();
            return Ok();
        }
    }
}
