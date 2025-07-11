using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EasyBurguer.Models;
using EasyBurguer.Repositories.Interfaces;
using EasyBurguer.ViewModels;

namespace EasyBurguer.Controllers;

public class HomeController : Controller
{
    private readonly ILancheRepository _lancheRepository;

    public HomeController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            LanchesPreferidos = _lancheRepository.LanchesPreferidos
        };
        return View(homeViewModel);
    }
     
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
