using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NWApi.Model;

namespace NWApi.Context
{
    public class NWContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public NWContext(DbContextOptions options) : base(options) { }

    }
}
