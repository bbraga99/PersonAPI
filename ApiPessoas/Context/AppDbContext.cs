﻿using ApiPessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPessoas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
    }
}
