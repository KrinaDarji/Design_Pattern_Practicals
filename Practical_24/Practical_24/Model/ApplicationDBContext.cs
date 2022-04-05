using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_24.Model
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opts) : base(opts)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
