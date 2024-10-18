using System;
using Microsoft.EntityFrameworkCore;

namespace EventEase2024.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions <AppDbContext> options) : base(options) { }

        public DbSet <Evento> Eventos { get; set; }

    }
}
