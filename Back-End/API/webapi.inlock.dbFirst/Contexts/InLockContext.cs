using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.inlock.dbFirst.Domains;

namespace webapi.inlock.dbFirst.Contexts;

public partial class InLockContext : DbContext
{
    public InLockContext()
    {
    }

    public InLockContext(DbContextOptions<InLockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudio> Estudios { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = NOTE14-S14; Initial Catalog = inlock_games_dbFirst_Manha; User id = sa; pwd = Senai@134; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudio>(entity =>
        {
            entity.HasKey(e => e.IdEstudio).HasName("PK__Estudio__0C3B43553D7DE58F");

            entity.ToTable("Estudio");

            entity.HasIndex(e => e.Nome, "UQ__Estudio__7D8FE3B216B5BB1C").IsUnique();

            entity.Property(e => e.IdEstudio).ValueGeneratedNever();
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.IdJogo).HasName("PK__Jogo__69E08513CD6A2172");

            entity.ToTable("Jogo");

            entity.HasIndex(e => e.Descricao, "UQ__Jogo__008BA9EFBC0FE05A").IsUnique();

            entity.HasIndex(e => e.Nome, "UQ__Jogo__7D8FE3B2355E4CD8").IsUnique();

            entity.Property(e => e.IdJogo).ValueGeneratedNever();
            entity.Property(e => e.DataLancamento).HasColumnType("date");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("smallmoney");

            entity.HasOne(d => d.IdEstudioNavigation).WithMany(p => p.Jogos)
                .HasForeignKey(d => d.IdEstudio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Jogo__IdEstudio__4E88ABD4");
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TiposUsu__CA04062BCE96881A");

            entity.ToTable("TiposUsuario");

            entity.HasIndex(e => e.Titulo, "UQ__TiposUsu__7B406B568D17D27C").IsUnique();

            entity.Property(e => e.IdTipoUsuario).ValueGeneratedNever();
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97C074FCDC");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534E80D6DD5").IsUnique();

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdTipoU__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
