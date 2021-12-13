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

        public virtual DbSet<m_Sport> Sports { get; set; }
        public virtual DbSet<m_Team> Teams { get; set; }
        public virtual DbSet<m_Player> Player { get; set; }
        public virtual DbSet<m_SportsRepo> US_Sports { get; set; }
    }
}
