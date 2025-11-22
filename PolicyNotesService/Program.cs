using Microsoft.EntityFrameworkCore;
using PolicyNotesService.Data;
using PolicyNotesService.Repositories;
using PolicyNotesService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("PolicyNotesDb"));
builder.Services.AddScoped<IPolicyNotesRepository, PolicyNotesRepository>();
builder.Services.AddScoped<IPolicyNotesServices, PolicyNotesServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


app.MapPost("/notes", async (IPolicyNotesServices service, PolicyNoteDto request) =>
{
    var created = await service.CreateNoteAsync(request.PolicyNumber, request.Note);
    return Results.Created($"/notes/{created.Id}", created);
});

app.MapGet("/notes", async (IPolicyNotesServices service) =>
{
    var notes = await service.GetNotesAsync();
    return Results.Ok(notes);
});
app.MapGet("/notes/{id:int}", async (int id, IPolicyNotesServices service) =>
{
    var note = await service.GetNoteByIdAsync(id);
    return note is not null ? Results.Ok(note) : Results.NotFound();
});



app.MapDelete("/notes/{id:int}", async (int id, IPolicyNotesServices service) =>
{
    var deleted = await service.DeleteNoteAsync(id);
    return deleted ? Results.Ok() : Results.NotFound();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
record PolicyNoteDto(string PolicyNumber, string Note);

public partial class Program { }
