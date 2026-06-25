using Microsoft.EntityFrameworkCore;
using BlazorInterviewApp.UI.Models;

namespace BlazorInterviewApp.UI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();
}