using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaypontAPI.Models
{
    public class Customer
    {
        public byte Id { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }
    }
}
