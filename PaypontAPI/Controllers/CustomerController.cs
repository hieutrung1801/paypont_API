using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaypontAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaypontAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CustomerController : ControllerBase
    {
        private PaypontDbContext _context;

        public CustomerController(PaypontDbContext context)
        {
            _context = context;

            if(_context.Customer.Count() == 0)
            {
                _context.Customer.Add(new Customer() {FirstName = "Test", SurName = "Customer"});
                _context.SaveChanges();
            }

        }


        // GET: api/<controller>

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomer()
        {
            return _context.Customer.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id:int}", Name = "GetById")]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = _context.Customer.Find(id);
            if (customer == null)
                return NotFound();
            return customer;
        }

        // Get api/<controller>/{firstname}
        [HttpGet("{surName}")]
        [EnableCors("CorsPolicy")]
        public ActionResult<List<Customer>> GetByName(string surName)
        {
            var result = new List<Customer>();
            var customerList = _context.Customer.ToList();
            foreach(var customer in customerList)
            {

                if (string.Equals(customer.SurName, surName))
                    result.Add(customer);
            }

            if (result.Count == 0)
                return NotFound();
            
            return result;
        }
        // POST api/<controller>
        [HttpPost(Name = "customer")]
        [IgnoreAntiforgeryToken]
        [EnableCors("CorsPolicy")]

        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
            
            return CreatedAtRoute("GetById", new {id = customer.Id}, customer);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]

        public void Delete(int id)
        {
        }
    }
}
