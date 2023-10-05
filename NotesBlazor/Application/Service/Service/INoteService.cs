using Domain.Model;

namespace Application.Service.Service
{
    public interface INoteService 
    {
        Task<List<Note>> GetAllNotes();
        Task<bool> AddNewNotes(Note note);
        Task<Note> GetNoteById(int id);
        Task<bool> UpdateNoteContent(Note note);
        Task<bool> DeleteNote(Note note);
    }
}
