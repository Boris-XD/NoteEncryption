using System;
using Dev33.UltimateTeam.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dev33.UltimateTeam.Infrastructure.Context
{
    public partial class SafeInformationDBContext : DbContext
    {
        public SafeInformationDBContext()
        {
        }

        public SafeInformationDBContext(DbContextOptions<SafeInformationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Container> Containers { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Information> Informations { get; set; }
        public virtual DbSet<Key> Keys { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<ShareInformation> ShareInformations { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Url> Urls { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Addresses_Informations_ContactId");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.InformationsId);

                entity.Property(e => e.InformationsId).ValueGeneratedNever();

                entity.HasOne(d => d.Informations)
                    .WithOne(p => p.Contact)
                    .HasForeignKey<Contact>(d => d.InformationsId);
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.ToTable("Container");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Containers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => e.InformationsId);

                entity.Property(e => e.InformationsId).ValueGeneratedNever();

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Informations)
                    .WithOne(p => p.Credential)
                    .HasForeignKey<Credential>(d => d.InformationsId);
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.InformationsId);

                entity.Property(e => e.InformationsId).ValueGeneratedNever();

                entity.Property(e => e.Cvv).IsUnicode(false);

                entity.Property(e => e.Issuer).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Number).IsUnicode(false);

                entity.HasOne(d => d.Informations)
                    .WithOne(p => p.CreditCard)
                    .HasForeignKey<CreditCard>(d => d.InformationsId);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.ContactId);
            });

            modelBuilder.Entity<Information>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Container)
                    .WithMany(p => p.Information)
                    .HasForeignKey(d => d.ContainerId)
                    .HasConstraintName("FK_Informations_Containers_ContainerId");
            });

            modelBuilder.Entity<Key>(entity =>
            {
                entity.HasKey(e => e.InformationsId);

                entity.Property(e => e.InformationsId).ValueGeneratedNever();

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Informations)
                    .WithOne(p => p.Key)
                    .HasForeignKey<Key>(d => d.InformationsId);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.InformationsId);

                entity.Property(e => e.InformationsId).ValueGeneratedNever();

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.Informations)
                    .WithOne(p => p.Note)
                    .HasForeignKey<Note>(d => d.InformationsId);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Phones_Contacts_InformationsId");
            });

            modelBuilder.Entity<ShareInformation>(entity =>
            {
                entity.HasKey(e => e.GuessId)
                    .HasName("PK__ShareInf__0B84EA59B59511F1");

                entity.Property(e => e.GuessId).ValueGeneratedNever();

                entity.HasOne(d => d.Guess)
                    .WithOne(p => p.ShareInformation)
                    .HasForeignKey<ShareInformation>(d => d.GuessId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Information)
                    .WithMany(p => p.ShareInformations)
                    .HasForeignKey(d => d.InformationId)
                    .HasConstraintName("FK_ShareInformations_Informations_InformationsId");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Information)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.InformationId)
                    .HasConstraintName("FK_Tags_Informations_InformationsId");
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Credential)
                    .WithMany(p => p.Urls)
                    .HasForeignKey(d => d.CredentialId)
                    .HasConstraintName("FK_Url_Credentials_CredentialId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
