using GlaaCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GlaaCore.Domain
{
    public class GlaaContext : DbContext
    {
        public GlaaContext() : base()
        { }

        public GlaaContext(DbContextOptions<GlaaContext> options) : base(options)
        { }

        public DbSet<Licence> Licences { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
