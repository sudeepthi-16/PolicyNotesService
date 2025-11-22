using PolicyNotesService.Models;

namespace PolicyNotesService.Services
{
    public interface IPolicyNotesServices
    {
        Task<PolicyNote> CreateNoteAsync(string PolicyNumber, string note);
        Task<List<PolicyNote>> GetNotesAsync();
        Task<PolicyNote?> GetNoteByIdAsync(int id);

        Task<bool> DeleteNoteAsync(int id);
    }
}
