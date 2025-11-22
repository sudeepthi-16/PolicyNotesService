using PolicyNotesService.Models;
namespace PolicyNotesService.Repositories
{
    public interface IPolicyNotesRepository
    {
        Task<PolicyNote> AddSync(PolicyNote note);
        Task<List<PolicyNote>> GetAllAsync();
        Task<PolicyNote?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);

    }
}
