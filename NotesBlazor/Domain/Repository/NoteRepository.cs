using Domain.Context;
using Domain.Model;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly IDbContext _context;
        public NoteRepository(IDbContext context)
        {
            _context = context;
        }
        // Add New Note
        public async Task<bool> AddNewNotesAsync(Note note)
        {
           note.DateCreate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
           await _context.Notes.AddAsync(note);
           await _context.SaveChangesAsync();
           return true;
        }
        //Delete Note Data
        public async Task<bool> DeleteNoteAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }
        // Get All Notes List
        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }
        // Get Note By Id
        public async Task<Note> GetNoteByIdAsync(int id)
        {
           Note note = await _context.Notes.FirstOrDefaultAsync(x=> x.Id == id);
            return note;
        }
        // Get Note Data
        public async Task<bool> UpdateNoteContentAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
