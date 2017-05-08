using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Texter.Models
{
    public class TexterContext : IdentityDbContext<ApplicationUser>
    {
        public TexterContext()
        {

        }
        //Creates database tables
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Texter;integrated security=True");
        }

        public TexterContext(DbContextOptions<TexterContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
