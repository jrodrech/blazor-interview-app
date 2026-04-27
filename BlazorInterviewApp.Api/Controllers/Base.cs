using Microsoft.AspNetCore.Mvc;

namespace BlazorInterviewApp.Api.Controllers
{
    public class Base : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("tickets")]
        public List<string> GetTickets()
        {
            return new List<string> { "Ticket A", "Ticket B", "Ticket C" };
        }
    }
}
