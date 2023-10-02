using Domain.Context;
using Domain.Model;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;
        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }
        // Add New Note
        public async Task<bool> AddNewNotes(Note note)
        {
           
           note.DateCreate = DateTime.Now;
           note.DateCreate = DateTime.SpecifyKind(note.DateCreate, DateTimeKind.Utc);
           await _context.Notes.AddAsync(note);
           await _context.SaveChangesAsync();
           return true;
        }
        //Delete Note Data
        public async Task<bool> DeleteNote(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }
        // Get All Notes List
        public async Task<List<Note>> GetAllNotes()
        {
            return await _context.Notes.ToListAsync();
        }
        // Get Note By Id
        public async Task<Note> GetNoteById(int id)
        {
           Note note = await _context.Notes.FirstOrDefaultAsync(x=> x.Id == id);
            return note;
        }
        // Get Note Data
        public async Task<bool> UpdateNoteContent(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
