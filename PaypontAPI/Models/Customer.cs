using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaypontAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }
    }
}
