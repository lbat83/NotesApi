using Microsoft.EntityFrameworkCore;
using NotesAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Repository.Context
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {

        }
        public NotesContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.Property(c => c.Id).HasColumnName("ID");

                category.Property(c => c.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Notes>(notes =>
            {   
                notes.Property(n => n.Id).HasColumnName("ID");

                notes.Property(n => n.Title).HasMaxLength(50);

                notes.Property(n => n.Note).HasMaxLength(50);

                notes.Property(n => n.CreatedOn).HasColumnType("datetime");

                notes.Property(n => n.IsDeleted).HasColumnType("boolean");

                

            });

            modelBuilder.Entity<User>(user =>
            {
                user.Property(u => u.Id).HasColumnName("ID");

                user.Property(u => u.CreatedOn).HasColumnType("datetime");

                user.Property(u => u.Email).HasMaxLength(50);

                user.Property(u => u.Name).HasMaxLength(50);
            });
        }

     
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Category> Category { get; set; }
    }
}
