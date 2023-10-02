using Domain.Model;

namespace Domain.Repository.Interfaces
{
   public interface INoteRepository
   {
         Task<List<Note>> GetAllNotes();
         Task<bool> AddNewNotes(Note note);
         Task<Note> GetNoteById(int id);
         Task<bool> UpdateNoteContent(Note note);
         Task<bool> DeleteNote(Note note);
   }
}
