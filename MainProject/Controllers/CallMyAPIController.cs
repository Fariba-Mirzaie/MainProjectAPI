using Microsoft.AspNetCore.Mvc;

namespace MainProject.Controllers
{
    public class CallMyAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
