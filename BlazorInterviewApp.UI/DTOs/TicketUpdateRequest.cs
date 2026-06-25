using BlazorInterviewApp.UI.Shared;

namespace BlazorInterviewApp.UI.DTOs;

public class TicketUpdateRequest
{
    public TicketStatus Status { get; set; }

    public TicketPriority Priority { get; set; }
}