using BlazorInterviewApp.UI.DTOs;
using BlazorInterviewApp.UI.Models;

namespace BlazorInterviewApp.UI.Services;

public interface ITicketService
{
    Task<List<TicketResponse>> GetAllAsync();

    Task<TicketResponse> CreateAsync(TicketCreateRequest newTicket);

    Task<bool> DeleteAsync(int id);

    Task<TicketResponse?> UpdateAsync(int id, TicketUpdateRequest updated);
    
    Task<TicketDetailsResponse?> GetByIdAsync(int id);
}