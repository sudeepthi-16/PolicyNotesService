using PolicyNotesService.Models;
using PolicyNotesService.Repositories;
using PolicyNotesService.Services;
using Moq;

public class PolicyNotesServiceTests
{
    [Fact]
    public async Task CreateNoteAsync_ShouldAddNote()
    {
        // ARRANGE
        var mockRepo = new Mock<IPolicyNotesRepository>();
        var service = new PolicyNotesServices(mockRepo.Object);

        var noteToReturn = new PolicyNote
        {
            Id = 1,
            PolicyNumber = "P101",
            Note = "Test Note"
        };

        // Mock repository behavior
        mockRepo.Setup(r => r.AddSync(It.IsAny<PolicyNote>()))
                .ReturnsAsync(noteToReturn);

        // ACT
        var result = await service.CreateNoteAsync("P101", "Test Note");

        // ASSERT
        Assert.Equal("P101", result.PolicyNumber);
        Assert.Equal("Test Note", result.Note);
    }
    [Fact]
    public async Task GetNotesAsync_ShouldReturnListOfNotes()
    {
        // ARRANGE
        var mockRepo = new Mock<IPolicyNotesRepository>();
        var service = new PolicyNotesServices(mockRepo.Object);

        var notes = new List<PolicyNote>
        {
            new PolicyNote { Id = 1, PolicyNumber = "P101", Note = "Note 1" },
            new PolicyNote { Id = 2, PolicyNumber = "P102", Note = "Note 2" }
        };

        // Mock repository behavior
        mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(notes);

        // ACT
        var result = await service.GetNotesAsync();

        // ASSERT
        Assert.Equal(2, result.Count);
        Assert.Equal("P101", result[0].PolicyNumber);
    }
}
