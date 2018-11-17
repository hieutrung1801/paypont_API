using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PaypontAPI.Models
{
    public class PaypontDbContext : DbContext
    {
        public PaypontDbContext(DbContextOptions<PaypontDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
    }
}
