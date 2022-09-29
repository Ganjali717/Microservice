using Microsoft.AspNetCore.Mvc;
using System;
using Customer.Entity.AppDbContext;

namespace Customer.Microservice.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerDbContext _context;
        public CustomerController(CustomerDbContext context) => _context = context;

        [HttpGet("api/getallcustomer")]
        public IActionResult GetAllCustomers()
        {
            var issues = _context.Customers.ToList();
            return issues == null ? NotFound() : Ok(issues);
        }

        [HttpGet("api/{id}")]
        [ProducesResponseType(typeof(Entity.Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetbyId(Guid id)
        {
            var issue = _context.Customers.FirstOrDefault(x => x.Id == id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost("api/customeradd")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddCustomers(Entity.Customer issue)
        {
            if (issue == null) return BadRequest("404");
            _context.Customers.Add(issue);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetbyId), new { id = issue.Id }, issue);
        }

        [HttpGet("api/{name}")]
        [ProducesResponseType(typeof(Entity.Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetbyName(string name)
        {
            var issue = _context.Customers.FirstOrDefault(x => x.Name == name);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPut("api/updatecustomer/{model}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCustomer(Entity.Customer model)
        {
            var issue = _context.Customers.FirstOrDefault(x => x.Id == model.Id);
            if (issue == null) return NotFound();
            issue.Name = model.Name;
            issue.Surname = model.Surname;
            issue.Email = model.Email;
            issue.MobilePhone = model.MobilePhone;
            issue.Address = model.Address;
            _context.SaveChanges();
            return Ok();
        }
    }
}
