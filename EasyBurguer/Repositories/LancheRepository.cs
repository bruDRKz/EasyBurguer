using EasyBurguer.Context;
using EasyBurguer.Models;
using EasyBurguer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyBurguer.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
                                                        Where(l => l.IsLanchePreferido).
                                                        Include(c => c.Categoria);

        public Lanche GetLancheByID(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheID == lancheId);
        }
    }
}
