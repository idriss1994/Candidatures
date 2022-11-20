using Candidatures.Models;

namespace Candidatures.Repository
{
    public interface ICandidatureRepository
    {
        Task AddCandidatureAsync(Candidature candidature);
        Task DeleteCandidatureAsync(Guid id);
        Task<IEnumerable<Candidature>> GetAllCandidaturesAsync();
        Task<Candidature> FindCandidatureByIdAsync(Guid id);
    }
}
