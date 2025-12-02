using Microsoft.AspNetCore.Mvc;

namespace FuncionalHealthTechChallenge.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
