using BlazorInterviewApp.UI.Components;
using BlazorInterviewApp.UI.Data;
using BlazorInterviewApp.UI.DTOs;
using BlazorInterviewApp.UI.Models;
using BlazorInterviewApp.UI.Services;
using BlazorInterviewApp.UI.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tickets.db"));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.EnsureCreated();

    if (!db.Tickets.Any())
    {
        db.Tickets.AddRange(
            new Ticket
            {
                Title = "Cannot login",
                Description = "User password reset failed",
                Status = TicketStatus.Open,
                Priority = TicketPriority.High,
                CreatedAt = DateTime.UtcNow,
                CustomerName = "Alice"
            },
            new Ticket
            {
                Title = "Report export broken",
                Description = "CSV download not working",
                Status = TicketStatus.InProgress,
                Priority = TicketPriority.Medium,
                CreatedAt = DateTime.UtcNow,
                CustomerName = "Bob"
            }
        );

        db.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();


app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/tickets", async (ITicketService service) =>
{
    return await service.GetAllAsync();
});
app.MapPost("/tickets", async (TicketCreateRequest ticket, ITicketService service) =>
{
    var created = await service.CreateAsync(ticket);

    return Results.Created($"/tickets/{created.Id}", created);
});
app.MapDelete("/tickets/{id:int}", async (int id, ITicketService service) =>
{
    var deleted = await service.DeleteAsync(id);

    return deleted
        ? Results.NoContent()
        : Results.NotFound();
});
app.MapPatch("/tickets/{id:int}", async (int id, TicketUpdateRequest updated, ITicketService service) =>
{
    var ticket = await service.UpdateAsync(id, updated);

    return ticket is not null
        ? Results.Ok(ticket)
        : Results.NotFound();
});


app.Run();
