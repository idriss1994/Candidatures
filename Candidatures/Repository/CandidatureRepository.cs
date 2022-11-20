using Candidatures.Data;
using Candidatures.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidatures.Repository
{
    public class CandidatureRepository : ICandidatureRepository
    {
        private readonly CandidatureDbContext _dbContext;

        public CandidatureRepository(CandidatureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCandidatureAsync(Candidature candidature)
        {
            await _dbContext.Candidatures.AddAsync(candidature);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCandidatureAsync(Guid id)
        {
            var candidature = await FindCandidatureByIdAsync(id);
            if (candidature != null)
            {
                _dbContext.Candidatures.Remove(candidature);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Candidature> FindCandidatureByIdAsync(Guid id)
        {
            return await _dbContext.Candidatures.FindAsync(id);
        }

        public async Task<IEnumerable<Candidature>> GetAllCandidaturesAsync()
        {
            return  await _dbContext.Candidatures.ToListAsync();
        }
    }
}
