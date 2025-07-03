using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyBurguer.Controllers
{
    public class ContatoController : Controller
    {
        // GET: ContatoController
        public IActionResult Index()
        {
            return View();
        }

    }  
}
