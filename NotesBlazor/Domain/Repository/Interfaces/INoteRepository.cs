using Domain.Model;

namespace Domain.Repository.Interfaces
{
   public interface INoteRepository
   {
         Task<List<Note>> GetAllNotesAsync();
         Task<bool> AddNewNotesAsync(Note note);
         Task<Note> GetNoteByIdAsync(int id);
         Task<bool> UpdateNoteContentAsync(Note note);
         Task<bool> DeleteNoteAsync(Note note);
   }
}
