using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VolunteerCenters.Models;

namespace VolunteerCenters;

public partial class BdVolunteerCentersContext : DbContext
{
    public BdVolunteerCentersContext()
    {
    }

    public BdVolunteerCentersContext(DbContextOptions<BdVolunteerCentersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Doing> Doings { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<RegistrationStatus> RegistrationStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteerRegistration> VolunteerRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=bd_volunteer_centers;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameCategori).HasColumnName("name_categori");
        });

        modelBuilder.Entity<Doing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doings_pkey");

            entity.ToTable("doings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateDoing).HasColumnName("date_doing");
            entity.Property(e => e.IdCategori)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_categori");
            entity.Property(e => e.IdEvent)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_event");
            entity.Property(e => e.IdEventStatus)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_event_status");
            entity.Property(e => e.IdUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_user");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.VolunteersNeeded).HasColumnName("volunteers_needed");

            entity.HasOne(d => d.Category).WithMany(p => p.Doings)
                .HasForeignKey(d => d.IdCategori)
                .HasConstraintName("doings_id_categori_fkey");

            entity.HasOne(d => d.Event).WithMany(p => p.Doings)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("doings_id_event_fkey");

            entity.HasOne(d => d.EventStatus).WithMany(p => p.Doings)
                .HasForeignKey(d => d.IdEventStatus)
                .HasConstraintName("doings_id_event_status_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Doings)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("doings_id_user_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameEvent).HasColumnName("name_event");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_statuses_pkey");

            entity.ToTable("event_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameEventStatus).HasColumnName("name_event_status");
        });

        modelBuilder.Entity<RegistrationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registration_statuses_pkey");

            entity.ToTable("registration_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameRegistrationStatus).HasColumnName("name_registration_status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameRole).HasColumnName("name_role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IdRole)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("users_id_role_fkey");
        });

        modelBuilder.Entity<VolunteerRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("volunteer_registrations_pkey");

            entity.ToTable("volunteer_registrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEvent)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_event");
            entity.Property(e => e.IdRegistrationStatus)
                .HasDefaultValueSql("nextval('volunteer_registrations_id_volunteer_registration_seq'::regclass)")
                .HasColumnName("id_registration_status");
            entity.Property(e => e.IdUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_user");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

            entity.HasOne(d => d.Event).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("volunteer_registrations_id_event_fkey");

            entity.HasOne(d => d.RegistrationStatus).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdRegistrationStatus)
                .HasConstraintName("volunteer_registrations_id_volunteer_registration_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.VolunteerRegistrations)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("volunteer_registrations_id_user_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
