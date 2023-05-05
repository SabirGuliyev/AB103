using EF_Step.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Step.DAL
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("server=msi;database=EFCoreAB103;trusted_connection=true;integrated security=true;encrypt=false;");
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
