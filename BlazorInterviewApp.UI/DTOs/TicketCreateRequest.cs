using BlazorInterviewApp.UI.Shared;
using System.ComponentModel.DataAnnotations;

namespace BlazorInterviewApp.UI.DTOs;

public class TicketCreateRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = "";

    [Required]
    [StringLength(100)]
    public string Description { get; set; } = "";

    [Required]
    [StringLength(100)]
    public string CustomerName { get; set; } = "";

    public TicketPriority Priority { get; set; }
}