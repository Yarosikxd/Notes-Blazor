using Application.Service;
using Blazor.Pages;
using Bunit;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace NotesUnitTestProject.BlazorTest
{
    public class AddNewNotePageTests
    {
        [Fact]
        public void ShouldRenderAddNewNotePage()
        {
            // Arrange
            using var ctx = new TestContext();
            var noteServiceMock = new Mock<NoteService>();
            ctx.Services.AddSingleton(noteServiceMock.Object);

            // Act
            var cut = ctx.RenderComponent<AddNewNote>();

            // Assert
            cut.MarkupMatches(@"  <h3>Add New Note</h3>
            <hr>
            <form>
                <div class=""row"">
                     <div class=""col-md-8"">
                        <div class=""for-group"">
                        <label for=""Name"" class=""control-label"">Title</label>
                     <input form=""Title"" class=""form-control"" >
                </div>
                    <div class=""for-group"">
                    <label for=""Content"" class=""control-label"">Content</label>
                 <input form=""Content"" class=""form-control"" >
             </div>
                    </div>
                    </div>
                     <hr>
                <div class=""row"">
                    <div class=""col-md-4"">
                 <div class=""form-group"">
                    <input type=""button"" class=""btn btn-primary btn-sm""  value=""Save Note"">
                    <input type=""button"" class=""btn btn-danger btn-sm""  value=""Cancel"">
                    </div>
                </div>
             </div>
            </form>");
        }

        [Fact]
        public void ShouldCreateNewNote()
        {
            // Arrange
            using var ctx = new TestContext();
            var noteServiceMock = new Mock<NoteService>();
            ctx.Services.AddSingleton(noteServiceMock.Object);

            var cut = ctx.RenderComponent<AddNewNote>();

            // Act
            cut.Find("input[form='Title']").Change("Test Title");
            cut.Find("input[form='Content']").Change("Test Content");
            cut.Find("input[value='Save Note']").Click();

            // Assert
            noteServiceMock.Verify(ns => ns.AddNewNotes(It.IsAny<Note>()), Times.Once);
            Assert.Equal("Test Title", cut.Instance.obj.Title);
            Assert.Equal("Test Content", cut.Instance.obj.Content);
        }
    }
}
