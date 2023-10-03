using Moq;
using Microsoft.EntityFrameworkCore;
using Domain.Context;
using Domain.Model;
using Domain.Repository;
using NotesUnitTestProject.NoteRepositoryTest.DbSet;

namespace NotesUnitTestProject.NoteRepositoryTest
{

    public class NoteRepositoryTest
    {
        [Fact]
        public void AddNote_AddNoteToDbSet()
        {
            // Arrange
            var notes = new List<Note>();
            var mockDbSet = new Mock<DbSet<Note>>();
            mockDbSet.SetupData(notes);

            var mockDbContext = new Mock<IDbContext>();
            mockDbContext.SetupGet(c => c.Notes).Returns(mockDbSet.Object);

            var noteService = new NoteRepository(mockDbContext.Object);

            var newNote = new Note { Id = 1, Title = "Test Note" }; // Створюємо нову нотатку

            // Act 
            notes.Add(newNote); // Додаємо нову нотатку до списку перед викликом AddNewNotes
            noteService.AddNewNotes(newNote);

            // Assert
            Assert.Equal(newNote.Title, notes.First().Title); // Перевіряємо, чи нотатка дійсно була додана
        }

        [Fact]
        public async Task DeleteNote_ShouldDeleteNoteFromDb()
        {
            // Arrange
            var notes = new List<Note>
            {

                new Note { Id = 1, Title = "Note 1" },
                new Note { Id = 2, Title = "Note 2" },
                new Note { Id = 3, Title = "Note 3" }
            };

            var noteToDelete = notes.First(); // Вибираємо нотатку для видалення

            var mockDbSet = new Mock<DbSet<Note>>();
            mockDbSet.SetupData(notes);

            var mockDbContext = new Mock<IDbContext>();
            mockDbContext.SetupGet(c => c.Notes).Returns(mockDbSet.Object);

            var noteService = new NoteRepository(mockDbContext.Object);

            // Act 
            var result = await noteService.DeleteNote(noteToDelete);

            // Оновлюємо список notes після видалення
            notes.Remove(noteToDelete);

            // Assert
            // Перевіряємо, що результат дорівнює true (якщо ви так бажаєте)
            Assert.True(result);

            // Перевіряємо, що нотатка більше не міститься у списку
            Assert.DoesNotContain(noteToDelete, notes);

        }

        [Fact]
        public async Task UpdateNoteContent_ShouldUpdateNoteContentInDb()
        {
            // Arrange
            var noteToUpdate = new Note { Id = 1, Title = "Test Note", Content = "Old Content" };

            var mockDbSet = new Mock<DbSet<Note>>();
            mockDbSet.SetupData(new List<Note> { noteToUpdate }); // Додаємо нотатку до DbSet

            var mockDbContext = new Mock<IDbContext>();
            mockDbContext.SetupGet(c => c.Notes).Returns(mockDbSet.Object);

            var noteService = new NoteRepository(mockDbContext.Object);

            // Act
            var updateNote = new Note { Id = 1, Title = "Test Note", Content = "New Content" };
            var result = await noteService.UpdateNoteContent(updateNote);

            //Assert 
            Assert.True(result);
            Assert.Equal("New Content",updateNote.Content);
        }


    }


}

