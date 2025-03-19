using EasyBurguer.Repositories;
using EasyBurguer.Repositories.Interfaces;
using EasyBurguer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyBurguer.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _LancheRepository;

        public LancheController(ILancheRepository lancheRepository) //Injeção de dependencia do meu repositorio para acesso ao banco
        {
            _LancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            //var lanches = _LancheRepository.Lanches;
            //return View(lanches);

            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _LancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lanchesListViewModel);
        }
    }
}
