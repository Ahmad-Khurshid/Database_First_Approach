using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirstApproach.Models
{
    public partial class LibraryManagementSystemContext : DbContext
    {
        public LibraryManagementSystemContext()
        {
        }

        public LibraryManagementSystemContext(DbContextOptions<LibraryManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BooksAwardingEmployee> BooksAwardingEmployees { get; set; } = null!;
        public virtual DbSet<Bookscategory> Bookscategories { get; set; } = null!;
        public virtual DbSet<IssuedBooksDetail> IssuedBooksDetails { get; set; } = null!;
        public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.Property(e => e.AuthorId)
                    .ValueGeneratedNever()
                    .HasColumnName("author_id");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("author_name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("book_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.AvailableCopies).HasColumnName("available_copies");

                entity.Property(e => e.BookName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("book_name");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.TotalCopies).HasColumnName("total_copies");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__books__author_id__4D94879B");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__books__category___4E88ABD4");
            });

            modelBuilder.Entity<BooksAwardingEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__books aw__C52E0BA8589DCEE0");

                entity.ToTable("books awarding employees");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.EmployeeName)
                    .IsUnicode(false)
                    .HasColumnName("employee_name");
            });

            modelBuilder.Entity<Bookscategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__bookscat__D54EE9B421F66E13");

                entity.ToTable("bookscategory");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<IssuedBooksDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("issued_books_details");

                entity.Property(e => e.AwardingEmployeeId).HasColumnName("awarding_employee_id");

                entity.Property(e => e.IssuanceDate)
                    .HasColumnType("date")
                    .HasColumnName("issuance_date");

                entity.Property(e => e.IssuedBookId).HasColumnName("issued_book_id");

                entity.Property(e => e.ReturnedDate)
                    .HasColumnType("date")
                    .HasColumnName("returned_date");

                entity.Property(e => e.ReturnedStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("returned_status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AwardingEmployee)
                    .WithMany()
                    .HasForeignKey(d => d.AwardingEmployeeId)
                    .HasConstraintName("FK__issued_bo__award__5441852A");

                entity.HasOne(d => d.IssuedBook)
                    .WithMany()
                    .HasForeignKey(d => d.IssuedBookId)
                    .HasConstraintName("FK__issued_bo__issue__5535A963");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__issued_bo__user___5629CD9C");
            });

            modelBuilder.Entity<RegisteredUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__register__B9BE370F7711BEA8");

                entity.ToTable("registered_users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.UserContact)
                    .IsUnicode(false)
                    .HasColumnName("user_contact");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserRegistrationDate)
                    .HasColumnType("date")
                    .HasColumnName("user_registration_date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
