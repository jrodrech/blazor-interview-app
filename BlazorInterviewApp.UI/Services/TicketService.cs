using BlazorInterviewApp.UI.Data;
using BlazorInterviewApp.UI.DTOs;
using BlazorInterviewApp.UI.Models;
using BlazorInterviewApp.UI.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorInterviewApp.UI.Services;

public class TicketService : ITicketService
{
    private readonly AppDbContext _db;

    public TicketService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<TicketResponse>> GetAllAsync()
    {
        return await _db.Tickets
        .Select(t => new TicketResponse
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            CustomerName = t.CustomerName,
            Status = t.Status,
            Priority = t.Priority,
            CreatedAt = t.CreatedAt,
            AssignedTo = t.AssignedTo
        })
        .ToListAsync();
    }

    public async Task<TicketResponse> CreateAsync(TicketCreateRequest newTicket)
    {
        var ticket = new Ticket
        {
            Title = newTicket.Title,
            Description = newTicket.Description,
            CustomerName = newTicket.CustomerName,
            Status = TicketStatus.Open,
            Priority = newTicket.Priority,
            CreatedAt = DateTime.UtcNow
        };

        _db.Tickets.Add(ticket);

        await _db.SaveChangesAsync();

        return new TicketResponse {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            CustomerName = ticket.CustomerName,
            Status = ticket.Status,
            Priority = ticket.Priority,
            CreatedAt = ticket.CreatedAt
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ticket = await _db.Tickets.FindAsync(id);

        if (ticket is null)
            return false;

        _db.Tickets.Remove(ticket);

        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<TicketResponse?> UpdateAsync(int id, TicketUpdateRequest updated)
    {
        var ticket = await _db.Tickets.FindAsync(id);

        if (ticket is null)
            return null;

        ticket.Status = updated.Status;
        ticket.Priority = updated.Priority;
        ticket.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        return new TicketResponse
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            CustomerName = ticket.CustomerName,
            Status = ticket.Status,
            Priority = ticket.Priority,
            CreatedAt = ticket.CreatedAt,
            AssignedTo = ticket.AssignedTo
        };
    }
}