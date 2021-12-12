using Microsoft.EntityFrameworkCore;
using System;

namespace SportsMVC.Data
{
    // create db connection
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
