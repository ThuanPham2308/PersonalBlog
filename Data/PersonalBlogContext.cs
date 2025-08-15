using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Data;

public partial class PersonalBlogContext : DbContext
{
    public PersonalBlogContext()
    {
    }

    public PersonalBlogContext(DbContextOptions<PersonalBlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=THUAN-PHAM\\SQL2022;Initial Catalog=PersonalBlog;Persist Security Info=True;User ID=sa;Password=thuan23082004;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__About__3214EC07CAEF2732");

            entity.ToTable("About");

            entity.Property(e => e.Age).HasComputedColumnSql("(datediff(year,[Birthday],getdate())-case when datepart(month,[Birthday])>datepart(month,getdate()) OR datepart(month,[Birthday])=datepart(month,getdate()) AND datepart(day,[Birthday])>datepart(day,getdate()) then (1) else (0) end)", false);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Degree).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Facebook)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Freelance).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Github)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Instagram)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Job).HasMaxLength(100);
            entity.Property(e => e.Linkedin)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProfileImage)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blog__3214EC07CB2995CA");

            entity.ToTable("Blog");

            entity.Property(e => e.Summary).HasMaxLength(500);
            entity.Property(e => e.Tag).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC075F0FF17A");

            entity.ToTable("Education");

            entity.Property(e => e.EndYear).HasMaxLength(255);
            entity.Property(e => e.StartYear).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC07924BBD88");

            entity.ToTable("Experience");

            entity.Property(e => e.EndYear).HasMaxLength(255);
            entity.Property(e => e.StartYear).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Portfoli__3214EC07F072C6F2");

            entity.ToTable("Portfolio");

            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC072147C790");

            entity.ToTable("Service");

            entity.Property(e => e.Icon).HasMaxLength(255);
            entity.Property(e => e.ServiceName).HasMaxLength(255);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC0731C93090");

            entity.Property(e => e.SkillName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
