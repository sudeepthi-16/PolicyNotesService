using PolicyNotesService.Models;
using PolicyNotesService.Repositories;
namespace PolicyNotesService.Services
{
    public class PolicyNotesServices :IPolicyNotesServices
    {
        public readonly IPolicyNotesRepository _repo;
        public PolicyNotesServices(IPolicyNotesRepository repo)
        {
            _repo = repo;
        }

        public async Task<PolicyNote> CreateNoteAsync(string PolicyNumber, string note)
        {
            var newNote = new PolicyNote
            {
                PolicyNumber = PolicyNumber,
                Note = note,
                
            };
            return await _repo.AddSync(newNote);
        }
        public async Task<List<PolicyNote>> GetNotesAsync(){ 
            return await _repo.GetAllAsync();
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
        public async Task<PolicyNote?> GetNoteByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
