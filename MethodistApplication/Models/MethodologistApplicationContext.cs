using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MethodistApplication;

public partial class MethodologistApplicationContext : DbContext
{
    public MethodologistApplicationContext()
    {
    }

    public MethodologistApplicationContext(DbContextOptions<MethodologistApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employeer> Employeers { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=methodologist_application;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employeer>(entity =>
        {
            entity.HasKey(e => e.EmployeersId).HasName("employeers_pkey");

            entity.ToTable("employeers");

            entity.HasIndex(e => e.Email, "employeers_email_key").IsUnique();

            entity.HasIndex(e => e.Inn, "employeers_inn_key").IsUnique();

            entity.HasIndex(e => e.NumberPhone, "employeers_number_phone_key").IsUnique();

            entity.Property(e => e.EmployeersId).HasColumnName("employeers_id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .HasColumnName("account_number");
            entity.Property(e => e.DateBirth).HasColumnName("dateBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("inn");
            entity.Property(e => e.IssuidBy)
                .HasMaxLength(120)
                .HasColumnName("issuid_by");
            entity.Property(e => e.NameBank)
                .HasMaxLength(30)
                .HasColumnName("name_bank");
            entity.Property(e => e.NumberPassport)
                .HasMaxLength(6)
                .HasColumnName("number_passport");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(20)
                .HasColumnName("number_phone");
            entity.Property(e => e.NumberSnils)
                .HasMaxLength(14)
                .HasColumnName("number_snils");
            entity.Property(e => e.RankId).HasColumnName("rank_id");
            entity.Property(e => e.RegistrationAddres)
                .HasMaxLength(200)
                .HasColumnName("registration_addres");
            entity.Property(e => e.SecondName)
                .HasMaxLength(30)
                .HasColumnName("second_name");
            entity.Property(e => e.SerialPassport)
                .HasMaxLength(4)
                .HasColumnName("serial_passport");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.WhenIssued).HasColumnName("when_issued");

            entity.HasOne(d => d.Rank).WithMany(p => p.Employeers)
                .HasForeignKey(d => d.RankId)
                .HasConstraintName("employeers_rank_id_fkey");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleId).HasName("job_titles_pkey");

            entity.ToTable("job_titles");

            entity.HasIndex(e => e.JobTitle1, "job_titles_job_title_key").IsUnique();

            entity.Property(e => e.JobTitleId).HasColumnName("job_title_id");
            entity.Property(e => e.JobTitle1)
                .HasMaxLength(20)
                .HasColumnName("job_title");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => e.RankId).HasName("ranks_pkey");

            entity.ToTable("ranks");

            entity.HasIndex(e => e.NameRank, "ranks_name_rank_key").IsUnique();

            entity.Property(e => e.RankId).HasColumnName("rank_id");
            entity.Property(e => e.NameRank)
                .HasMaxLength(30)
                .HasColumnName("name_rank");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.LoginUser, "users_login_user_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.JobTitleId).HasColumnName("job_title_id");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(20)
                .HasColumnName("login_user");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(30)
                .HasColumnName("password_user");
            entity.Property(e => e.SecondName)
                .HasMaxLength(30)
                .HasColumnName("second_name");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.Users)
                .HasForeignKey(d => d.JobTitleId)
                .HasConstraintName("users_job_title_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
