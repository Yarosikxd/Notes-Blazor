using Application.Service.Service;
using Domain.Context;
using Domain.Repository;


namespace Application.Service
{
    public class NoteService : NoteRepository, INoteService
    {
        private readonly AppDbContext _context;
        public NoteService(AppDbContext context) : base(context)
        {
        }
    }
}
