using Microsoft.EntityFrameworkCore;
using RagProject.Domain;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace RagProject.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Document> Documents => Set<Document>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("documents");

                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                    .HasColumnName("id");

                entity.Property(d => d.Title)
                    .HasColumnName("title");

                entity.Property(d => d.Content)
                    .HasColumnName("content");
            });
        }
    }

}
