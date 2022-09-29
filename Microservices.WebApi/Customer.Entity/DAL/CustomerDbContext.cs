using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Customer.Entity.AppDbContext
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> context) : base(context)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
