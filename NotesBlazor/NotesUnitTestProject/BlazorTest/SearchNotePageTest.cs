using Domain.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Bunit;
using Blazor.Pages;

namespace NotesUnitTestProject.BlazorTest
{
    public class SearchNotePageTest
    {
        [Fact]
        public void SearchPageDisplaysFilteredNotes()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();

            using var ctx = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options);

            var notes = new List<Note>
        {
            new Note { Title = "Note 1", Content = "Content 1" },
            new Note { Title = "Note 2", Content = "Content 2" },
            new Note { Title = "Another Note", Content = "Another Content" },
        };

            ctx.Notes.AddRange(notes);
            ctx.SaveChanges();

            using var ctxBunit = new TestContext();
            ctxBunit.Services.AddSingleton(ctx);

            // Act
            var cut = ctxBunit.RenderComponent<SearchNote>();

            var searchInput = cut.Find("input");
            searchInput.Change("Note");

            var searchButton = cut.Find("button");
            searchButton.Click();

            // Assert
            var tableRows = cut.FindAll("table tbody tr");

            Assert.Equal(3, tableRows.Count);
            Assert.Contains("Note 1", tableRows[0].TextContent);
            Assert.Contains("Note 2", tableRows[1].TextContent);
        }
    }
}
