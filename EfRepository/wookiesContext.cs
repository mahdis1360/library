using Microsoft.EntityFrameworkCore;
using poco;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfRepository
{
    public class wookiesContext : DbContext
    {
        public DbSet<AuthorPoco> authorPocos { get; set; }
        public DbSet<BookPoco> bookPocos { get; set; }
        public DbSet<LoginPoco> loginPocos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-41TMA4UR;Initial Catalog=wookies;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<BookPoco>
                (entity =>
                {
                    entity.HasOne(e => e.authorpoco)
                    .WithMany(b => b.bookPocos)
                    .HasForeignKey(a => a.AutorId);
                }
                );


            modelBuilder.Entity<AuthorPoco>
                (entity =>
                {
                    entity.HasMany(b => b.bookPocos)
                    .WithOne(a => a.authorpoco);



                }
                );





        }
    }
}