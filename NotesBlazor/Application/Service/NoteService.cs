using Application.Service.Service;
using Domain.Model;
using Domain.Repository;
using Domain.Repository.Interfaces;

namespace Application.Service
{
    public class NoteService :  INoteService
    {
        private readonly INoteRepository _repository;
        public NoteService(INoteRepository repository) 
        {
            _repository = repository;
        }

        public async Task<bool> AddNewNotes(Note note)
        {
          return await _repository.AddNewNotes(note);
        }

        public async Task<bool> DeleteNote(Note note)
        {
           return await _repository.DeleteNote(note);
        }

        public async Task<List<Note>> GetAllNotes()
        {
           return await _repository.GetAllNotes();
        }

        public async Task<Note> GetNoteById(int id)
        {
          return await _repository.GetNoteById(id);
        }

        public async Task<bool> UpdateNoteContent(Note note)
        {
            return await _repository.UpdateNoteContent(note);
        }
    }
}
