using Microsoft.EntityFrameworkCore;
using randomNameGenerator.Models;
using System.Collections.Generic;

namespace randomNameGenerator.Data
{
    public class NameDbContext : DbContext
    {
        public DbSet<Name> Names { get; set; }

        public NameDbContext(DbContextOptions<NameDbContext> ctx) : base(ctx)
        {

        }
    }
}
