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

        public DbSet<DocumentChunk> Chunks => Set<DocumentChunk>();

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

            modelBuilder.Entity<DocumentChunk>(entity =>
            {
                entity.ToTable("document_chunks");

                entity.HasKey(d => d.Id);

                entity.Property(d => d.DocumentId)
                    .HasColumnName("document_id");             

                entity.Property(d => d.Id)
                    .HasColumnName("id");

                entity.Property(d => d.Content)
                    .HasColumnName("content");

                entity.Property(d => d.ChunkIndex)
                    .HasColumnName("chunk_index");

                entity.HasOne(d => d.Document)
                    .WithMany(d => d.Chunks)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.Cascade); ;

                entity.HasIndex(c => new { c.DocumentId, c.ChunkIndex })
                    .IsUnique();


            });
        }
    }

}
