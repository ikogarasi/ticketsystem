using Microsoft.AspNetCore.Mvc;

namespace TicketSystemWeb.Areas.Admin.Controllers
{
    public class BoardingPassesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
