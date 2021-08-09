using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCoreBulkTest.Models;

namespace EFCoreBulkTest.Data
{
    public class EfCoreBulkTestContext : DbContext
    {
        public EfCoreBulkTestContext(DbContextOptions<EfCoreBulkTestContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(c => c.Id)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder.Entity<Student>()
                .Property(c => c.Id)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder.Entity<Book>()
                .Property(c => c.Id)
                .HasDefaultValueSql("newsequentialid()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
