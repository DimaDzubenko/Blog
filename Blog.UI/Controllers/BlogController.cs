using Microsoft.AspNetCore.Mvc;

namespace Blog.UI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
