using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
