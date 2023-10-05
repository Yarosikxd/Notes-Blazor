using Application.Service.Service;
using Domain.Model;
using Domain.Repository.Interfaces;

namespace Application.Service
{
    public class NoteService :  INoteService
    {
        public NoteService()
        {
            
        }
        private readonly INoteRepository _repository;
        public NoteService(INoteRepository repository) 
        {
            _repository = repository;
        }

        public virtual async Task<bool> AddNewNotesAsync(Note note)
        {
            try
            {
                return await _repository.AddNewNotesAsync(note);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
          
        }

        public async Task<bool> DeleteNoteAsync(Note note)
        {
            try
            {
                return await _repository.DeleteNoteAsync(note);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
          
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            try
            {
                return await _repository.GetAllNotesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
           
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            try
            {
                return await _repository.GetNoteByIdAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
          
        }

        public async Task<bool> UpdateNoteContentAsync(Note note)
        {
            try
            {
                return await _repository.UpdateNoteContentAsync(note);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
           
        }
    }
}
