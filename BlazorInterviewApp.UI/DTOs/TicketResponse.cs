using BlazorInterviewApp.UI.Shared;

namespace BlazorInterviewApp.UI.DTOs;

public class TicketResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public string CustomerName { get; set; } = "";

    public TicketStatus Status { get; set; }

    public TicketPriority Priority { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? AssignedTo { get; set; }
}