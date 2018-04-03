﻿using Microsoft.EntityFrameworkCore;
using NotesAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Repository.Context
{
    public class NotesContext : DbContext
    {
        public NotesContext()
        {

        }
        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
