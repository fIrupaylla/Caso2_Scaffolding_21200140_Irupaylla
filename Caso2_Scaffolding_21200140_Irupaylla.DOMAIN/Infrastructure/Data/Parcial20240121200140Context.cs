using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Infrastructure.Data;

public partial class Parcial20240121200140Context : DbContext
{
    public Parcial20240121200140Context()
    {
    }

    public Parcial20240121200140Context(DbContextOptions<Parcial20240121200140Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Movies> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=localhost;Database=Parcial202401-21200140;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movies>(entity =>
        {
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReleaseYear)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
