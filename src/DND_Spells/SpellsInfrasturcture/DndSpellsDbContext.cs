using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpellsDomain.Model;

namespace SpellsInfrasturcture;

public partial class DndSpellsDbContext : DbContext
{
    public DndSpellsDbContext()
    {
    }

    public DndSpellsDbContext(DbContextOptions<DndSpellsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<AreaType> AreaTypes { get; set; }

    public virtual DbSet<Attack> Attacks { get; set; }

    public virtual DbSet<AttackType> AttackTypes { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<CastingTimeType> CastingTimeTypes { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Duration> Durations { get; set; }

    public virtual DbSet<DurationType> DurationTypes { get; set; }

    public virtual DbSet<Effect> Effects { get; set; }

    public virtual DbSet<EffectType> EffectTypes { get; set; }

    public virtual DbSet<MaterialComponent> MaterialComponents { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<RangeType> RangeTypes { get; set; }

    public virtual DbSet<SchoolOfMagic> SchoolOfMagics { get; set; }

    public virtual DbSet<Spell> Spells { get; set; }

    public virtual DbSet<SpellAccess> SpellAccesses { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=FYODOR-PC\\SQLEXPRESS; Database=DND_Spells_DB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.ToTable("Area");

            entity.Property(e => e.Id).HasColumnName("area_id");
            entity.Property(e => e.AreaSize).HasColumnName("area_size");
            entity.Property(e => e.AreaTypeId).HasColumnName("area_type_id");

            entity.HasOne(d => d.AreaType).WithMany(p => p.Areas)
                .HasForeignKey(d => d.AreaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Area_Area-Type");
        });

        modelBuilder.Entity<AreaType>(entity =>
        {
            entity.ToTable("Area-Type");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("area_type_id");
            entity.Property(e => e.Label)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("label");

        });

        modelBuilder.Entity<Attack>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AttackTypeId).HasColumnName("attack_type_id");
            entity.Property(e => e.SpellId).HasColumnName("spell_id");

            entity.HasOne(d => d.AttackType).WithMany()
                .HasForeignKey(d => d.AttackTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attacks_Attack-Type");

            entity.HasOne(d => d.Spell).WithMany()
                .HasForeignKey(d => d.SpellId)
                .HasConstraintName("FK_Attacks_Spells");
        });

        modelBuilder.Entity<AttackType>(entity =>
        {
            entity.ToTable("Attack-Type");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("attack_type_id");
            entity.Property(e => e.Label)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("book_id");
            entity.Property(e => e.Short)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("short");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<CastingTimeType>(entity =>
        {
            entity.ToTable("Casting-Time-Type");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("casting_time_type_id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("class_id");
            entity.Property(e => e.Label)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Duration>(entity =>
        {
            entity.ToTable("Duration");

            entity.Property(e => e.Id).HasColumnName("duration_id");
            entity.Property(e => e.Concentration).HasColumnName("concentration");
            entity.Property(e => e.Dismissable).HasColumnName("dismissable");
            entity.Property(e => e.DurationTypeId).HasColumnName("duration_type_id");

            entity.HasOne(d => d.DurationType).WithMany(p => p.Durations)
                .HasForeignKey(d => d.DurationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Duration_Duration-Type");
        });

        modelBuilder.Entity<DurationType>(entity =>
        {
            entity.ToTable("Duration-Type");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("duration_type_id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Effect>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EffectTypeId).HasColumnName("effect_type_id");
            entity.Property(e => e.Id).HasColumnName("spell_id");

            entity.HasOne(d => d.EffectType).WithMany()
                .HasForeignKey(d => d.EffectTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Effects_Effect-Type");

            entity.HasOne(d => d.Spell).WithMany()
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_Effects_Spells");
        });

        modelBuilder.Entity<EffectType>(entity =>
        {
            entity.ToTable("Effect-Type");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("effect_type_id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<MaterialComponent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Material-Components");

            entity.Property(e => e.Consumed).HasColumnName("consumed");
            entity.Property(e => e.MaterialTypeId).HasColumnName("material_type_id");
            entity.Property(e => e.SpellId).HasColumnName("spell_id");
            entity.Property(e => e.WorthCopper).HasColumnName("worth_copper");

            entity.HasOne(d => d.MaterialType).WithMany()
                .HasForeignKey(d => d.MaterialTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Material-Components_Material-Type");

            entity.HasOne(d => d.Spell).WithMany()
                .HasForeignKey(d => d.SpellId)
                .HasConstraintName("FK_Material-Components_Spells");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.ToTable("Material-Type");

            entity.Property(e => e.Id).HasColumnName("material_type_id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<RangeType>(entity =>
        {
            entity.ToTable("Range-Type");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("range_type_id");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("label");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<SchoolOfMagic>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("School-of-Magic");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("school_id");
            entity.Property(e => e.Label)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasIndex(e => e.AreaId, "UQ_Spells_area-id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("spell_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CastingTimeTypeId).HasColumnName("casting_time_type_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DurationId).HasColumnName("duration_id");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Material).HasColumnName("material");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RangeTypeId).HasColumnName("range_type_id");
            entity.Property(e => e.Ritual).HasColumnName("ritual");
            entity.Property(e => e.SchoolId).HasColumnName("school_id");
            entity.Property(e => e.Somatic).HasColumnName("somatic");
            entity.Property(e => e.Verbal).HasColumnName("verbal");

            entity.HasOne(d => d.Area).WithOne(p => p.Spell)
                .HasForeignKey<Spell>(d => d.AreaId)
                .HasConstraintName("FK_Spells_Area");

            entity.HasOne(d => d.Book).WithMany(p => p.Spells)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_Spells_Books");

            entity.HasOne(d => d.CastingTimeType).WithMany(p => p.Spells)
                .HasForeignKey(d => d.CastingTimeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spells_Casting-Time-Type");

            entity.HasOne(d => d.Duration).WithMany(p => p.Spells)
                .HasForeignKey(d => d.DurationId)
                .HasConstraintName("FK_Spells_Duration");

            entity.HasOne(d => d.RangeType).WithMany(p => p.Spells)
                .HasForeignKey(d => d.RangeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spells_Range-Type");

            entity.HasOne(d => d.School).WithMany(p => p.Spells)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spells_School-of-Magic");
        });

        modelBuilder.Entity<SpellAccess>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Spell-Access");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.SpellId).HasColumnName("spell_id");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spell-Access_Books");

            entity.HasOne(d => d.Class).WithMany()
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Spell-Access_Class");

            entity.HasOne(d => d.Spell).WithMany()
                .HasForeignKey(d => d.SpellId)
                .HasConstraintName("FK_Spell-Access_Spells");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Id)
                //.ValueGeneratedOnAdd()
                .HasColumnName("status_id");
            entity.Property(e => e.Label)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("label");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("user_id");
            entity.Property(e => e.Hash)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("hash");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
