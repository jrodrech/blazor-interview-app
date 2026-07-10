// DTOs/TicketDetailsResponse.cs

using BlazorInterviewApp.UI.Shared;

namespace BlazorInterviewApp.UI.DTOs;

public class TicketDetailsResponse
{
    public int Id { get; init; }

    public string Title { get; init; } = "";

    public string Description { get; init; } = "";

    public TicketStatus Status { get; init; }

    public TicketPriority Priority { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }

    public string CustomerName { get; init; } = "";

    public string? AssignedTo { get; init; }
}