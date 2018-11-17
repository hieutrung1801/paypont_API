using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaypontAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaypontAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private PaypontDbContext _context;

        public CustomerController(PaypontDbContext context)
        {
            _context = context;

            if (_context.Customer.Count() == 0)
            {
                _context.Customer.Add(new Customer() {FirstName = "Test", SureName = "Customer"});
                _context.SaveChanges();
            }

        }

        // GET: api/<controller>
        [HttpGet(Name = "Customer")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomer()
        {
            return _context.Customer.ToList();
        }

        // GET api/<controller>/5
        [HttpGet(("{id}"), Name = "GetCustomerById")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return customer;
        }

        // POST api/<controller>
        [HttpPost(Name = "Customer")]
        public IActionResult Create(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return CreatedAtRoute("GetCustomerById", new {id = customer.Id}, customer);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
