using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaSentry.Models.Db;

public partial class PruebaTecnicaSentryContext : DbContext
{
    public PruebaTecnicaSentryContext()
    {
    }

    public PruebaTecnicaSentryContext(DbContextOptions<PruebaTecnicaSentryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbTask> TbTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-91U7P9L\\SQLEXPRESS; Database=PruebaTecnicaSentry; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Task__3213E83F0085C12D");

            entity.ToTable("tb_Task");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Iscompleted).HasColumnName("iscompleted");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
