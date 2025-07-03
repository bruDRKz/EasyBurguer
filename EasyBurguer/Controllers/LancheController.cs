<<<<<<< HEAD
﻿using AspNetCoreGeneratedDocument;
using EasyBurguer.Models;
using EasyBurguer.Repositories;
=======
﻿using EasyBurguer.Repositories;
>>>>>>> FirstStep
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

<<<<<<< HEAD
        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _LancheRepository.Lanches.OrderBy(l => l.LancheID);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _LancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.Nome);
                }
                else 
                {
                    lanches = _LancheRepository.Lanches
                       .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                       .OrderBy(l => l.Nome);
                }
                    categoriaAtual = categoria;
            }
            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };
                return View(lanchesListViewModel);
=======
        public IActionResult List()
        {
            //var lanches = _LancheRepository.Lanches;
            //return View(lanches);

            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _LancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lanchesListViewModel);
>>>>>>> FirstStep
        }
    }
}
