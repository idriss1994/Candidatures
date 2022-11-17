using Candidatures.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidatures.Data
{
    public class CandidatureDbContext : DbContext
    {
        public CandidatureDbContext(DbContextOptions<CandidatureDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidature> Candidatures { get; set; }
    }
}
