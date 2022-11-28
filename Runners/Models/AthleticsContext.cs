using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Runners.Models;

public partial class AthleticsContext : DbContext
{
    public AthleticsContext()
    {
    }

    public AthleticsContext(DbContextOptions<AthleticsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Runner> Runners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost; database=Athletics; integrated security=true; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Runner>(entity =>
        {
            entity.ToTable("runner");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Minutes).HasColumnName("minutes");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Seconds).HasColumnName("seconds");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
