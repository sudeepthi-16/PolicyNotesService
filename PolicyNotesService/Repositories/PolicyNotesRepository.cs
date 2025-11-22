using PolicyNotesService.Models;
using PolicyNotesService.Data;
using Microsoft.EntityFrameworkCore;

namespace PolicyNotesService.Repositories
{
    public class PolicyNotesRepository :IPolicyNotesRepository
    {
        private readonly AppDbContext _context;

        public PolicyNotesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PolicyNote> AddSync(PolicyNote note)
        {
            _context.PolicyNotes.Add(note);
            await _context.SaveChangesAsync();
            return note;

        }
        public async Task<List<PolicyNote>> GetAllAsync()
        {
            return await _context.PolicyNotes.ToListAsync();
        }

        //public async Task<PolicyNote?> GetByIdAsync (int Id)
        //{
        //    return await _context.PolicyNotes.FindAsync(Id);
        //}
        public async Task<bool> DeleteAsync(int Id)
        {
            var note = await _context.PolicyNotes.FindAsync(Id);
            if (note == null)
            {
                return false;
            }
            _context.PolicyNotes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<PolicyNote?> GetByIdAsync(int id)
        {
            return await _context.PolicyNotes.FindAsync(id);
        }
    }
}
