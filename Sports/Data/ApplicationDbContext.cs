using Microsoft.EntityFrameworkCore;
using SportsLib.US_Sports;
using SportsMVC.Models;
using System;

namespace SportsMVC.Data
{
    // create db connection
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<m_Sport> Sports { get; set; }
        public DbSet<m_Team> Teams { get; set; }
        public DbSet<m_Player> Player { get; set; }
        public DbSet<m_SportsRepo> US_Sports { get; set; }
    }
}
