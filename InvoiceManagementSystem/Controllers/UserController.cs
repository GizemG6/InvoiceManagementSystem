using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
