using Domain.Model;

namespace Application.Service.Service
{
    public interface INoteService 
    {
        Task<List<Note>> GetAllNotesAsync();
        Task<bool> AddNewNotesAsync(Note note);
        Task<Note> GetNoteByIdAsync(int id);
        Task<bool> UpdateNoteContentAsync(Note note);
        Task<bool> DeleteNoteAsync(Note note);
    }
}
