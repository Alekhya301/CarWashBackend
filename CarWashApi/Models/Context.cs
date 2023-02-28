using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Models
{
    public class Context : DbContext
    {
         public Context(DbContextOptions<Context> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }

        public DbSet<Packages> Packages { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Orders> Orders { get; set; }





    }
}
